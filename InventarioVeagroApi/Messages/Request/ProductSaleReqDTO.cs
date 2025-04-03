using System.ComponentModel.DataAnnotations;

namespace InventarioVeagroApi.Messages.Request
{
    public class ProductSaleReqDTO
    {

        [Required(ErrorMessage = "El campo name es obligatorio.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo mainCode es obligatorio.")]
        public string MainCode { get; set; }
        public string? AuxiliaryCode { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "El campo price es obligatorio.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "El campo amount es obligatorio.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "El campo measurementUnit es obligatorio.")]
        public string MeasurementUnit { get; set; }

        [Required(ErrorMessage = "El campo Subtotal es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El campo Subtotal debe ser mayor a 0.")]
        public decimal Subtotal { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}; MainCode: {MainCode}; AuxiliaryCode: {AuxiliaryCode}; Description:{Description}; Price: {Price}; Amount: {Amount}; MeasurementUnit: {MeasurementUnit}; Subtotal: {Subtotal} ";
        }
    }
}
