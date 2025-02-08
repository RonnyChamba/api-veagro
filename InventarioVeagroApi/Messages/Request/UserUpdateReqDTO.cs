using System.ComponentModel.DataAnnotations;

namespace InventarioVeagroApi.Messages.Request
{
    public class UserUpdateReqDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
