using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3_Tier1.Models;

namespace SEP3_Tier1.Data
{
    public interface IPurchaseService
    {
        Task  CreatePurchaseRequestAsync(IList<PurchaseRequest> purchaseRequest);
        Task<IList<PurchaseRequest>> GetPurchaseRequestAsync(string username);
        Task DeletePurchaseRequestAsync(int id);

        Task AddToCartAsync(BookSale bookSale);

        Task<IList<BookSale>> GetCartItems();
    }
}