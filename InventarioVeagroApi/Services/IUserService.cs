using InventarioVeagroApi.Messages.Request;
using InventarioVeagroApi.Messages.Response;

namespace InventarioVeagroApi.Services
{
    public interface IUserService
    {
       public Task<GenericRespDTO<string>> CreateUser(GenericReqDTO<UserReqDTO> reqDTO);
       public Task<GenericRespDTO<List<UserResDTO>>> ListUser();
       public Task<GenericRespDTO<UserResDTO>> FindUser(int ide);
       public Task<GenericRespDTO<string>> DeleteUser(int ide);
       public Task<GenericRespDTO<string>> UpdateUser(GenericReqDTO<UserUpdateReqDTO> reqDTO, int ide);
    }
}
