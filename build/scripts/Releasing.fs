namespace Scripts

open Versioning

module Release =
    
    let NugetPack version = 
    
        Tooling.DotNet.ExecIn "src" [ "pack"; 
            "-c"; "Release";
             (sprintf "-p:Version=%s" <| version.Full.ToString()); 
             (sprintf "-p:CurrentVersion=%s" <| version.Full.ToString()); 
             (sprintf "-p:CurrentAssemblyVersion=%s" <| version.Assembly.ToString()); 
             (sprintf "-p:CurrentAssemblyFileVersion=%s" <| version.AssemblyFile.ToString()); 
             "--output"; (sprintf "../%s" <| Paths.BuildOutput)
        ] |> ignore
