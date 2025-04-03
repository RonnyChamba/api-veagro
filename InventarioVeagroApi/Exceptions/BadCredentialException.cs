using System.Net;

namespace InventarioVeagroApi.Exceptions
{
    public class BadCredentialException : GenericException
    {

        public BadCredentialException(string message) : base(message, StatusCodes.Status401Unauthorized)
        {
        }
      
        public BadCredentialException(string message, Exception exception) : base(message, exception){
           
        }
    }
}
