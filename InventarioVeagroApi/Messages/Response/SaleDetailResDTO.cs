
namespace InventarioVeagroApi.Messages.Response
{
    public class SaleDetailResDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string MainCode { get; set; }

        public string? AuxiliaryCode { get; set; }

        public string? Description { get; set; }

        
        public decimal Price { get; set; }

      
        public decimal Amount { get; set; }

      
        public decimal Subtotal { get; set; }

       
        public string MeasurementUnit { get; set; }


    }
}
