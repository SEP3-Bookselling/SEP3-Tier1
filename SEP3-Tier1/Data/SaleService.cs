using System.Collections.Generic;
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
        
        
        
        public async Task<string> GetSaleAsync() {
            Task<string> stringAsync = client.GetStringAsync(uri + "/sales");
            string message = await stringAsync;
            string result = JsonSerializer.Deserialize<string>(message);
            return result;
        }

        public async Task AddSaleAsync(string sale) {
            string saleAsJson = JsonSerializer.Serialize(sale);
            
            HttpContent content = new StringContent(saleAsJson, Encoding.UTF8, "application/json");
            await client.PostAsync(uri + )
        }

        public async Task RemoveSaleAsync(string sale) {
            throw new System.NotImplementedException();
        }

        public async Task UpdateAsync(string sale) {
            throw new System.NotImplementedException();
        }
    }
}