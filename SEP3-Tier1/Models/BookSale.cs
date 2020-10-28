namespace SEP3_Tier1.Models
{
    public class BookSale
    {
        public string title { get; set; }
        public string author { get; set; }
        public string edition { get; set; }
        public string condition { get; set; }
        public string subject { get; set; }
        public string image { get; set; }

        public double price { get; set; }
        public bool hardCopy { get; set; }
        
        public User seller { get; set; }
       
        //Create method to autogenerate ID value 
        public int ID { get; }

        
        
        
    }
}