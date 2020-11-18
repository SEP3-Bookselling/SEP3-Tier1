using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3_Tier1.Models;
using SEP3_Tier1.Network;

namespace SEP3_Tier1.Data
{
    public class SaleService : ISaleService
    {

        private string uri = "https://localhost:5010";
        private HttpClient client;


        public SaleService() {
            client = new HttpClient();
        }


        public async Task<List<BookSale>> GetAllBookSales()
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "/Data");
            string message = await stringAsync;
            List<BookSale> result = JsonSerializer.Deserialize<List<BookSale>>(message);
            return result;
        }

        public async Task<BookSale> GetSaleAsync() {
            Task<string> stringAsync = client.GetStringAsync(uri + "/data");
            string message = await stringAsync;
            BookSale result = JsonSerializer.Deserialize<BookSale>(message);
            return result;
        }

        public async Task AddSaleAsync(BookSale sale) {
            Console.WriteLine(sale.ToString() + "At addSaleAsync");
            string saleAsJson = JsonSerializer.Serialize(new Request {
                BookSale = sale,
                RequestEnum = EnumRequest.CreateBookSale
            });
            
            HttpContent content = new StringContent(saleAsJson, Encoding.UTF8, "application/json");
            
            await client.PostAsync(uri + "/data", content);

        }

        
        public async Task RemoveSaleAsync(int saleId) {
            await client.DeleteAsync($"{uri}/data/{saleId}");
        }

        public async Task UpdateAsync(BookSale sale) {
            string saleAsJson = JsonSerializer.Serialize(sale);
            
            HttpContent content = new StringContent(saleAsJson, Encoding.UTF8, "application/json");

            await client.PatchAsync($"{uri}/data/{sale}", content);
        }
    }
}