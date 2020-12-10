using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3_Tier1.Models;

namespace SEP3_Tier1.Data.Purchase
{
    public class PurchaseService : IPurchaseService
    {
        
        private string uri = "https://localhost:5010";
        private readonly HttpClient client;

        public IList<Models.BookSale> cartItems;
        

        public PurchaseService()
        { 
            client = new HttpClient();
            cartItems = new List<Models.BookSale>();
        }

        public async Task CreatePurchaseRequestAsync(IList<PurchaseRequest> purchaseRequests)
        {
            string bookSaleAsJson = JsonSerializer.Serialize(purchaseRequests);
            
            HttpContent content = new StringContent(bookSaleAsJson,
                Encoding.UTF8,
                "application/json");
            
            HttpResponseMessage responseMessage = await client.PostAsync(uri + "/Purchase", content);
        }

        public async Task<IList<PurchaseRequest>> GetPurchaseRequestAsync(string username) {
            Task<string> stringAsync = client.GetStringAsync(uri + $"/Purchase?username={username}");
            string message = await stringAsync;
            List<PurchaseRequest> result = JsonSerializer.Deserialize<List<PurchaseRequest>>(message);
            return result;
        }

        public async Task DeletePurchaseRequestAsync(int id)
        {
            await client.DeleteAsync($"{uri}/purchase/{id}");
        }

        public async Task AddToCartAsync(Models.BookSale bookSale)
        {
            cartItems.Add(bookSale);
            
        }

        public async Task<IList<Models.BookSale>> GetCartItems()
        {
            return cartItems;
        }
    }
}