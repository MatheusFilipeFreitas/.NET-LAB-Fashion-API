using System.Text.Json.Serialization;

namespace LAB_Fashion_API.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ModelType
    {
        Bermuda = 1,
        Biquini = 2,
        Bolsa = 3,
        Boné = 4,
        Calça = 5,
        Calçados = 6,
        Camisa = 7,
        Chapéu = 8,
        Saia = 9,
    }
}
