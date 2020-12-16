using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using SEP3_Tier1.Shared;
using SEP3_Tier1.Validation;

namespace SEP3_Tier1.Models
{
    public class BookSale
    {
        [JsonPropertyName("title")]
        [Required(ErrorMessage = "Please enter a title")]
        [MaxLength(256, ErrorMessage = "Book's title is too long, please enter a shorter one")]
        public string title { get; set; }
        
        [JsonPropertyName("author")]
        [Required(ErrorMessage = "Please enter an author")]
        [MaxLength(256, ErrorMessage = "Author's name is too long, please enter a shorter one")]
        public string author { get; set; }
        
        [JsonPropertyName("edition")]
        [Required(ErrorMessage = "Please specify the edition")]
        [MaxLength(50, ErrorMessage = "Edition too long, please enter shorter edition")]
        public string edition { get; set; }
        
        [JsonPropertyName("condition")]
        [Required(ErrorMessage = "Please specify the condition")]
        [MaxLength(10)]
        public string condition { get; set; }
        
        [JsonPropertyName("subject")]
        [Required(ErrorMessage = "Please enter a subject")]
        [MaxLength(50, ErrorMessage = "Subject is too long, please enter a shorter one")]
        public string subject { get; set; }
        
        [JsonPropertyName("image")]
        [Required(ErrorMessage = "Please enter an image")]
        [MaxLength(256, ErrorMessage = "Image is too large, please enter a smaller one")]
        public string image { get; set; }
        
        [JsonPropertyName("price")]
        [Required(ErrorMessage = "Please enter a price")]
        [DoubleValidation]
        public double price { get; set; }
        
        [JsonPropertyName("hardCopy")]
        public bool hardCopy { get; set; }
        
        [JsonPropertyName("description")]
        [MaxLength(256, ErrorMessage = "Description is too long, please enter a shorter one")]
        public string description { get; set; }
        
        [JsonPropertyName("username")]
        public string username { get; set; }
        
        //Create method to autogenerate ID value
        [JsonPropertyName("bookSaleID")]
        public int bookSaleID { get; set; }
        
        [JsonIgnore]
        public bool isEditing { get; set; }
        
      /*  public string ToString()
        {
           // Converts the values into jsonFormat


            return "{"
                   + "\"title\":" + "\"" + title + "\","
                   + "\"author\":" + "\"" + author + "\","
                   + "\"edition\":" + "\"" + edition + "\","
                   + "\"condition\":" + "\"" + condition + "\","
                   + "\"subject\":" + "\"" + subject + "\","
                   + "\"image\":" + "\"" + image + "\","
                   + "\"price\":" + price + ","
                   + "\"hardCopy\":" + hardCopy + ","
                   + "\"description\":" + "\"" + description + "\"" +","
                   + "\"username\":" + "\"" + username + "\"" +","
                   + "\"id\":" + bookSaleID
                   + "}";
        }



        public bool IsNullOrEmpty() {
            if (!(string.IsNullOrEmpty(title) || string.IsNullOrEmpty(author) || string.IsNullOrEmpty(edition) 
                || string.IsNullOrEmpty(condition) || string.IsNullOrEmpty(subject) || string.IsNullOrEmpty(image)
                || price == null)) {
                return true;
            }

            return false;
        }*/
        
    }
    
}

