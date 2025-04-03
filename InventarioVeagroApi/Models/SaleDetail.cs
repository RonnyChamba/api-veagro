using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventarioVeagroApi.Models
{

    [Table("venta_detalle")]
    public class SaleDetail
    {
        public int Id { get; set; }

        [Column("nombre_producto")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Column("code_principal")]
        [MaxLength(100)]
        public string MainCode { get; set; }

        [Column("code_auxiliar")]
        [MaxLength(100)]
        public string? AuxiliaryCode { get; set; }

        [Column("descripcion")]
        [MaxLength(100)]
        public string? Description { get; set; }

        [Column("precio")]
        public decimal Price { get; set; }

        [Column("cantidad")]
        public decimal Amount { get; set; }

        [Column("subtotal")]
        public decimal Subtotal { get; set; }

        [Column("unidad")]
        [MaxLength(50)]
        public string MeasurementUnit { get; set; }

        [ForeignKey("venta_id")]
        public Sale Sale { get; set; }

    }
}
