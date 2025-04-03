using System.ComponentModel.DataAnnotations.Schema;

namespace InventarioVeagroApi.Messages.Request
{
    public class CustomerReqDTO
    {
        
        public string Name { get; set; }
        public string? Address { get; set; }
        public string? Cellphone { get; set; }
        public string? Email { get; set; }
        public string Dni { get; set; }

        public override string ToString() {

            return $"Name: {Name}, Address:{Address}, Cellphone: {Cellphone}, Email: {Email}, Dni: {Dni}";
        }
    }
}
