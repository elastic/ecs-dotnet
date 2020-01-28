namespace Scripts

open Versioning

module Release =
    
    let NugetPack (ArtifactsVersion(version)) = 
    
        [|
           "Elastic.Apm.NLog";
           "Elastic.Apm.SerilogEnricher";
           "Elastic.CommonSchema";
           "Elastic.CommonSchema.BenchmarkDotNetExporter";
           "Elastic.CommonSchema.Serilog";
        |]
            |> Seq.iter(fun project -> Tooling.DotNet.ExecIn (sprintf "src/%s" <| project) [ "pack"; 
                "-c"; "Release";
                 (sprintf "-p:Version=%s" <| version.Full.ToString()); 
                 (sprintf "-p:CurrentVersion=%s" <| version.Full.ToString()); 
                 (sprintf "-p:CurrentAssemblyVersion=%s" <| version.Assembly.ToString()); 
                 (sprintf "-p:CurrentAssemblyFileVersion=%s" <| version.AssemblyFile.ToString()); 
                 (sprintf "-p:NuspecFile=package.nuspec"); 
                 (sprintf "-p:NuspecProperties=Version=%s" <| version.Full.ToString()); 
                 "--output"; (sprintf "../../%s" <| Paths.BuildOutput)
            ]) |> ignore
