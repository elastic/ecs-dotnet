namespace Scripts

[<AutoOpen>]
module Projects = 
    type DotNetFrameworkIdentifier = { MSBuild: string; Nuget: string; DefineConstants: string; }

    type DotNetFramework = 
        | NetStandard2_0
        | Net461
        | NetCoreApp2_1
        static member All = [NetStandard2_0; Net461]
        static member AllTests = [NetCoreApp2_1; Net461] 
        member this.Identifier = 
            match this with
            | NetStandard2_0 -> { MSBuild = "netstandard2.0"; Nuget = "netstandard2.0"; DefineConstants = ""; }
            | NetCoreApp2_1 -> { MSBuild = "netcoreapp2.1"; Nuget = "netcoreapp2.1"; DefineConstants = ""; }
            | Net461 -> { MSBuild = "net461"; Nuget = "net461"; DefineConstants = ""; }

    type Project =
        | CommonSchema
        
    type PrivateProject =
        | Generator

    type DotNetProject = 
        | Project of Project
        | PrivateProject of PrivateProject

        static member All = 
            seq [
                Project Project.CommonSchema; 
                PrivateProject PrivateProject.Generator
            ]

        static member AllPublishable = seq [Project Project.CommonSchema] 
        static member Tests = seq [PrivateProject PrivateProject.Generator]

        member this.VersionedMergeDependencies =
            match this with 
            | Project CommonSchema -> [Project Project.CommonSchema; ]
            | _ -> []

        member this.Name =
            match this with
            | Project CommonSchema -> "Elastic.CommonSchema"
            | PrivateProject Generator -> "Generator"
 
        member this.NugetId =
            match this with
            | Project CommonSchema -> "Elastic.CommonSchema"
            | _ -> this.Name
                
        member this.Versioned name version =
            match version with
            | Some s -> sprintf "%s%s" name s
            | None -> name
            
        member this.InternalName =
            match this with
            | Project _ -> this.Name 
            | PrivateProject _ -> sprintf "Elastic.Internal.%s" this.Name
                
        static member TryFindName (name: string) =
            DotNetProject.All
            |> Seq.map(fun p -> p.Name)
            |> Seq.tryFind(fun p -> p.ToLowerInvariant() = name.ToLowerInvariant())

    type DotNetFrameworkProject = { framework: DotNetFramework; project: DotNetProject }
    let AllPublishableProjectsWithSupportedFrameworks = seq {
        for framework in DotNetFramework.All do
        for project in DotNetProject.AllPublishable do
            yield { framework = framework; project= project}
        }
