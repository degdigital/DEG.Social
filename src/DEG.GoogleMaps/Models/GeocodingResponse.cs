using System.Runtime.Serialization;

namespace DEG.GoogleMaps.Models
{
    [DataContract]
    public class GeocodingResponse
    {
        [DataMember(Name = "status")]
        public string Status { get; set; }

        [DataMember(Name = "results")]
        public GeocodingResult[] Results { get; set; }

        [DataMember(Name = "error_message")]
        public string ErrorMessage { get; set; }

        public override string ToString()
        {
            return string.Format("{0}: {1} results", Status, (Results ?? new GeocodingResult[0]).Length);
        }
    }

    public static class GeocodingStatusCode
    {
        public const string UnknownError = "UNKNOWN_ERROR";
        public const string Ok = "OK";
        public const string NoResults = "ZERO_RESULTS";
        public const string OverQueryLimit = "OVER_QUERY_LIMIT";
        public const string RequestDenied = "REQUEST_DENIED";
        public const string InvalidRequest = "INVALID_REQUEST";
    }

    [DataContract]
    public class GeocodingResult
    {
        [DataMember(Name = "address_components")]
        public GeocodingAddressComponent[] AddressComponents { get; set; }

        [DataMember(Name = "formatted_address")]
        public string FormattedAddress { get; set; }

        [DataMember(Name = "geometry")]
        public GeocodingGeometry Geometry { get; set; }

        [DataMember(Name = "partial_match")]
        public bool PartialMatch { get; set; }

        [DataMember(Name = "types")]
        public string[] Types { get; set; }

        public override string ToString()
        {
            return FormattedAddress;
        }
    }

    [DataContract]
    public class GeocodingGeometry
    {
        [DataMember(Name = "location")]
        public GeocodingGeometryLocation Location { get; set; }

        [DataMember(Name = "location_type")]
        public string LocationType { get; set; }

        public override string ToString()
        {
            return string.Format("{0}: {1}", LocationType, Location ?? new GeocodingGeometryLocation());
        }
    }

    public static class GeocodingGeometryLocationType
    {
        public const string Rooftop = "ROOFTOP";
        public const string RangeInterpolated = "RANGE_INTERPOLATED";
        public const string GeometricCenter = "GEOMETRIC_CENTER";
        public const string Approximate = "APPROXIMATE";
    }

    [DataContract]
    public class GeocodingGeometryLocation
    {
        [DataMember(Name = "lat")]
        public decimal Latitude { get; set; }

        [DataMember(Name = "lng")]
        public decimal Longitude { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, {1}", Latitude, Longitude);
        }
    }

    public class GeocodingGeometryLocationBounds
    {
        public GeocodingGeometryLocation Southwest { get; set; }
        public GeocodingGeometryLocation Northeast { get; set; }

        public override string ToString()
        {
            return string.Format("{0}|{1}", Southwest, Northeast);
        }
    }

    [DataContract]
    public class GeocodingAddressComponent
    {
        [DataMember(Name = "long_name")]
        public string LongName { get; set; }

        [DataMember(Name = "short_name")]
        public string ShortName { get; set; }
        
        [DataMember(Name = "types")]
        public string[] Types { get; set; }

        public override string ToString()
        {
            return string.Format("{0}: {1}", string.Join(", ", Types ?? new string[0]), LongName);
        }
    }

    /// <summary>
    /// Contains constants of possible geocoding types.
    /// NOTE: this list is not exhaustive, and subject to change.
    /// </summary>
    public static class GeocodingTypes
    {
        public const string StreetNumber = "street_number";
        public const string Route = "route";
        public const string Intersection = "intersection";
        public const string ColloquialArea = "colloquial_area";
        public const string Locality = "locality";
        public const string Sublocality = "sublocality";
        public const string SublocalityLevel1 = "sublocality_level_1";
        public const string SublocalityLevel2 = "sublocality_level_2";
        public const string SublocalityLevel3 = "sublocality_level_3";
        public const string SublocalityLevel4 = "sublocality_level_4";
        public const string SublocalityLevel5 = "sublocality_level_5";
        public const string Neighborhood = "neighborhood";
        public const string Political = "political";
        public const string Premise = "premise";
        public const string SubPremise = "subpremise";
        public const string AdminAreaLevel1 = "administrative_area_level_1";
        public const string AdminAreaLevel2 = "administrative_area_level_2";
        public const string AdminAreaLevel3 = "administrative_area_level_3";
        public const string Country = "country";
        public const string PostalCode = "postal_code";
        public const string NaturalFeature = "natural_feature";
        public const string Airport = "airport";
        public const string Park = "park";
        public const string PointOfInterest = "point_of_interest";
        public const string Floor = "floor";
        public const string Establishment = "establishment";
        public const string Parking = "parking";
        public const string PostBox = "post_box";
        public const string PostalTown = "postal_town";
        public const string Room = "room";
        public const string TrainStation = "train_station";

    }
}
