﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
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


            public async Task<Customer> getSpecificCustomerAsync(string username)
            {
                Task<string> stringString = client.GetStringAsync(uri + "/customers");
                string message = await stringString;
                Customer result = JsonSerializer.Deserialize<Customer>(message);
                
                return result;
            }

            public async Task CreateCustomerAsync(Customer customer)
            {
                string customerJson = JsonSerializer.Serialize(customer);
            
                HttpContent content = new StringContent(customerJson, Encoding.UTF8, "application/json");
        
                HttpResponseMessage responseMessage = await client.PostAsync(uri + "/Customers", content);
                Console.WriteLine();    
                Console.Write(" 2start " + customerJson + " 2end ");

               
            }

            public async Task<IList<Customer>> GetAllCustomersAsync()
            {
                Task<string> stringAsync = client.GetStringAsync(uri + "/customers");
                string message = await stringAsync;
                IList<Customer> result = JsonSerializer.Deserialize<IList<Customer>>(message);
                return result;
            }
            
    }
}