using System.Text.Json.Serialization;

namespace SEP3_Tier1.Models.Users
{
    public class User
    {
        [JsonPropertyName("postcode")]
        public string postcode { get; set;}
        
        [JsonPropertyName("username")]
        public string username { get; set; }
        
        [JsonPropertyName("password")]
        public string password { get; set; }
        
        [JsonPropertyName("id")]
        public int? Id { get; set; }

    }
}