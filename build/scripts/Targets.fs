module Targets

open Argu
open System
open System.IO
open Bullseye
open CommandLine
open Fake.Tools.Git
open ProcNet

    
let exec binary args =
    let r = Proc.Exec (binary, args |> List.map (fun a -> sprintf "\"%s\"" a) |> List.toArray)
    match r.HasValue with | true -> r.Value | false -> failwithf "invocation of `%s` timed out" binary
    
let private restoreTools = lazy(exec "dotnet" ["tool"; "restore"])
let private currentVersion =
    lazy(
        restoreTools.Value |> ignore
        let r = Proc.Start("dotnet", "minver", "-d", "canary", "-m", "0.1")
        let o = r.ConsoleOut |> Seq.find (fun l -> not(l.Line.StartsWith("MinVer:")))
        o.Line
    )
let private currentVersionInformational =
    lazy(
        match Paths.IncludeGitHashInInformational with
        | false -> currentVersion.Value
        | true -> sprintf "%s+%s" currentVersion.Value (Information.getCurrentSHA1( "."))
    )

let private clean (arguments:ParseResults<Arguments>) =
    if (Paths.Output.Exists) then Paths.Output.Delete (true)
    exec "dotnet" ["clean"] |> ignore
    
let private build (arguments:ParseResults<Arguments>) = exec "dotnet" ["build"; "-c"; "Release"] |> ignore

let private pristineCheck (arguments:ParseResults<Arguments>) =
    match Information.isCleanWorkingCopy "." with
    | true  -> printfn "The checkout folder does not have pending changes, proceeding"
    | _ -> failwithf "The checkout folder has pending changes, aborting"

let private test (arguments:ParseResults<Arguments>) =
    let junitOutput = Path.Combine(Paths.Output.FullName, "junit-{assembly}-{framework}-test-results.xml")
    let loggerPathArgs = sprintf "LogFilePath=%s" junitOutput
    let loggerArg = sprintf "--logger:\"junit;%s\"" loggerPathArgs
    exec "dotnet" ["test"; "-c"; "RELEASE"; loggerArg] |> ignore

let private generatePackages (arguments:ParseResults<Arguments>) =
    let output = Paths.RootRelative Paths.Output.FullName
    exec "dotnet" ["pack"; "-c"; "Release"; "-o"; output] |> ignore
    
let private validatePackages (arguments:ParseResults<Arguments>) =
    let output = Paths.RootRelative <| Paths.Output.FullName
    let nugetPackages =
        Paths.Output.GetFiles("*.nupkg") |> Seq.sortByDescending(fun f -> f.CreationTimeUtc)
        |> Seq.map (fun p -> Paths.RootRelative p.FullName)
        
    let appVeyorArgs =
        if Fake.Core.Environment.environVarAsBool "APPVEYOR" then ["-r"; "true"] else []
    
    let args = ["-v"; currentVersionInformational.Value; "-k"; Paths.SignKey; "-t"; output] @ appVeyorArgs
    nugetPackages |> Seq.iter (fun p -> exec "dotnet" (["nupkg-validator"; p] @ args) |> ignore)
    

let private generateApiChanges (arguments:ParseResults<Arguments>) =
    let output = Paths.RootRelative <| Paths.Output.FullName
    let currentVersion = currentVersion.Value
    let nugetPackages =
        Paths.Output.GetFiles("*.nupkg") |> Seq.sortByDescending(fun f -> f.CreationTimeUtc)
        |> Seq.map (fun p -> Path.GetFileNameWithoutExtension(Paths.RootRelative p.FullName).Replace("." + currentVersion, ""))
    nugetPackages
    |> Seq.iter(fun p ->
        let outputFile =
            let f = sprintf "breaking-changes-%s.md" p
            Path.Combine(output, f)
        let args =
            [
                "assembly-differ"
                (sprintf "previous-nuget|%s|%s|%s" p currentVersion Paths.MainTFM);
                (sprintf "directory|src/%s/bin/Release/%s" p Paths.MainTFM);
                "-a"; "true"; "--target"; p; "-f"; "github-comment"; "--output"; outputFile
            ]
        
        exec "dotnet" args |> ignore
    )
    
let private generateReleaseNotes (arguments:ParseResults<Arguments>) =
    let currentVersion = currentVersion.Value
    let output =
        Paths.RootRelative <| Path.Combine(Paths.Output.FullName, sprintf "release-notes-%s.md" currentVersion)
    let tokenArgs =
        match arguments.TryGetResult Token with
        | None -> []
        | Some token -> ["--token"; token;]
    let releaseNotesArgs =
        (Paths.Repository.Split("/") |> Seq.toList)
        @ ["--version"; currentVersion
           "--label"; "enhancement"; "New Features"
           "--label"; "bug"; "Bug Fixes"
           "--label"; "documentation"; "Docs Improvements"
        ] @ tokenArgs
        @ ["--output"; output]
        
    exec "dotnet" (["release-notes"] @ releaseNotesArgs) |> ignore

let private createReleaseOnGithub (arguments:ParseResults<Arguments>) =
    let currentVersion = currentVersion.Value
    let tokenArgs =
        match arguments.TryGetResult Token with
        | None -> []
        | Some token -> ["--token"; token;]
    let releaseNotes = Paths.RootRelative <| Path.Combine(Paths.Output.FullName, sprintf "release-notes-%s.md" currentVersion)
    let breakingChanges =
        let breakingChangesDocs = Paths.Output.GetFiles("breaking-changes-*.md")
        breakingChangesDocs 
        |> Seq.map(fun f -> ["--body"; Paths.RootRelative f.FullName])
        |> Seq.collect id
        |> Seq.toList
    let releaseArgs =
        (Paths.Repository.Split("/") |> Seq.toList)
        @ ["create-release"
           "--version"; currentVersion
           "--body"; releaseNotes; 
        ] @ breakingChanges @ tokenArgs
        
    exec "dotnet" (["release-notes"] @ releaseArgs) |> ignore
    
let private release (arguments:ParseResults<Arguments>) = printfn "release"
    
let private publish (arguments:ParseResults<Arguments>) = printfn "publish" 

let Setup (parsed:ParseResults<Arguments>) (subCommand:Arguments) =
    let step (name:string) action = Targets.Target(name, new Action(fun _ -> action(parsed)))
    
    let cmd (name:string) commandsBefore steps action =
        let singleTarget = (parsed.TryGetResult SingleTarget |> Option.defaultValue false)
        let deps =
            match (singleTarget, commandsBefore) with
            | (true, _) -> [] 
            | (_, Some d) -> d
            | _ -> []
        let steps = steps |> Option.defaultValue []
        Targets.Target(name, deps @ steps, Action(action))
        
    step Clean.Name clean
    cmd Build.Name None (Some [Clean.Name]) <| fun _ -> build parsed
    
    cmd Test.Name (Some [Build.Name;]) None <| fun _ -> test parsed
    
    step PristineCheck.Name pristineCheck
    step GeneratePackages.Name generatePackages 
    step ValidatePackages.Name validatePackages 
    step GenerateReleaseNotes.Name generateReleaseNotes
    step GenerateApiChanges.Name generateApiChanges
    cmd Release.Name
        (Some [PristineCheck.Name; Test.Name;])
        (Some [GeneratePackages.Name; ValidatePackages.Name; GenerateReleaseNotes.Name; GenerateApiChanges.Name])
        <| fun _ -> release parsed
        
    step CreateReleaseOnGithub.Name createReleaseOnGithub 
    cmd Publish.Name
        (Some [Release.Name])
        (Some [CreateReleaseOnGithub.Name; ])
        <| fun _ -> publish parsed
