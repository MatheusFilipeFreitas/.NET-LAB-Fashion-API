using System.Text.Json.Serialization;

namespace LAB_Fashion_API.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Seasons
    {
        Winter = 1,
        Autumn = 2,
        Spring = 3,
        Summer = 4,
    }
}
