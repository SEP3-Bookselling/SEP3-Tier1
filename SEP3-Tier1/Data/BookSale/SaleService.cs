using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3_Tier1.Models;
using SEP3_Tier1.Models.BookSale;
using SEP3_Tier1.Network;

namespace SEP3_Tier1.Data
{
    public class SaleService : ISaleService
    {

        private string uri = "https://localhost:5010";
        private readonly HttpClient client;


        public SaleService() {
            client = new HttpClient();
        }


        public async Task<IList<BookSale>> GetAllBookSales()
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "/Sales");
            string message = await stringAsync;
            List<BookSale> result = JsonSerializer.Deserialize<List<BookSale>>(message);
            return result;
        }

        public async Task<BookSale> GetSaleAsync() {
            Task<string> stringAsync = client.GetStringAsync(uri + "/Sales");
            string message = await stringAsync;
            BookSale result = JsonSerializer.Deserialize<BookSale>(message);
            return result;
        }

        public async Task CreateBookSale(BookSale bookSale) {
            Console.WriteLine("I AM IN THE HOLE FATHER");
            string bookSaleAsJson = JsonSerializer.Serialize(bookSale);
            
            HttpContent content = new StringContent(bookSaleAsJson,
                Encoding.UTF8,
                "application/json");
            
            HttpResponseMessage responseMessage = await client.PostAsync(uri + "/Sales", content);
            Console.WriteLine(responseMessage.ToString() + "\t <-- RIGHT EHRE");

        }

        
        public async Task RemoveSaleAsync(int saleId) {
            await client.DeleteAsync($"{uri}/sales/{saleId}");
            Console.WriteLine("Removed");
        }

        public async Task UpdateAsync(BookSale sale) {
            string saleAsJson = JsonSerializer.Serialize(sale);
            
            HttpContent content = new StringContent(saleAsJson, Encoding.UTF8, "application/json");

            await client.PatchAsync($"{uri}/sales/{sale.bookSaleID}", content);
        }
    }
}