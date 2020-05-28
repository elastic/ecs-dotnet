module Paths

open System
open System.IO

let ToolName = "elasticsearch-net-abstractions"
let Repository = sprintf "elastic/%s" ToolName
let MainTFM = "netstandard2.0"

let ValidateAssemblyName = false
let IncludeGitHashInInformational = true
let GenerateApiChanges = false

let Root =
    let mutable dir = DirectoryInfo(".")
    while dir.GetFiles("*.sln").Length = 0 do dir <- dir.Parent
    Environment.CurrentDirectory <- dir.FullName
    dir
    
let RootRelative path = Path.GetRelativePath(Root.FullName, path) 
    
let Output = DirectoryInfo(Path.Combine(Root.FullName, "build", "output"))

let ToolProject = DirectoryInfo(Path.Combine(Root.FullName, "src", ToolName))
