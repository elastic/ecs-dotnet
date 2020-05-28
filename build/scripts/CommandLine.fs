module CommandLine

open Argu
open Microsoft.FSharp.Reflection

type Arguments =
    | [<CliPrefix(CliPrefix.None);SubCommand>] Clean
    | [<CliPrefix(CliPrefix.None);SubCommand>] Build
    | [<CliPrefix(CliPrefix.None);SubCommand>] Test
    
    | [<CliPrefix(CliPrefix.None);Hidden;SubCommand>] PristineCheck 
    | [<CliPrefix(CliPrefix.None);Hidden;SubCommand>] GeneratePackages
    | [<CliPrefix(CliPrefix.None);Hidden;SubCommand>] ValidatePackages 
    | [<CliPrefix(CliPrefix.None);Hidden;SubCommand>] GenerateReleaseNotes 
    | [<CliPrefix(CliPrefix.None);Hidden;SubCommand>] GenerateApiChanges 
    | [<CliPrefix(CliPrefix.None);SubCommand>] Release
    
    | [<CliPrefix(CliPrefix.None);Hidden;SubCommand>] CreateReleaseOnGithub 
    | [<CliPrefix(CliPrefix.None);SubCommand>] Publish
    
    | [<Inherit;AltCommandLine("-s")>] SingleTarget of bool
    | [<Inherit>] Token of string 
    | [<Inherit;AltCommandLine("-c")>] CleanCheckout of bool
with
    interface IArgParserTemplate with
        member this.Usage =
            match this with
            | Clean _ -> "clean known output locations"
            | Build _ -> "Run build"
            | Test _ -> "Runs build then tests"
            | Release _ -> "runs build, tests, and create and validates the packages shy of publishing them"
            | Publish _ -> "Runs the full release"
            
            | SingleTarget _ -> "Runs the provided sub command without running their dependencies"
            | Token _ -> "Token to be used to authenticate with github"
            | CleanCheckout _ -> "Skip the clean checkout check that guards the release/publish targets"
            
            | PristineCheck  
            | GeneratePackages
            | ValidatePackages 
            | GenerateReleaseNotes
            | GenerateApiChanges
            | CreateReleaseOnGithub 
                -> "Undocumented, dependent target"
    member this.Name =
        match FSharpValue.GetUnionFields(this, typeof<Arguments>) with
        | case, _ -> case.Name.ToLowerInvariant()
