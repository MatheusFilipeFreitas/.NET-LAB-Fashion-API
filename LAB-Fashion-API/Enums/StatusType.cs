using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LAB_Fashion_API.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StatusType
    {
        Active = 1,
        Inactive = 2
    }
}
