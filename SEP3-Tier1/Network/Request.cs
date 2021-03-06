﻿using System.Collections.Generic;
using SEP3_Tier1.Models;

namespace SEP3_Tier1.Network
{
    public class Request
    {
        public EnumRequest RequestEnum { get; set; }
        
        public BookSale BookSale { get; set; }
        // public BookSaleNoID BookSaleNoId { get; set; }
        public User User { get; set; }
        public string GetAllBookSales { get; set; }
        public Customer Customer { get; set; }
        public IList<PurchaseRequest> purchaseRequests { get; set; }
    }
}