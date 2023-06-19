using System.ComponentModel;
using System.Text.Json.Serialization;

namespace LAB_Fashion_API.Errors.User
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum UserErrorMessages
    {
        NotFound = 1,
        EmailConflict = 2,
        CpfConflict = 3,
        CnpjConflict = 4,
        CpfOrCnpjRequired = 5,
    }
}
