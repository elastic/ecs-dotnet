namespace Scripts

open Versioning

module Release =
    
    let NugetPack (ArtifactsVersion(version)) = 
    
        Tooling.DotNet.ExecIn "src" [ "pack"; 
            "-c"; "Release";
            "--no-build";
             (sprintf "-p:Version=%s" <| version.Full.ToString()); 
             "--output"; (sprintf "../%s" <| Paths.BuildOutput)
        ] |> ignore
