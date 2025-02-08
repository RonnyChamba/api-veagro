using System.Net;

namespace InventarioVeagroApi.Exceptions
{
    public class GenericException : Exception
    {


        public int Code { get; } = StatusCodes.Status400BadRequest;
        public GenericException(string message) : base(message){ }
        public GenericException(string message, int Code) : base(message){
            this.Code = Code;
        }
      
        public GenericException(string message, Exception exception) : base(message, exception){}
    }
}
