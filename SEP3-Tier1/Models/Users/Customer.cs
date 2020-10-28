using Microsoft.AspNetCore.Components;

namespace SEP3_Tier1.Models
{
    public class Customer : User
    {
        
        public string location { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        private string email { get; set; }
        private int phoneNumber { get; set; }
        private double rating { get; set; }
        
    }
}