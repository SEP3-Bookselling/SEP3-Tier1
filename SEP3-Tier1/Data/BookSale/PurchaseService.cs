using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3_Tier1.Models;
using Syncfusion.Blazor.PivotView;

namespace SEP3_Tier1.Data
{
    public class PurchaseService : IPurchaseService
    {
        
        private string uri = "https://localhost:5010";
        private readonly HttpClient client;

        public IList<BookSale> cartItems;
        

        public PurchaseService()
        {
            client = new HttpClient();
        }

        public async Task CreatePurchaseRequestAsync(PurchaseRequest purchaseRequest)
        {
            string bookSaleAsJson = JsonSerializer.Serialize(purchaseRequest);
            
            HttpContent content = new StringContent(bookSaleAsJson,
                Encoding.UTF8,
                "application/json");
            
            HttpResponseMessage responseMessage = await client.PostAsync(uri + "/PurchaseRequest", content);
        }

        public async Task<IList<PurchaseRequest>> GetPurchaseRequestAsync(string username)
        {
            throw new System.NotImplementedException();
        }

        public async Task DeletePurchaseRequestAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task AddToCartAsync(BookSale bookSale)
        {
            cartItems.Add(bookSale);
            Console.WriteLine(cartItems[0]);
            
        }

        public async Task<IList<BookSale>> GetCartItems()
        {
            return cartItems;
        }
    }
}