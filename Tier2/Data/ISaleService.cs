using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3_Tier1.Models;

namespace SEP3_Tier1.Data
{
    public interface ISaleService
    {
        Task<IList<BookSale>> GetSaleAsync();
        Task AddSaleAsync(string sale);
        Task RemoveSaleAsync(int saleId);
        Task UpdateAsync(string sale);
    }
}