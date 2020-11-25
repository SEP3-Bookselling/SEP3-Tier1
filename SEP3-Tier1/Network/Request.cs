using SEP3_Tier1.Models;
using SEP3_Tier1.Models.Users;

namespace SEP3_Tier1.Network
{
    public class Request
    {
        public EnumRequest RequestEnum { get; set; }
        
        public BookSale BookSale { get; set; }
        public BookSaleNoID BookSaleNoId { get; set; }
        public User User { get; set; }
        public Card Card { get; set; }
        public string GetAllBookSales { get; set; }

        // Prototype
        public string HelloWorld { get; set; }
        public Customer Customer { get; set; }
    }
}