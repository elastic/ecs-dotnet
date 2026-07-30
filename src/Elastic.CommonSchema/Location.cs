// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Globalization;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Elastic.CommonSchema;

/// <summary> Represents a Latitude/Longitude as a 2-dimensional point.</summary>
public record Location
{
	/// Represents a Latitude/Longitude as a 2-dimensional point.
	public Location() { }

	/// Represents a Latitude/Longitude as a 2-dimensional point.
	public Location(double latitude, double longitude)
	{
		Latitude = latitude;
		Longitude = longitude;
	}

	/// <summary>
	///  Latitude
	/// </summary>
	[JsonPropertyName("lat"), DataMember(Name = "lat")]
	public double Latitude { get; init; }

	/// <summary>
	///  Longitude
	/// </summary>
	[JsonPropertyName("lon"), DataMember(Name = "lon")]
	public double Longitude { get; init; }

	/// <inheritdoc cref="object.ToString"/>>
	public string ToString(string format, IFormatProvider formatProvider) => ToString();

	/// <inheritdoc cref="object.ToString"/>>
	public override string ToString() =>
		Latitude.ToString("#0.0#######", CultureInfo.InvariantCulture) + "," +
		Longitude.ToString("#0.0#######", CultureInfo.InvariantCulture);

	/// <summary> Implicitly convert from a lat, lon string </summary>
	public static Location FromString(string latLon)
	{
		if (string.IsNullOrEmpty(latLon))
			throw new ArgumentNullException(nameof(latLon));

		var parts = latLon.Split(',');
		if (parts.Length != 2) throw new ArgumentException("Invalid format: string must be in the form of lat,lon");
		if (!double.TryParse(parts[0], NumberStyles.Any, CultureInfo.InvariantCulture, out var lat))
			throw new ArgumentException("Invalid latitude value");
		if (!double.TryParse(parts[1], NumberStyles.Any, CultureInfo.InvariantCulture, out var lon))
			throw new ArgumentException("Invalid longitude value");

		return new Location(lat, lon);
	}

	/// <summary> Implicitly convert from a lat, lon array </summary>
	public static Location? FromDoubleArray(double[] lonLat) =>
		lonLat.Length != 2
			? null
			: new Location(lonLat[1], lonLat[0]);
}
