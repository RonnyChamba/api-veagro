using InventarioVeagroApi.Messages.Request;
using InventarioVeagroApi.Messages.Response;

namespace InventarioVeagroApi.Services
{
    public interface IReportService
    {

         Task<GenericRespDTO<string>> GenerateReport(GenericReqDTO<ReportReqDTO> genericReqDTO);
         Task<GenericRespDTO<string>> GenerateReportSale(int saleId);
    }
}
