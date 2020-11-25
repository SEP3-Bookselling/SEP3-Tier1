using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using SEP3_Tier1.Models.Users;

namespace SEP3_Tier1.Models
{
    public class BookSale
    {
        [JsonPropertyName("title")]
        [Required(ErrorMessage = "Please enter a title")]
        public string title { get; set; }
        
        [JsonPropertyName("author")]
        [Required(ErrorMessage = "Please enter an author")]
        public string author { get; set; }
        
        [JsonPropertyName("edition")]
        [Required(ErrorMessage = "Please specify the edition")]
        public string edition { get; set; }
        
        [JsonPropertyName("condition")]
        [Required(ErrorMessage = "Please specify the condition")]
        public string condition { get; set; }
        
        [JsonPropertyName("subject")]
        [Required(ErrorMessage = "Please enter a subject")]
        public string subject { get; set; }
        
        [JsonPropertyName("image")]
        [Required(ErrorMessage = "Please enter an image")]
        public string image { get; set; }
        
        [JsonPropertyName("price")]
        [Required(ErrorMessage = "Please enter a price")]
        public double? price { get; set; }
        
        [JsonPropertyName("hardCopy")]
        public bool hardCopy { get; set; }
        
        [JsonPropertyName("description")]
        public string description { get; set; }
        
        [JsonPropertyName("username")]
        public string username { get; set; }
        
        //Create method to autogenerate ID value
        [JsonPropertyName("bookSaleID")]
        public int bookSaleID { get; set; }
        
        
        
        
        public string ToString()
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
        }
        
    }
    
}

