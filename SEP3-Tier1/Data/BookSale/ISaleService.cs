using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3_Tier1.Models;
using SEP3_Tier1.Models.BookSale;

namespace SEP3_Tier1.Data
{
    public interface ISaleService
    {
        //Change to correct return types
        Task<IList<BookSale>> GetAllBookSales();
        Task<BookSale> GetSaleAsync();
        Task CreateBookSale(BookSale bookSale);
        Task RemoveSaleAsync(int saleId);
        Task UpdateAsync(BookSale sale, string title, string author, string edition, string condition, string subject, string image, double? price, bool hardCopy, string description);
    }
}