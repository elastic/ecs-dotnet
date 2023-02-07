module Targets

open System.Net.Http
open Fake.Tools.Git
open Argu
open System
open System.Linq
open System.IO
open Bullseye
open CommandLine
open ProcNet

let runningOnCI = Fake.Core.Environment.hasEnvironVar "CI"
let runningOnWindows = Fake.Core.Environment.isWindows

let execWithTimeout binary args timeout =
    let opts =
        ExecArguments(binary, args |> List.map (sprintf "\"%s\"") |> List.toArray)
        
    let r = Proc.Exec(opts, timeout)

    match r.HasValue with
    | true -> r.Value
    | false -> failwithf "invocation of `%s` timed out" binary

let exec binary args =
    execWithTimeout binary args (TimeSpan.FromMinutes 4)

let private restoreTools = lazy (exec "dotnet" [ "tool"; "restore" ])

let private currentVersion =
    lazy
        (restoreTools.Value |> ignore
         let r = Proc.Start("dotnet", "minver", "-d=canary", "-m=0.1")
         let o = r.ConsoleOut |> Seq.find (fun l -> not (l.Line.StartsWith("MinVer:")))
         o.Line)

let private currentVersionInformational =
    lazy
        (match Paths.IncludeGitHashInInformational with
         | false -> currentVersion.Value
         | true -> sprintf "%s+%s" currentVersion.Value (Information.getCurrentSHA1 (".")))

let private clean (arguments: ParseResults<Arguments>) =
    if (Paths.Output.Exists) then
        Paths.Output.Delete(true)

    exec "dotnet" [ "clean" ] |> ignore

let private build (arguments: ParseResults<Arguments>) =
    exec "dotnet" [ "build"; "-c"; "Release" ] |> ignore

let private pristineCheck (arguments: ParseResults<Arguments>) =
    let doCheck = arguments.TryGetResult CleanCheckout |> Option.defaultValue true

    match doCheck, Information.isCleanWorkingCopy "." with
    | _, true -> printfn "The checkout folder does not have pending changes, proceeding"
    | false, _ -> printf "Checkout is dirty but -c was specified to ignore this"
    | _ -> failwithf "The checkout folder has pending changes, aborting"

type TestMode = | Unit | Integration
let private runTests (arguments: ParseResults<Arguments>) testMode =
    
    let mode = match testMode with | Unit ->  "unit" | Integration -> "integration"
        
    let filterArg =
        match testMode with
        | Unit ->  [ "--filter"; "FullyQualifiedName!~IntegrationTests" ]
        | Integration -> [ "--filter"; "FullyQualifiedName~IntegrationTests" ]

    let os = if runningOnWindows then "win" else "linux"
    let junitOutput =
        Path.Combine(Paths.Output.FullName, $"junit-%s{os}-%s{mode}-{{assembly}}-{{framework}}-test-results.xml")

    let loggerPathArgs = sprintf "LogFilePath=%s" junitOutput
    let loggerArg = $"--logger:\"junit;%s{loggerPathArgs};MethodFormat=Class;FailureBodyFormat=Verbose\""
    let settingsArg = if runningOnCI then (["-s"; ".ci.runsettings"]) else [];

    execWithTimeout "dotnet" ([ "test" ] @ filterArg @ settingsArg @ [ "-c"; "RELEASE"; "-m:1"; loggerArg ]) (TimeSpan.FromMinutes 15)
    |> ignore

let private test (arguments: ParseResults<Arguments>) =
    runTests arguments Unit

let private integrate (arguments: ParseResults<Arguments>) =
    runTests arguments Integration

let private generatePackages (arguments: ParseResults<Arguments>) =
    let output = Paths.RootRelative Paths.Output.FullName
    exec "dotnet" [ "pack"; "-c"; "Release"; "-o"; output ] |> ignore

