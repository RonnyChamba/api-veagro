using System.ComponentModel.DataAnnotations;

namespace InventarioVeagroApi.Messages.Request
{
    public class ProductUpdateReqDTO
    {
        public string name { get; set; }

        public string? auxiliaryCode { get; set; }
        public string description { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public decimal price { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public decimal amount { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string measurementUnit { get; set; }

    }
}
