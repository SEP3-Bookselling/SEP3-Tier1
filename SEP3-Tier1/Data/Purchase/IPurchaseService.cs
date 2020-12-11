using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3_Tier1.Models;

namespace SEP3_Tier1.Data.Purchase
{
    public interface IPurchaseService
    {
        Task  CreatePurchaseRequestAsync(IList<PurchaseRequest> purchaseRequest);
        Task<IList<PurchaseRequest>> GetPurchaseRequestAsync(string username);

        Task<IList<PurchaseRequest>> GetPurchaseRequestFromIdAsync(int id);
        Task DeletePurchaseRequestAsync(int id);
        Task DeletePurchaseRequestFromSaleIdAsync(int id);

        

        Task AddToCartAsync(Models.BookSale bookSale);

        Task<IList<Models.BookSale>> GetCartItems();
    }
}