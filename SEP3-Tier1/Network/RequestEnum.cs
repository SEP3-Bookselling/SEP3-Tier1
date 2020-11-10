using System.Text.Json.Serialization;

namespace SEP3_Tier1.Network
{
    [Newtonsoft.Json.JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RequestEnum
    {
        recieveProofOfConcept,
        sendProofOfConcept
    }
}