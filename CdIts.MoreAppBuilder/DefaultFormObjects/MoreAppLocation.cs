using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace MoreAppBuilder.DefaultFormObjects;

public class MoreAppLocation
{
    [JsonProperty("coordinates")]
    [JsonPropertyName("coordinates")]
    public MoreAppCoordinates? Coordinates { get; set; }

    [JsonProperty("location")]
    [JsonPropertyName("location")]
    public MoreAppLocationInfo? Location { get; set; }

    [JsonProperty("formattedValue")]
    [JsonPropertyName("formattedValue")]
    public string? FormattedValue { get; set; }
}

public class MoreAppLocationInfo
{
    [JsonProperty("road")]
    [JsonPropertyName("road")]
    public string? Road { get; set; }

    [JsonProperty("houseNumber")]
    [JsonPropertyName("houseNumber")]
    public string? HouseNumber { get; set; }

    [JsonProperty("city")]
    [JsonPropertyName("city")]
    public string? City { get; set; }

    [JsonProperty("postcode")]
    [JsonPropertyName("postcode")]
    public string? PostalCode { get; set; }

    [JsonProperty("country")]
    [JsonPropertyName("country")]
    public string? Country { get; set; }
}

public class MoreAppCoordinates
{
    [JsonProperty("latitude")]
    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }

    [JsonProperty("longitude")]
    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }
}