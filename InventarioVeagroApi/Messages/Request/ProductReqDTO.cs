
// Import para aplicar validaciones
using System.ComponentModel.DataAnnotations;

namespace InventarioVeagroApi.Messages.Request
{
    public class ProductReqDTO
    {

        public int id { get; set; }
        [MaxLength(100, ErrorMessage ="El campo {0} debe tener maximo {1} caracteres")]

        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        public string name { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string mainCode { get; set; }

        public string? auxiliaryCode { get; set; }
        public string description { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public decimal price { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public decimal amount { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string measurementUnit { get; set; }


        public override string ToString()
        {

            return $"Name: {this.name} , mainCode: {this.mainCode}, auxiliaryCode: {this.auxiliaryCode},  description: {this.description}, price: {this.price} , amount: {this.amount}, measurementUnit: {this.measurementUnit}";
        }
    }
}
