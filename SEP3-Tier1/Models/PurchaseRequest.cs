using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace SEP3_Tier1.Models
{
    public class PurchaseRequest
    {
        [JsonPropertyName("requestID")] 
        public int requestID { get; set; }
 
        [JsonPropertyName("bookSale")]
        public BookSale bookSale { get; set; }
        
        
        [JsonPropertyName("buyer")]
        public string buyer { get; set; }
        
        [JsonPropertyName("seller")]
        public string seller { get; set; }
        
    }
}