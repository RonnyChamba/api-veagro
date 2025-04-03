namespace InventarioVeagroApi.Security.Messages
{
    public class AuthReqDTO
    {
        public string username { get; set; }

        public string password { get; set; }


        public override string ToString()
        {
            return $"username: {username}, password: {password}";
        }
    }
}
