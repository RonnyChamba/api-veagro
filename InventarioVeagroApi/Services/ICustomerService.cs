using InventarioVeagroApi.Messages.Request;
using InventarioVeagroApi.Messages.Response;

namespace InventarioVeagroApi.Services
{
    public interface ICustomerService
    {

        Task<GenericRespDTO<string>> CreateCustomer(GenericReqDTO<CustomerReqDTO> reqDTO);
        Task<GenericRespDTO<List<CustomerRespDTO>>> ListCustomer();
        Task<GenericRespDTO<CustomerRespDTO>> FindCustomer(int id);
        Task<GenericRespDTO<string>> DeleteCustomer(int id);
        Task<GenericRespDTO<string>> UpdateCustomer(GenericReqDTO<CustomerReqDTO> reqDTO, int ide);
    }
}
