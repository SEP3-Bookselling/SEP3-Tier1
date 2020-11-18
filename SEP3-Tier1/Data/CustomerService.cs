using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SEP3_Tier1.Models.Users;
using SEP3_Tier1.Network;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace SEP3_Tier1.Data
{
    public class CustomerService : ICustomerService
    {
        private string uri = "https://localhost:5010";
        private HttpClient client;

        public CustomerService()
        {
            client = new HttpClient();
        }
        
        public async Task AddCustomerAsyncTask(Customer customer)
        {
            string customerJson = JsonSerializer.Serialize(new Request
                {
                    Customer = customer,
                    RequestEnum = EnumRequest.CreateUser
                }
            );
            
            HttpContent content = new StringContent(customerJson, Encoding.UTF8, "application/json");
            await client.PostAsync(uri + "/users", content);
        }

        public Task<Customer> GetCustomerAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}