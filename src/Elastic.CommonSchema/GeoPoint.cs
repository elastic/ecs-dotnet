using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace Elastic
{
    public class GeoPoint
    {
	    /// <summary>
	    ///     Represents a Latitude/Longitude as a 2 dimensional point.
	    /// </summary>
	    /// <param name="latitude">Value between -90 and 90</param>
	    /// <param name="longitude">Value between -180 and 180</param>
	    /// <exception cref="ArgumentOutOfRangeException">
	    ///     If <paramref name="latitude" /> or <paramref name="longitude" /> are
	    ///     invalid
	    /// </exception>
	    public GeoPoint(double latitude, double longitude)
        {
            if (!IsValidLatitude(latitude))
                throw new ArgumentOutOfRangeException(string.Format(CultureInfo.InvariantCulture,
                    "Invalid latitude '{0}'. Valid values are between -90 and 90", latitude));
            if (!IsValidLongitude(longitude))
                throw new ArgumentOutOfRangeException(string.Format(CultureInfo.InvariantCulture,
                    "Invalid longitude '{0}'. Valid values are between -180 and 180", longitude));

            Latitude = latitude;
            Longitude = longitude;
        }

	    /// <summary>
	    ///     Latitude
	    /// </summary>
	    [DataMember(Name = "lat")]
        public double Latitude { get; }

	    /// <summary>
	    ///     Longitude
	    /// </summary>
	    [DataMember(Name = "lon")]
        public double Longitude { get; }

        public bool Equals(GeoPoint other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;

            return Latitude.Equals(other.Latitude) && Longitude.Equals(other.Longitude);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return ToString();
        }

        /// <summary>
        ///     True if <paramref name="latitude" /> is a valid latitude. Otherwise false.
        /// </summary>
        /// <param name="latitude"></param>
        /// <returns></returns>
        public static bool IsValidLatitude(double latitude)
        {
            return latitude >= -90 && latitude <= 90;
        }

        /// <summary>
        ///     True if <paramref name="longitude" /> is a valid longitude. Otherwise false.
        /// </summary>
        /// <param name="longitude"></param>
        /// <returns></returns>
        public static bool IsValidLongitude(double longitude)
        {
            return longitude >= -180 && longitude <= 180;
        }

        /// <summary>
        ///     Try to create a <see cref="GeoLocation" />.
        ///     Return
        ///     <value>null</value>
        ///     if either <paramref name="latitude" /> or <paramref name="longitude" /> are invalid.
        /// </summary>
        /// <param name="latitude">Value between -90 and 90</param>
        /// <param name="longitude">Value between -180 and 180</param>
        /// <returns></returns>
        public static GeoPoint TryCreate(double latitude, double longitude)
        {
            if (IsValidLatitude(latitude) && IsValidLongitude(longitude))
                return new GeoPoint(latitude, longitude);

            return null;
        }

        public override string ToString()
        {
            return Latitude.ToString("#0.0#######", CultureInfo.InvariantCulture) + "," +
                   Longitude.ToString("#0.0#######", CultureInfo.InvariantCulture);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != GetType())
                return false;

            return Equals((GeoPoint) obj);
        }

        public override int GetHashCode()
        {
            return unchecked((Latitude.GetHashCode() * 397) ^ Longitude.GetHashCode());
        }

        public static implicit operator GeoPoint(string latLon)
        {
            if (string.IsNullOrEmpty(latLon))
                throw new ArgumentNullException(nameof(latLon));

            var parts = latLon.Split(',');
            if (parts.Length != 2) throw new ArgumentException("Invalid format: string must be in the form of lat,lon");
            if (!double.TryParse(parts[0], NumberStyles.Any, CultureInfo.InvariantCulture, out var lat))
                throw new ArgumentException("Invalid latitude value");
            if (!double.TryParse(parts[1], NumberStyles.Any, CultureInfo.InvariantCulture, out var lon))
                throw new ArgumentException("Invalid longitude value");

            return new GeoPoint(lat, lon);
        }

        public static implicit operator GeoPoint(double[] lonLat)
        {
            return lonLat.Length != 2
                ? null
                : new GeoPoint(lonLat[1], lonLat[0]);
        }
    }
}