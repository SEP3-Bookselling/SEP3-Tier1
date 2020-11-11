﻿using System.Text.Json.Serialization;
using SEP3_Tier1.Models.Users;

namespace SEP3_Tier1.Models
{
    public class BookSale
    {
        [JsonPropertyName("title")]
        public string title { get; set; }
        
        [JsonPropertyName("author")]
        public string author { get; set; }
        
        [JsonPropertyName("edition")]
        public string edition { get; set; }
        
        [JsonPropertyName("condition")]
        public string condition { get; set; }
        
        [JsonPropertyName("subject")]
        public string subject { get; set; }
        
        [JsonPropertyName("image")]
        public string image { get; set; }
        
        [JsonPropertyName("price")]
        public double price { get; set; }
        
        [JsonPropertyName("hardCopy")]
        public bool hardCopy { get; set; }
        
        [JsonPropertyName("seller")]
        public User seller { get; set; }
        
        //Create method to autogenerate ID value
        [JsonPropertyName("id")]
        public int ID { get; }
        
        
        
    }
}