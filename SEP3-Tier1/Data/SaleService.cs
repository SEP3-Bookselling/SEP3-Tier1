﻿using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3_Tier1.Models;

namespace SEP3_Tier1.Data
{
    public class SaleService : ISaleService
    {

        private string uri = "https://localhost:5003";
        private HttpClient client;


        public SaleService() {
            client = new HttpClient();
        }
        
        
        
        public async Task<IList<string>> GetSaleAsync() {
            Task<string> stringAsync = client.GetStringAsync(uri + "/data");
            string message = await stringAsync;
            List<string> result = JsonSerializer.Deserialize<List<string>>(message);
            return result;
        }

        public async Task AddSaleAsync(string sale) {
            string saleAsJson = JsonSerializer.Serialize(sale);
            
            HttpContent content = new StringContent(saleAsJson, Encoding.UTF8, "application/json");
            
            await client.PostAsync(uri + "/data", content);

        }

        
        public async Task RemoveSaleAsync(int saleId) {
            await client.DeleteAsync($"{uri}/data/{saleId}");
        }

        public async Task UpdateAsync(string sale) {
            string saleAsJson = JsonSerializer.Serialize(sale);
            
            HttpContent content = new StringContent(saleAsJson, Encoding.UTF8, "application/json");

            await client.PatchAsync($"{uri}/data/{sale}", content);
        }
    }
}