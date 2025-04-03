namespace InventarioVeagroApi.Messages.Response
{
    public class CustomerRespDTO
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Cellphone { get; set; }
        public string Email { get; set; }
        public string Dni { get; set; }

        public string StatusRecord { get; set; }
    }
}
