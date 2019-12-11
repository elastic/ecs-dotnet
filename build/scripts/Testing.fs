namespace Scripts

open System
open Tooling
open Fake.Core
open Fake.IO.Globbing.Operators
open System.IO
open Commandline
open Versioning

module Tests =
    let private buildingOnAzurePipeline = Environment.environVarAsBool "TF_BUILD"
    
    let TestAll (ArtifactsVersion(version)) =
        Directory.CreateDirectory Paths.BuildOutput |> ignore
        let command = 
            let p = [
                "test"; "."; "-c"; "RELEASE";
                (sprintf "-p:Version=%s" <| version.Full.ToString()); 
            ]
            //make sure we only test netcoreapp on linux or requested on the command line to only test-one
            match Environment.isLinux with 
            | true ->
                printfn "Running on linux defaulting tests to .NET Core only" 
                ["--framework"; "netcoreapp3.0"] |> List.append p
            | _  -> p
        let commandWithCodeCoverage =
            // TODO /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura
            // Using coverlet.msbuild package
            // https://github.com/tonerdo/coverlet/issues/110
            // Bites us here as well a PR is up already but not merged will try again afterwards
            // https://github.com/tonerdo/coverlet/pull/329
            match buildingOnAzurePipeline with
            | true -> [ "--logger"; "trx"; "--collect"; "\"Code Coverage\""; "-v"; "m"] |> List.append command
            | _  -> command
        
        let testProjects = !! "tests/**/*.csproj"

        for projectFile in testProjects do
            let folder = (FileInfo projectFile).Directory.FullName
            printfn "Running tests in %s" folder
            
            Tooling.DotNet.ExecInWithTimeout folder commandWithCodeCoverage (TimeSpan.FromMinutes 30.)
