using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventarioVeagroApi.Models
{
    [Table("venta")]
    public class Sale
    {

        [Column("id")]
        public int Id { get; set; }

        [Column("total")]
        public decimal Total { get; set; }

        [Column("ide_cliente")]
        public int IdCustomer { get; set; }

        [Column("nombre")]
        [MaxLength(200)]
        public string Name { get; set; }

        [Column("direccion")]
        [MaxLength(250)]
        public string? Address { get; set; }

        [Column("telefono")]
        [MaxLength(15)]
        public string? Cellphone { get; set; }

        [Column("correo")]
        [MaxLength(50)]
        public string? Email { get; set; }

        [Column("dni")]
        [MaxLength(15)]
        public string Dni { get; set; }

        [Column("fecha_creacion")]
        public DateTime CreateDate { get; set; }

        public List<SaleDetail> Details { get; set; } = new List<SaleDetail>();
    }
}
