using InventarioVeagroApi.Messages.Request;
using InventarioVeagroApi.Messages.Response;
using InventarioVeagroApi.Services;
using InventarioVeagroApi.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventarioVeagroApi.Controllers
{

    [ApiController]
    [Route("reportes")]
    public class ReportController: ControllerBase
    {

        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        { 
            _reportService = reportService;
        }

        [Authorize]
        [HttpPost]
        [Route("generar")]
        public async Task<ActionResult>  GenerateReport([FromBody] GenericReqDTO<ReportReqDTO> genericReq) 
        {

            GenericRespDTO<string>  respDTO =  await _reportService.GenerateReport(genericReq);

            byte[] fileBytes = FileUtil.ReadAndDeletePdf(respDTO.data);

            return File(fileBytes, "application/pdf", "archivo.pdf"); // Retornar el PDF con headers adecuados


        }


        [Authorize]
        [HttpGet]
        [Route("generar/{id}")]
        public async Task<ActionResult> GenerateReportSale(int id)
        {

            GenericRespDTO<string> respDTO = await _reportService.GenerateReportSale(id);

            byte[] fileBytes = FileUtil.ReadAndDeletePdf(respDTO.data);

            return File(fileBytes, "application/pdf", "archivo.pdf"); // Retornar el PDF con headers adecuados

        }
    }
}
