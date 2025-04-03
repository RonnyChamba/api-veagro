using System.ComponentModel.DataAnnotations;

namespace InventarioVeagroApi.Messages.Request
{
    public class CustomerSaleReqDTO
    {


        [Required(ErrorMessage = "El idCustomer es obligatorio")]
        public int IdCustomer { get; set; }

        [Required(ErrorMessage = "El dni es obligatorio")]
        public string Dni { get; set; }

        [Required(ErrorMessage = "El name es obligatorio")]
        public string Name { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Cellphone { get; set; }

        public override string ToString()
        {
            return $"Dni: {Dni}; Name: {Name}; Email: {Email}; Address: {Address}; CellPhone: {Cellphone}";
        }
    }
}
