using System.Net;

namespace InventarioVeagroApi.Exceptions
{
    public class NotFoundException : GenericException
    {

        public NotFoundException(string message) : base(message, StatusCodes.Status404NotFound)
        {
        }
      
        public NotFoundException(string message, Exception exception) : base(message, exception){
           
        }
    }
}
