
using InventarioVeagroApi.Messages.Response;
namespace InventarioVeagroApi.Util
{
    public class GeneralUtil
    {

        /**
         * Metodo contruye un respuesta de exito generica
         */
        public static GenericRespDTO<T> CreateSuccessResp<T>( T data, string message ) {

            var resp = new GenericRespDTO<T>();
            resp.status = ConstantVeagro.STATUS_OK;
            resp.code = ConstantVeagro.CODE_OK;
            resp.data = data;
            resp.message = message == null 
                ? "Proceso ejecutado correctamente" 
                : message;
            return resp;
        }
    }
}
