using System.Collections.Generic;
using System.Threading.Tasks;

namespace SEP3_Tier1.Data.BookSale
{
    public interface ISaleService
    {
        //Change to correct return types
        Task<IList<Models.BookSale>> GetBookSaleAsync(string username);
       // Task<Models.BookSale> GetSaleAsync();
        Task CreateBookSaleAsync(Models.BookSale bookSale);
        Task DeleteBookSaleAsync(int saleId);
        Task UpdateBookSaleAsync(Models.BookSale bookSale, string title, string author, string edition, string condition, string subject, string image, double price, bool hardCopy, string description);
    }
}