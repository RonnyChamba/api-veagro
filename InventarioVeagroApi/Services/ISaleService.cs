using InventarioVeagroApi.Messages.Request;
using InventarioVeagroApi.Messages.Response;

namespace InventarioVeagroApi.Services
{
    public interface ISaleService
    {
        Task<GenericRespDTO<string>> GenerateSale(GenericReqDTO<SaleReqDTO> reqDTO);


        Task<GenericRespDTO<List<SaleResDTO>>> ListSales();
    }
}
