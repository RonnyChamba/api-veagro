using InventarioVeagroApi.Messages.Request;
using InventarioVeagroApi.Messages.Response;
using InventarioVeagroApi.Security.Messages;

namespace InventarioVeagroApi.Security.Service
{
    public interface IAuthService
    {
        Task<GenericRespDTO<TokenRespDTO>> AuthLogin(GenericReqDTO<AuthReqDTO> reqDTO);
    }
}
