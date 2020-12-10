using System.Text.Json.Serialization;

namespace SEP3_Tier1.Models.Users
{
    public class User
    {
        
        [JsonPropertyName("username")]
        public string username { get; set; }
        
        [JsonPropertyName("password")]
        public string password { get; set; }
       
        [JsonPropertyName("role")]
        public string role { get; set; }
        
        [JsonIgnore] public bool isEditing { get; set; }

    }
}