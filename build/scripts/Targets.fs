namespace Scripts

open System
open System.IO

open Build
open Commandline
open Bullseye
open ProcNet
open Fake.Core

module Main =

    let private target name action = Targets.Target(name, new Action(action)) 
    let private skip name = printfn "SKIPPED target '%s' evaluated not to run" name |> ignore
    let private conditional optional name action = target name (if optional then action else (fun _ -> skip name)) 
    let private command name dependencies action = Targets.Target(name, dependencies, new Action(action))
    
    /// <summary>Sets command line environments indicating we are building from the command line</summary>
    let setCommandLineEnvVars () =
        Environment.setEnvironVar "ECSDOTNET_COMMAND_LINE_BUILD" "1"
          
    let [<EntryPoint>] main args = 
        
        setCommandLineEnvVars ()
        
        let parsed = Commandline.parse (args |> Array.toList)
        
        let buildVersions = Versioning.BuildVersioning parsed
        let artifactsVersion = Versioning.ArtifactsVersion buildVersions
        Versioning.Validate parsed.Target buildVersions
        
        target "touch" <| fun _ -> printfn "Touching build %O" artifactsVersion

        target "start" <| fun _ -> 
            match (isMono, parsed.ValidMonoTarget) with
            | (true, false) -> failwithf "%s is not a valid target on mono because it can not call ILRepack" (parsed.Target)
            | _ -> printfn "STARTING BUILD"

        conditional parsed.NeedsClean "clean" Build.Clean 

        conditional parsed.NeedsFullBuild "full-build" <| fun _ -> Build.Compile parsed artifactsVersion

        target "version" <| fun _ -> printfn "Artifacts Version: %O" artifactsVersion

        target "restore" Restore

        target "nuget-pack" <| fun _ -> Release.NugetPack artifactsVersion

        conditional (parsed.Target <> "canary") "generate-release-notes" <| fun _ -> ReleaseNotes.GenerateNotes buildVersions 

        target "validate-artifacts" <| fun _ -> Versioning.ValidateArtifacts artifactsVersion
        
        // the following are expected to be called as targets directly        
        let buildChain = [
            "clean"; "version"; "restore"; "full-build"; 
        ]
        command "build" buildChain <| fun _ -> printfn "STARTING BUILD"

        command "canary" [ "version"; "release";] <| fun _ -> printfn "Finished Release Build %O" artifactsVersion

        command "release" [ 
           "build"; "nuget-pack"; "validate-artifacts"; "generate-release-notes"
        ] (fun _ -> printfn "Finished Release Build %O" artifactsVersion)

        command "diff" [ "clean"; ] <| fun _ -> Differ.Run parsed

        Targets.RunTargetsAndExit([parsed.Target], fun e -> e.GetType() = typeof<ProcExecException>)

        0
