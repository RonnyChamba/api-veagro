using InventarioVeagroApi.Exceptions;
using InventarioVeagroApi.Messages.Request;

namespace InventarioVeagroApi.Services
{
    public interface IValidatorService
    {
        Task ValidatorReqCustomer(CustomerReqDTO customerReq);
    }
}
