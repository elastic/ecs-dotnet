# Specification folder


This folder provides a local copy of the ECS spec to this repository. 

Used by [`tools/Elastic.CommonSchemaGenerator`](../../tools/Elastic.CommonSchema.Generator) to generate source code under `src`

No automation exist currently for generating/updating the spec.

Simply run 

```bash
dotnet run -c Release --project tools/Elastic.CommonSchema.Generator
```

To kick of the interactive tool to download a new version of the spec and generate all codebases. 