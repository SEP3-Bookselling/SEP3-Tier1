using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3_Tier1.Models;

namespace SEP3_Tier1.Data
{
    public interface ISaleService
    {
        //Change to correct return types
        Task<string> GetSaleAsync();
        Task AddSaleAsync(string sale);
        Task RemoveSaleAsync(string sale);
        Task UpdateAsync(string sale);
    }
}