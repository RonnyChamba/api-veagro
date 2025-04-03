using System.ComponentModel.DataAnnotations.Schema;

namespace InventarioVeagroApi.Models
{
    public class Customer
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("nombre")]
        public string Name { get; set; }

        [Column("direccion")]
        public string? Address { get; set; }

        [Column("telefono")]
        public string? Cellphone { get; set; }

        [Column("correo")]
        public string? Email { get; set; }

        [Column("dni")]
        public string Dni { get; set; }

        [Column("status_record")]
        public string StatusRecord { get; set; }
    }
}
