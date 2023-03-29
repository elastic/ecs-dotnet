// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

/*
IMPORTANT NOTE
==============
This file has been generated. 
If you wish to submit a PR please modify the original csharp file and submit the PR with that change. Thanks!
*/

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Elastic.CommonSchema;

public partial class Log 
{
	[JsonIgnore]
	internal bool ShouldSerialize =>
		FilePath != null || Logger != null || OriginFileLine != null || OriginFileName != null || OriginFunction != null;
}
public partial class Ecs 
{
	[JsonIgnore]
	internal bool ShouldSerialize =>
		false;
}
