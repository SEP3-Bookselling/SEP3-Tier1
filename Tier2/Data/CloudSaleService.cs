﻿using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3_Tier1.Models;

namespace SEP3_Tier1.Data
{
    public class CloudSaleService : ISaleService
    {
        
        private string SaleFile = "sales.json";
        private IList<BookSale> _sales;
        private string uri = "https://localhost:5003";
        private HttpClient client;

        public CloudSaleService()
        {
            client = new HttpClient();
        }

        public async Task<IList<string>> GetSaleAsync() {
            Task<string> stringAsync = client.GetStringAsync(uri + "/sales");
            string message = await stringAsync;
            List<string> result = JsonSerializer.Deserialize<List<string>>(message);
            return result;
        }

        public async Task AddSaleAsync(string sale) {
            string saleAsJson = JsonSerializer.Serialize(sale);
            
            HttpContent content = new StringContent(saleAsJson, Encoding.UTF8, "application/json");
            
            await client.PostAsync(uri + "/sales", content);
        }

        
        public async Task RemoveSaleAsync(int saleId) {
            await client.DeleteAsync($"{uri}/sales/{saleId}");
        }

        public async Task UpdateAsync(string sale) {
            string saleAsJson = JsonSerializer.Serialize(sale);
            
            HttpContent content = new StringContent(saleAsJson, Encoding.UTF8, "application/json");

            await client.PatchAsync($"{uri}/sales/{sale}", content);
        }
        
       
    }
}