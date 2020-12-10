using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3_Tier1.Models;
using SEP3_Tier1.Models.Users;

namespace SEP3_Tier1.Data.Users
{
    
        public class CustomerService : ICustomerService
        {
            private string uri = "https://localhost:5010";
            private HttpClient client;
            private IList<Customer> customers;

            public CustomerService()
            {
                client = new HttpClient();
            }


            public async Task<IList<Customer>> GetCustomerAsync(string username)
            {
                Task<string> stringString = client.GetStringAsync(uri + $"/customer?username={username}");
                string message = await stringString;
                IList<Customer> result = JsonSerializer.Deserialize<IList<Customer>>(message);    
                return result;
            }

            public async Task<double> GetRatingAsync(string username)
            {
                Task<string> stringString = client.GetStringAsync(uri + $"/customer/Rating?username={username}");
                string message = await stringString;
                double result = JsonSerializer.Deserialize<double>(message);    
                return result;
            }


            public async Task CreateCustomerAsync(Customer customer)
            {
                string customerJson = JsonSerializer.Serialize(customer);
                HttpContent content = new StringContent(customerJson, Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = await client.PostAsync(uri + "/customer", content);
            }

            public async Task RateCustomerAsync(Rating rating)
            {
                Console.WriteLine($"Rating service: {rating.username} : {rating.rating} : {rating.otherUsername}");
                string ratingJson = JsonSerializer.Serialize(rating);
                HttpContent content = new StringContent(ratingJson, Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = await client.PostAsync(uri + "/customer/Rating", content);
            }

            public async Task UpdateCustomerAsync(Customer customer, string postcode, string address, string firstName, string lastName, string email, int phoneNumber, double rating, string password)
            {
                customer.postCode = postcode;
                customer.address = address;
                customer.firstName = firstName;
                customer.lastName = lastName;
                customer.email = email;
                customer.phoneNumber = phoneNumber;
                customer.rating = rating;
                customer.password = password;

                string customerAsJson = JsonSerializer.Serialize(customer);
            
                HttpContent content = new StringContent(customerAsJson, Encoding.UTF8, "application/json");

                await client.PatchAsync($"{uri}/customer/{customer.username}", content);
            }

          /*  public async Task<IList<Customer>> GetAllCustomersAsync()
            {
                Task<string> stringAsync = client.GetStringAsync(uri + "/customer");
                string message = await stringAsync;
                IList<Customer> result = JsonSerializer.Deserialize<IList<Customer>>(message);
                return result;
            }
            */


            public async Task DeleteCustomerAsync(string username)
            {
                await client.DeleteAsync($"{uri}/customer/{username}");
            }
            
    }
}