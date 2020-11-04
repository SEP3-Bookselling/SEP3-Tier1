using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3_Tier1.Models;

namespace SEP3_Tier1.Data
{
    public interface ISaleService
    {
        Task<IList<BookSale>> GetSaleAsync();
        Task AddSaleAsync();
        Task RemoveSaleAsync();
        Task UpdateAsync();
    }
}