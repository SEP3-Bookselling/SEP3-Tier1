using System.Text.Json.Serialization;

namespace SEP3_Tier1.Network
{
    [Newtonsoft.Json.JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EnumRequest
    {
        //BookSale
        CreateBookSale,
        GetBookSpecificBookSale,
        GetAllBookSales,
        UpdateBookSale,
        DeleteBookSale,
        
        //Users
        CreateUser,
        GetSpecificUser,
        GetAllUsers,
        UpdateUser,
        DeleteUser,
        RateUser,
        
        //Customers
        CreateCustomer,
        GetSpecificCustomer,
        UpdateCustomer,
        DeleteCustomer,
        
        //PurchaseRequest
        CreatePurchaseRequest,
        GetPurchaseRequest,
        DeletePurchaseRequest,
        
        // Prototype
        recieveProofOfConcept,
        sendProofOfConcept
        
    }
}