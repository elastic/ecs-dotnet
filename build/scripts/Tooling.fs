﻿namespace Scripts

open System
open System.IO
open ProcNet
open ProcNet.Std

module Tooling = 

    type ExecResult = { ExitCode: int; Output: Std.LineOut seq;}
    
    let private defaultTimeout = TimeSpan.FromMinutes(5.)
    
    let startRedirectedInWithTimeout timeout workinDir bin args = 
        let startArgs = StartArguments(bin, args |> List.toArray)
        if (Option.isSome workinDir) then
            startArgs.WorkingDirectory <- Option.defaultValue "" workinDir
        if Commandline.isMono then startArgs.WaitForStreamReadersTimeout <- Nullable<TimeSpan>()
        let result = Proc.StartRedirected(startArgs, timeout)
        if not result.Completed then failwithf "process failed to complete within %O: %s" timeout bin
        if not result.ExitCode.HasValue then failwithf "process yielded no exit code: %s" bin
        { ExitCode = result.ExitCode.Value; Output = seq []}
    
    let readInWithTimeout timeout workinDir bin args = 
        let startArgs = StartArguments(bin, args |> List.toArray)
        if (Option.isSome workinDir) then
            startArgs.WorkingDirectory <- Option.defaultValue "" workinDir
        let result = Proc.Start(startArgs, timeout, ConsoleOutColorWriter())
        if not result.Completed then failwithf "process failed to complete within %O: %s" timeout bin
        if not result.ExitCode.HasValue then failwithf "process yielded no exit code: %s" bin
        { ExitCode = result.ExitCode.Value; Output = seq result.ConsoleOut}
        
    let read bin args = readInWithTimeout defaultTimeout None bin args
    
    let execInWithTimeout timeout workinDir bin args = 
        let startArgs = ExecArguments(bin, args |> List.toArray)
        if (Option.isSome workinDir) then
            startArgs.WorkingDirectory <- Option.defaultValue "" workinDir
        let result = Proc.Exec(startArgs, timeout)
        try
            if not result.HasValue || result.Value > 0 then
                failwithf "process returned %i: %s" result.Value bin
        with
        | :? ProcExecException as ex -> failwithf "%s" ex.Message

    let execIn workingDir bin args = execInWithTimeout defaultTimeout workingDir bin args
    
    let exec bin args = execIn None bin args

    type BuildTooling(timeout, path) =
        let timeout = match timeout with | Some t -> t | None -> defaultTimeout
        member this.Path = path
        member this.StartInWithTimeout workingDirectory arguments timeout = startRedirectedInWithTimeout timeout (Some workingDirectory) this.Path arguments
        member this.ReadInWithTimeout workingDirectory arguments timeout = readInWithTimeout timeout (Some workingDirectory) this.Path arguments
        member this.ExecInWithTimeout workingDirectory arguments timeout = execInWithTimeout timeout (Some workingDirectory) this.Path arguments
        member this.ExecWithTimeout arguments timeout = execInWithTimeout timeout None this.Path arguments
        member this.ExecIn workingDirectory arguments = this.ExecInWithTimeout workingDirectory arguments timeout
        member this.Exec arguments = this.ExecWithTimeout arguments timeout

    //used by differ
    let nugetFile = Path.GetFullPath "build/scripts/bin/Release/netcoreapp3.0/NuGet.exe" 
    let DotNet = BuildTooling(Some <| TimeSpan.FromMinutes(5.), "dotnet")
