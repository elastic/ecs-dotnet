// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

namespace Elastic.CommonSchema.Serilog.Adapters;

/// <summary>
/// Provides an abstraction that returns the current HTTP related information to be used to enrich <see cref="EcsDocument"/>
/// </summary>
public interface IHttpAdapter
{
	/// <summary> The current <see cref="Client"/> information</summary>
	Client Client { get; }
	/// <summary> The current <see cref="Http"/> information</summary>
	Http Http { get; }
	/// <summary> The current <see cref="Server"/> information</summary>
	Server Server { get; }
	/// <summary> The current <see cref="Url"/> information</summary>
	Url Url { get; }
	/// <summary> The current <see cref="User"/> information</summary>
	User User { get; }
	/// <summary> The current <see cref="UserAgent"/> information</summary>
	UserAgent UserAgent { get; }

	/// <summary>Whether there is a context to infer information from</summary>
	bool HasContext { get; }
}
