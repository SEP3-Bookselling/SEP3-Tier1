﻿using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3_Tier1.Models.Users;

namespace SEP3_Tier1.Data.Users
{
    public interface ICustomerService
    {
        Task<Customer> getSpecificCustomerAsync(string username);
        Task <IList<Customer>> GetAllCustomersAsync();
        Task CreateCustomerAsync(Customer customer);
    }
}