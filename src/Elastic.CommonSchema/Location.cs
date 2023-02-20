// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Globalization;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Elastic.CommonSchema
{
	/// <summary>
	///   Represents a Latitude/Longitude as a 2 dimensional point.
	/// </summary>
	public class Location
	{
		/// <summary>
		///   Represents a Latitude/Longitude as a 2 dimensional point.
		/// </summary>
		public Location(double latitude, double longitude)
		{
			Latitude = latitude;
			Longitude = longitude;
		}

		/// <summary>
		///  Latitude
		/// </summary>
		[JsonPropertyName("lat"), DataMember(Name = "lat")]
		public double Latitude { get; }

		/// <summary>
		///  Longitude
		/// </summary>
		[JsonPropertyName("lon"), DataMember(Name = "lon")]
		public double Longitude { get; }

		/// <inheritdoc cref="object.Equals(object)"/>>
		public bool Equals(Location other)
		{
			if (ReferenceEquals(null, other))
				return false;
			if (ReferenceEquals(this, other))
				return true;

			return Latitude.Equals(other.Latitude) && Longitude.Equals(other.Longitude);
		}

		/// <inheritdoc cref="object.ToString"/>>
		public string ToString(string format, IFormatProvider formatProvider) => ToString();

		/// <inheritdoc cref="object.ToString"/>>
		public override string ToString() =>
			Latitude.ToString("#0.0#######", CultureInfo.InvariantCulture) + "," +
			Longitude.ToString("#0.0#######", CultureInfo.InvariantCulture);

		/// <inheritdoc cref="object.Equals(object)"/>>
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
				return false;
			if (ReferenceEquals(this, obj))
				return true;
			if (obj.GetType() != GetType())
				return false;

			return Equals((Location)obj);
		}

		/// <inheritdoc cref="object.GetHashCode"/>>
		public override int GetHashCode() => unchecked((Latitude.GetHashCode() * 397) ^ Longitude.GetHashCode());

		/// <summary> Implicitly convert from a lat, lon string </summary>
		public static implicit operator Location(string latLon)
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
		public static implicit operator Location(double[] lonLat) =>
			lonLat.Length != 2
				? null
				: new Location(lonLat[1], lonLat[0]);
	}
}
