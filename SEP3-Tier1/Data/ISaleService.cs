using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3_Tier1.Models;

namespace SEP3_Tier1.Data
{
    public interface ISaleService
    {
        //Change to correct return types
        Task<List<BookSale>> GetAllBookSales();
        Task<BookSale> GetSaleAsync();
        Task AddSaleAsync(BookSale sale);
        Task RemoveSaleAsync(int saleId);
        Task UpdateAsync(BookSale sale);
    }
}