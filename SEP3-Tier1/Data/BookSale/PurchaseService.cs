﻿using System;
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
            cartItems = new List<BookSale>();
        }

        public async Task CreatePurchaseRequestAsync(IList<PurchaseRequest> purchaseRequests)
        {
            string bookSaleAsJson = JsonSerializer.Serialize(purchaseRequests);
            
            HttpContent content = new StringContent(bookSaleAsJson,
                Encoding.UTF8,
                "application/json");
            
            HttpResponseMessage responseMessage = await client.PostAsync(uri + "/Purchase", content);
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
            
        }

        public async Task<IList<BookSale>> GetCartItems()
        {
            return cartItems;
        }
    }
}