
namespace InventarioVeagroApi.Messages.Response
{
    public class SaleResDTO
    {

        
        public int Id { get; set; }
        public decimal Total { get; set; }
        public int IdCustomer { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public string? Cellphone { get; set; }
        public string? Email { get; set; }
        public string Dni { get; set; }
        public string CreateDate { get; set; }
        public List<SaleDetailResDTO> Details { get; set; } = new List<SaleDetailResDTO>();
    }
}
