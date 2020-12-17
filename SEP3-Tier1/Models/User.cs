using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SEP3_Tier1.Models
{
    public class User
    {
        
        [JsonPropertyName("username")]
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Special characters are not allowed")]
        [MaxLength(256, ErrorMessage = "Username is too long, please enter a shorter one")]
        public string username { get; set; }
        
        [JsonPropertyName("password")]
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Special characters are not allowed")]
        [MaxLength(256, ErrorMessage = "Password is too long, please enter a shorter one")]
        public string password { get; set; }
       
        [JsonPropertyName("role")]
        public string role { get; set; }
        
        [JsonIgnore] public bool isEditing { get; set; }

    }
}