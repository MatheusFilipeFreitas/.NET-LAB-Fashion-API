using System.Text.Json.Serialization;

namespace LAB_Fashion_API.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum LayoutType
    {
        Bordado = 1,
        Estampa = 2,
        Liso = 3,
    }
}