let private validatePackages (arguments: ParseResults<Arguments>) =
    let output = Paths.RootRelative <| Paths.Output.FullName

    let nugetPackages =
        Paths.Output.GetFiles("*.nupkg")
        |> Seq.sortByDescending (fun f -> f.CreationTimeUtc)
        |> Seq.map (fun p -> Paths.RootRelative p.FullName)

    let ciOnWindowsArgs = if runningOnCI && runningOnWindows then [ "-r"; "true" ] else []

    let args =
        [ "-v"; currentVersionInformational.Value; "-k"; Paths.SignKey; "-t"; output ] @ ciOnWindowsArgs

    nugetPackages |> Seq.iter (fun p -> exec "dotnet" ([ "nupkg-validator"; p ] @ args) |> ignore)

let private generateApiChanges (arguments: ParseResults<Arguments>) =
    let output = Paths.RootRelative <| Paths.Output.FullName
    let currentVersion = currentVersion.Value

    let nugetPackages =
        Paths.Output.GetFiles("*.nupkg")
        |> Seq.sortByDescending (fun f -> f.CreationTimeUtc)
        |> Seq.map (fun p ->
            Path
                .GetFileNameWithoutExtension(Paths.RootRelative p.FullName)
                .Replace("." + currentVersion, ""))

    let firstPath project tfms =
        tfms
        |> Seq.map (fun tfm -> (tfm, sprintf "directory|src/%s/bin/Release/%s" project Paths.MainTFM))
        |> Seq.where (fun (tfm, path) -> File.Exists path)
        |> Seq.tryHead

    nugetPackages
    |> Seq.iter (fun p ->
        let outputFile =
            let f = sprintf "breaking-changes-%s.md" p
            Path.Combine(output, f)

        let firstKnownTFM = firstPath p [ Paths.MainTFM; Paths.Netstandard21TFM ]

        match firstKnownTFM with
        | None -> printf "Skipping generating API changes for: %s" p
        | Some (tfm, path) ->
            let args =
                [
                    "assembly-differ"
                    (sprintf "previous-nuget|%s|%s|%s" p currentVersion tfm)
                    (sprintf "directory|%s" path)
                    "-a"
                    "true"
                    "--target"
                    p
                    "-f"
                    "github-comment"
                    "--output"
                    outputFile
                ]

            exec "dotnet" args |> ignore)

let private generateReleaseNotes (arguments: ParseResults<Arguments>) =
    let currentVersion = currentVersion.Value

    let output =
        Paths.RootRelative <| Path.Combine(Paths.Output.FullName, sprintf "release-notes-%s.md" currentVersion)

    let tokenArgs =
        match arguments.TryGetResult Token with
        | None -> []
        | Some token -> [ "--token"; token ]

    let releaseNotesArgs =
        (Paths.Repository.Split("/") |> Seq.toList)
        @ [
            "--version"
            currentVersion
            "--label"
            "enhancement"
            "New Features"
            "--label"
            "bug"
            "Bug Fixes"
            "--label"
            "documentation"
            "Docs Improvements"
          ]
          @ tokenArgs @ [ "--output"; output ]

    exec "dotnet" ([ "release-notes" ] @ releaseNotesArgs) |> ignore

let private createReleaseOnGithub (arguments: ParseResults<Arguments>) =
    let currentVersion = currentVersion.Value

    let tokenArgs =
        match arguments.TryGetResult Token with
        | None -> []
        | Some token -> [ "--token"; token ]

    let releaseNotes =
        Paths.RootRelative <| Path.Combine(Paths.Output.FullName, sprintf "release-notes-%s.md" currentVersion)

    let breakingChanges =
        let breakingChangesDocs = Paths.Output.GetFiles("breaking-changes-*.md")

        breakingChangesDocs |> Seq.map (fun f -> [ "--body"; Paths.RootRelative f.FullName ]) |> Seq.collect id |> Seq.toList

    let releaseArgs =
        (Paths.Repository.Split("/") |> Seq.toList)
        @ [ "create-release"; "--version"; currentVersion; "--body"; releaseNotes ] @ breakingChanges @ tokenArgs

    exec "dotnet" ([ "release-notes" ] @ releaseArgs) |> ignore

