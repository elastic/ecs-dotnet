namespace Scripts

module Paths =

    let OwnerName = "elastic"
    let RepositoryName = "ecs-dotnet"
    let Repository = sprintf "https://github.com/%s/%s" OwnerName RepositoryName

    let BuildFolder = "build"
    let TargetsFolder = "build/scripts"
    let BuildOutput = sprintf "%s/output" BuildFolder
    
    let Tool tool = sprintf "packages/build/%s" tool
    let CheckedInToolsFolder = "build/tools"
    let KeysFolder = sprintf "%s/keys" BuildFolder
    let NugetOutput = sprintf "%s/_packages" BuildOutput
    let SourceFolder = "src"
    
    let Solution = "src/ecs-dotnet.sln"
    
    let CheckedInTool(tool) = sprintf "%s/%s" CheckedInToolsFolder tool
    let Keys(keyFile) = sprintf "%s/%s" KeysFolder keyFile
    let Output(folder) = sprintf "%s/%s" BuildOutput folder
    let Source(folder) = sprintf "%s/%s" SourceFolder folder
    
    let BinFolder (folder:string) = 
        let f = folder.Replace(@"\", "/")
        sprintf "%s/%s/bin/Release" SourceFolder f
