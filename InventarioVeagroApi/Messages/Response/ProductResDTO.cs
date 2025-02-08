

namespace InventarioVeagroApi.Messages.Response
{
    public class ProductResDTO
    {
        public int id { get; set; }
        public string name { get; set; }

        
        public string mainCode { get; set; }

        public string? auxiliaryCode { get; set; }
        public string description { get; set; }

        
        public decimal price { get; set; }

        
        public decimal amount { get; set; } 
       public decimal measurementUnit { get; set; }
    }
}
