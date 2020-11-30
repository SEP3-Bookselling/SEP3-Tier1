﻿using System.Text.Json.Serialization;

namespace SEP3_Tier1.Models.Users
{
    public class Customer : User
    {
        [JsonPropertyName("postcode")]
        public string postcode { get; set;}
        
        [JsonPropertyName("address")]
        public string address { get; set; }
        
        [JsonPropertyName("firstName")]
        public string firstName { get; set; }
        
        [JsonPropertyName("lastName")]
        public string lastName { get; set; }
        
        [JsonPropertyName("email")]
        public string email { get; set; }
        
        [JsonPropertyName("phoneNumber")]
        public int phoneNumber { get; set; }
        
        [JsonPropertyName("rating")]
        public double rating { get; set; }
    }
}