using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SEP3_Tier1.Data.BookSale
{
    public class SaleService : ISaleService
    {

        private string uri = "https://localhost:5010";
        private readonly HttpClient client;


        public SaleService() {
            client = new HttpClient();
        }


        public async Task<IList<Models.BookSale>> GetBookSaleAsync(string username)
        {
            Task<string> stringAsync = client.GetStringAsync(uri + $"/Sales?username={username}");
            string message = await stringAsync;
            List<Models.BookSale> result = JsonSerializer.Deserialize<List<Models.BookSale>>(message);
            return result;
        }

        public async Task<Models.BookSale> GetSaleAsync() {
            Task<string> stringAsync = client.GetStringAsync(uri + "/Sales");
            string message = await stringAsync;
            Models.BookSale result = JsonSerializer.Deserialize<Models.BookSale>(message);
            return result;
        }

        public async Task CreateBookSaleAsync(Models.BookSale bookSale) {
            string bookSaleAsJson = JsonSerializer.Serialize(bookSale);
            
            HttpContent content = new StringContent(bookSaleAsJson,
                Encoding.UTF8,
                "application/json");
            
            HttpResponseMessage responseMessage = await client.PostAsync(uri + "/Sales", content);

        }

        
        public async Task DeleteBookSaleAsync(int saleId) {
            await client.DeleteAsync($"{uri}/sales/{saleId}");
        }

        public async Task UpdateBookSaleAsync(Models.BookSale bookSale,  string title, string author, string edition, string condition, string subject, string image, double? price, bool hardCopy, string description) {
            bookSale.title = title;
            bookSale.author = author;
            bookSale.edition = edition;
            bookSale.condition = condition;
            bookSale.subject = subject;
            bookSale.image = image;
            bookSale.price = price;
            bookSale.hardCopy = hardCopy;
            bookSale.description = description;
            
            
            string saleAsJson = JsonSerializer.Serialize(bookSale);
            
            HttpContent content = new StringContent(saleAsJson, Encoding.UTF8, "application/json");

            await client.PatchAsync($"{uri}/sales/{bookSale.bookSaleID}", content);
        }
    }
}