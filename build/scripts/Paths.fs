namespace Scripts

module Paths =

    let OwnerName = "elastic"
    let RepositoryName = "ecs-dotnet"
    let Repository = sprintf "https://github.com/%s/%s" OwnerName RepositoryName

    let private buildFolder = "build"
    let TargetsFolder = "build/scripts"
    let BuildOutput = sprintf "%s/output" buildFolder
    
    let Solution = "src/ecs-dotnet.sln"
    
    let Output(folder) = sprintf "%s/%s" BuildOutput folder
    
