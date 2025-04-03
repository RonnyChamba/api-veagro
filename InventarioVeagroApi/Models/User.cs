using System.ComponentModel.DataAnnotations.Schema;

namespace InventarioVeagroApi.Models
{
    public class User
    {

        [Column("ide")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("dni")]
        public string Dni { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("rol_name")]
        public string RolName { get; set; }

        [Column("status_record")]
        public string StatusRecord { get; set; }

        [Column("status_account")]
        public bool StatusAccount { get; set; }

        [Column("direccion")]
        public string? Address { get; set; }

        [Column("telefono")]
        public string? Cellphone { get; set; }

    }
}
