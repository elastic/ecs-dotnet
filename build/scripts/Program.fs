module Program

open Argu
open Bullseye
open ProcNet
open CommandLine
    
[<EntryPoint>]
let main argv =
    let parser = ArgumentParser.Create<Arguments>(programName = "./build.sh")
    let parsed = 
        try
            let parsed = parser.ParseCommandLine(inputs = argv, raiseOnUsage = true)
            let arguments = parsed.GetSubCommand()
            Some (parsed, arguments)
        with e ->
            printfn "%s" e.Message
            None
    
    match parsed with
    | None -> 2
    | Some (parsed, arguments) ->
        
        let target = arguments.Name
        
        Targets.Setup parsed arguments
        let swallowTypes = [typeof<ProcExecException>; typeof<ExceptionExiter>]
        
        Targets.RunTargetsAndExit
            ([target], (fun e -> swallowTypes |> List.contains (e.GetType()) ), ":")
        0
        
