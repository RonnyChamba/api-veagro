namespace InventarioVeagroApi.Messages.Response
{
    public class GenericRespDTO<T>
    {
        public string status { get; set; }
        public int code { get; set; }
        public string message { get; set; }

        public T data { get; set; }
    }
}
