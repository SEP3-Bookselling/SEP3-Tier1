using System.Text.Json.Serialization;
using Newtonsoft.Json;
using SEP3_Tier1.Models.Users;

namespace SEP3_Tier1.Models
{
    public class PurchaseRequest
    {
        [JsonPropertyName("requestID")] 
        public int? requestID { get; set; } = null;
 
        [JsonPropertyName("bookSale")]
        public int bookSaleId { get; set; }
        
        
        [JsonPropertyName("buyer")]
        public string buyer { get; set; }
        
        [JsonPropertyName("seller")]
        public string seller { get; set; }
        
    }
}