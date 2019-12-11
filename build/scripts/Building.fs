﻿namespace Scripts

open System.IO

open Paths
open Tooling
open Versioning
open Fake.Core
open Fake.IO
open Commandline

module Build =

    let Restore() = DotNet.Exec ["restore"; Solution; ] |> ignore

    let Compile args (ArtifactsVersion(version)) = 
        let props = 
            [ 
                "CurrentVersion", (version.Full.ToString());
                "CurrentAssemblyVersion", (version.Assembly.ToString());
                "CurrentAssemblyFileVersion", (version.AssemblyFile.ToString());
                "OutputPathBaseDir", Path.GetFullPath Paths.BuildOutput;
            ] 
            |> List.map (fun (p,v) -> sprintf "%s=%s" p v)
            |> String.concat ";"
            |> sprintf "/property:%s"
            
        DotNet.Exec ["build"; Solution; "-c"; "Release"; props] |> ignore

    let Clean () =
        printfn "Cleaning known output folders"
        Shell.cleanDir Paths.BuildOutput
        DotNet.Exec ["clean"; Solution; "-c"; "Release"] |> ignore 
