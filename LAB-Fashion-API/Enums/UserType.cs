using System.Text.Json.Serialization;

namespace LAB_Fashion_API.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum UserType
    {
        Administrator = 1,
        Manager = 2,
        Creator = 3,
        Other = 4
    }
}
