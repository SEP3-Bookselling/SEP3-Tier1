using System.Collections.Generic;
using System.Net.Http;
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
        
        
        
        public Task<IList<BookSale>> GetSaleAsync() {
            Task<string> stringAsync = client.GetStringAsync(uri + "/sales");
        }

        public Task AddSaleAsync() {
            throw new System.NotImplementedException();
        }

        public Task RemoveSaleAsync() {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync() {
            throw new System.NotImplementedException();
        }
    }
}