using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using SEP3_Tier1.Validation;

namespace SEP3_Tier1.Models
{
    public class Customer : User
    {
        [JsonPropertyName("postCode")]
        [Required]
        [PostCodeValidation]
        public string postCode { get; set;}
        
        [JsonPropertyName("address")]
        [Required]
        [MaxLength(256)]
        public string address { get; set; }
        
        [JsonPropertyName("firstName")]
        [Required]
        [MaxLength(256)]
        public string firstName { get; set; }
        
        [JsonPropertyName("lastName")]
        [Required]
        [MaxLength(256)]
        public string lastName { get; set; }
        
        [JsonPropertyName("email")]
        [Required]
        [MaxLength(256)]
        public string email { get; set; }
        
        [JsonPropertyName("phoneNumber")]
        [Required]
        [PhoneValidation]
        public int phoneNumber { get; set; }
        
        [JsonPropertyName("rating")]
        public double rating { get; set; }

        [JsonIgnore] public bool isEditing { get; set; }

        public override string ToString()
        {
            return username + " " + password + " " + role + " " + postCode + " " + address + " " + firstName + " " + lastName + " " + email + " " + phoneNumber + " " + rating;
        }
    }
}