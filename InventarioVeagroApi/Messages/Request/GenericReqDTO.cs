using System.ComponentModel.DataAnnotations;

namespace InventarioVeagroApi.Messages.Request
{
    
    /**
     * Clase generica para los request
     */
    public class GenericReqDTO<T>
    {

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public T payload { set; get;}

        [Required(ErrorMessage = "El campo {0} es obligatorio")]

        public string origin { set; get; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]

        public string usrRequest { set; get; }
        public override string ToString()
        {
            return $"payload {this.payload}, origin: {this.origin}, usrRequest: {this.usrRequest}";
        }
    }
}
