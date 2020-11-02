using System;

namespace SEP3_Tier1.Models
{
    public class Card
    {
        public int CardNumber { get; set; }
        public int Cvv { get; set; }
        public int ExpirationMonth { get; set; }
        public int ExpirationYear { get; set; }
        public string Type { get; set; }
    }
}