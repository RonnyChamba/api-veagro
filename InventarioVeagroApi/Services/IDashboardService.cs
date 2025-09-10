using InventarioVeagroApi.Messages.Request;
using InventarioVeagroApi.Messages.Response;

namespace InventarioVeagroApi.Services
{
    public interface IDashboardService
    {

        Task<GenericRespDTO<DashBoardChartRespDTO>> GetInfoDashboard();

    }
}
