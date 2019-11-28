namespace Scripts

[<AutoOpen>]
module Projects = 
    type DotNetFrameworkIdentifier = { MSBuild: string; Nuget: string; DefineConstants: string; }

    type DotNetFramework = 
        | NetStandard2_0
        | Net461
        | NetCoreApp2_1
        static member All = [NetStandard2_0; Net461]
        member this.Identifier = 
            match this with
            | NetStandard2_0 -> { MSBuild = "netstandard2.0"; Nuget = "netstandard2.0"; DefineConstants = ""; }
            | NetCoreApp2_1 -> { MSBuild = "netcoreapp2.1"; Nuget = "netcoreapp2.1"; DefineConstants = ""; }
            | Net461 -> { MSBuild = "net461"; Nuget = "net461"; DefineConstants = ""; }

    type Project =
        | CommonSchema
        | CommonSchemaSerilog
        
    type PrivateProject =
        | Generator

    type DotNetProject = 
        | Project of Project
        | PrivateProject of PrivateProject

        static member All = 
            seq [
                Project Project.CommonSchema; 
                Project Project.CommonSchemaSerilog; 
                PrivateProject PrivateProject.Generator
            ]
        static member AllPublishable =
            seq [
                Project Project.CommonSchema
                Project Project.CommonSchemaSerilog                
            ]

        member this.Name =
            match this with
            | Project CommonSchema -> "Elastic.CommonSchema"
            | Project CommonSchemaSerilog -> "Elastic.CommonSchema.Serilog"
            | PrivateProject Generator -> "Generator"
 
        member this.NugetId =
            match this with
            | Project CommonSchema -> "Elastic.CommonSchema"
            | Project CommonSchemaSerilog -> "Elastic.CommonSchema.Serilog"
            | _ -> this.Name
                
        member this.Versioned name version =
            match version with
            | Some s -> sprintf "%s%s" name s
            | None -> name

    type DotNetFrameworkProject = { framework: DotNetFramework; project: DotNetProject }
    let AllPublishableProjectsWithSupportedFrameworks = seq {
        for framework in DotNetFramework.All do
        for project in DotNetProject.AllPublishable do
            yield { framework = framework; project= project}
        }
