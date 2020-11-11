using System.Threading.Tasks;

namespace SEP3_Tier1.Data
{
    public interface ISaleService
    {
        //Change to correct return types
        Task<string> GetSaleAsync();
        Task AddSaleAsync(string sale);
        Task RemoveSaleAsync(int saleId);
        Task UpdateAsync(string sale);
    }
}