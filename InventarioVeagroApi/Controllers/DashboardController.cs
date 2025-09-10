using InventarioVeagroApi.Messages.Response;
using InventarioVeagroApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventarioVeagroApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class DashboardController(IDashboardService dashboardService) : ControllerBase
    {

        private readonly IDashboardService _dashboardService = dashboardService;


        [Authorize]
        [HttpGet]
        [Route("info")]
        public async Task<GenericRespDTO<DashBoardChartRespDTO>> GetInfoDashBoard()
        {
            return await _dashboardService.GetInfoDashboard();

        }

    }
}
