using System.ComponentModel.DataAnnotations;

namespace InventarioVeagroApi.Messages.Request
{
    public class SaleReqDTO
    {

        [Required(ErrorMessage = "El campo product es obligatorio")]
        public List<ProductSaleReqDTO> Products { set; get; } = new List<ProductSaleReqDTO>();

        [Required(ErrorMessage ="El campo customer es obligatorio")]
        public CustomerSaleReqDTO Customer { set; get; }


        [Required(ErrorMessage = "El campo total es obligatorio")]
        public decimal Total { set; get; }

        public override string ToString()
        {
            return $"Product: {Products} ; Customer: {Customer}";
        }
    }

}
