
namespace InventarioVeagroApi.Messages.Response
{
    
    public class UserResDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }

        public string Dni { get; set; }
        //public string Password { get; set; }

        public string RolName { get; set; }

        public string StatusRecord { get; set; }

        public bool StatusAccount { get; set; }

        
        public string Address { get; set; }

        public string Cellphone { get; set; }
    }
}
