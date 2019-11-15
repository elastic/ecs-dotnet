namespace Scripts

open System
open System.Runtime.InteropServices
open Fake.Core

//this is ugly but a direct port of what used to be duplicated in our DOS and bash scripts
module Commandline =

    let private usage = """
USAGE:

build <target> [params]

Targets:

* build-all
  - default target if non provided.
* clean
  - cleans build output folders
* release <version>
  - 0 create a release worthy nuget packages for [version] under build\output
* canary 
  - create a canary nuget package based on the current version.
* diff <..args>
  - runs assembly-differ with the specified arguments
    see: https://github.com/nullean/AssemblyDiffer#differ
"""

    type VersionArguments = { Version: string; }

    type CommandArguments =
        | Unknown
        | SetVersion of VersionArguments

    type PassedArguments = {
        RemainingArguments: string list;
        Target: string;
        ValidMonoTarget: bool;
        NeedsFullBuild: bool;
        NeedsClean: bool;
        DoSourceLink: bool;

        CommandArguments: CommandArguments;
    }

    //TODO RENAME to notWindows
    let isMono =
        RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || 
        RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.OSX)

    let parse (args: string list) =
        
        let target = 
            match (args |> List.tryHead) with
            | Some t -> t.Replace("-one", "")
            | _ -> "build"

        let parsed = {
            RemainingArguments = args
            Target = 
                match (args |> List.tryHead) with
                | Some t -> t.Replace("-one", "")
                | _ -> "build"
            ValidMonoTarget = 
                match target with
                | "release"
                | "canary" -> false
                | _ -> true
            NeedsFullBuild = true;
            NeedsClean = 
                match (target) with
                | ("release") -> true
                | ("build")
                | ("diff") -> false
                | _ -> true;
            CommandArguments = Unknown
            DoSourceLink = false
        }
            
        let arguments =
            match args with
            | _ :: tail -> target :: tail
            | [] -> [target]
        
        let split (s:string) = s.Split ',' |> Array.toList 

        match arguments with
        | [] | ["build"] | ["clean"] | ["touch"; ] | ["temp"; ] | ["canary"; ] -> parsed
        | "diff" :: tail -> { parsed with RemainingArguments = tail }
        | ["release"; version] -> { parsed with CommandArguments = SetVersion { Version = version }  }

        | _ ->
            eprintf "%s" usage
            failwith "Please consult printed help text on how to call our build"
