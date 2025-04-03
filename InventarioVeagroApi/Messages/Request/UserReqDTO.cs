
namespace InventarioVeagroApi.Messages.Request
{
    public class UserReqDTO
    {

        public string Dni { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RolName { get; set; }
        public string? Address { get; set; }
        public string? Cellphone { get; set; }
    }
}
