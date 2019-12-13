# ECS .NET

## Introduction

This repository contains .NET integrations that use the Elastic Common Schema, including popular logging frameworks.

The Elastic Common Schema (ECS) defines a common set of fields for ingesting data into Elasticsearch. A common schema helps you correlate data from sources like logs and metrics or IT operations analytics and security analytics. Further information on ECS can be found in the official [github repository](https://github.com/elastic/ecs) or [Elastic documentation](https://www.elastic.co/guide/en/ecs/current/index.html).

## Projects

 - [Elastic.CommonSchema](https://github.com/elastic/ecs-dotnet/tree/master/src/Elastic.CommonSchema) - foundational project that contains a full C# representation of the ECS schema.
 - [Elastic.CommonSchema.Serilog](https://github.com/elastic/ecs-dotnet/tree/master/src/Elastic.CommonSchema.Serilog) - formats a Serilog event into a JSON representation that adheres to the Elastic Common Schema specification.
 - [Elastic.Apm.SerilogEnricher](https://github.com/elastic/ecs-dotnet/tree/master/src/Elastic.Apm.SerilogEnricher) - adds transaction id and trace id to every Serilog log message that is created during a transaction.

## Copyright and License

This software is Copyright (c) 2014-2019 by Elasticsearch BV.

This is free software, licensed under: [The Apache License Version 2.0](https://github.com/elastic/ecs-dotnet/blob/master/license.txt).
