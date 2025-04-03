namespace InventarioVeagroApi.Messages.Request
{
    public class UserUpdateReqDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Address { get; set; }
        public string? Cellphone { get; set; }
    }
}