let private updateLoggingSpec (arguments: ParseResults<Arguments>) =
    let commit =
        match arguments.TryGetResult Commit with
        | None -> "main"
        | Some commit -> commit

    async {
        use client = new HttpClient()

        try
            let! response =
                let url =
                    sprintf "https://raw.githubusercontent.com/elastic/ecs-logging/%s/spec/spec.json" commit

                client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead) |> Async.AwaitTask

            response.EnsureSuccessStatusCode() |> ignore
            use! stream = response.Content.ReadAsStreamAsync() |> Async.AwaitTask

            use fileStream =
                new FileStream(Paths.RootRelative("tests/Elastic.CommonSchema.Tests/Specs/spec.json"), FileMode.Create, FileAccess.Write, FileShare.None)

            do! stream.CopyToAsync(fileStream) |> Async.AwaitTask

            do!
                File.WriteAllTextAsync(Paths.RootRelative("tests/Elastic.CommonSchema.Tests/Specs/spec_version.txt"), commit)
                |> Async.AwaitTask
        with ex ->
            printfn "Could not update logging spec: %A" ex
    }
    |> Async.RunSynchronously



let private release (arguments: ParseResults<Arguments>) = printfn "release"

let private publish (arguments: ParseResults<Arguments>) = printfn "publish"

// temp fix for unit reporting: https://github.com/elastic/apm-pipeline-library/issues/2063
let teardown () =
    if Paths.Output.Exists then
        let isSkippedFile p =
            File.ReadLines(p).FirstOrDefault() = "<testsuites />"
        Paths.Output.GetFiles("junit-*.xml")
            |> Seq.filter (fun p -> isSkippedFile p.FullName)
            |> Seq.iter (fun f ->
                printfn $"Removing empty test file: %s{f.FullName}"
                f.Delete()
            )
    Console.WriteLine "Ran teardown"

let Setup (parsed: ParseResults<Arguments>) (subCommand: Arguments) =
    let step (name: string) action =
        Targets.Target(name, Action(fun _ -> action (parsed)))

    let cmd (name: string) commandsBefore steps action =
        let singleTarget = (parsed.TryGetResult SingleTarget |> Option.defaultValue false)

        let deps =
            match (singleTarget, commandsBefore) with
            | (true, _) -> []
            | (_, Some d) -> d
            | _ -> []

        let steps = steps |> Option.defaultValue []
        Targets.Target(name, deps @ steps, Action(action))

    step Clean.Name clean
    cmd Build.Name None (Some [ Clean.Name ]) <| fun _ -> build parsed

    cmd Test.Name (Some [ Build.Name ]) None <| fun _ -> test parsed
    cmd Integrate.Name (Some [ Build.Name ]) None <| fun _ -> integrate parsed

    cmd UpdateSpec.Name None None <| fun _ -> updateLoggingSpec parsed

    step PristineCheck.Name pristineCheck
    step GeneratePackages.Name generatePackages
    step ValidatePackages.Name validatePackages
    step GenerateReleaseNotes.Name generateReleaseNotes
    step GenerateApiChanges.Name generateApiChanges

    cmd
        Release.Name
        (Some [ PristineCheck.Name; Test.Name; Integrate.Name ])
        (Some [ GeneratePackages.Name; ValidatePackages.Name; GenerateReleaseNotes.Name; GenerateApiChanges.Name ])
    <| fun _ -> release parsed

    step CreateReleaseOnGithub.Name createReleaseOnGithub

    cmd Publish.Name (Some [ Release.Name ]) (Some [ CreateReleaseOnGithub.Name ]) <| fun _ -> publish parsed