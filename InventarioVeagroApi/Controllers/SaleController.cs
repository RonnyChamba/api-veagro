using InventarioVeagroApi.Exceptions;
using InventarioVeagroApi.Messages.Request;
using InventarioVeagroApi.Messages.Response;
using InventarioVeagroApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventarioVeagroApi.Controllers
{
    [ApiController]
    [Route("ventas")]
    public class SaleController : ControllerBase
    {
        private readonly ILogger<SaleController> _logger;
        private readonly ISaleService _saleService;


        public SaleController(ILogger<SaleController> logger, ISaleService saleService) { 
            
            _logger = logger;
            _saleService = saleService;
        }

        [Authorize]
        [HttpPost]
        [Route("generateSale")]
        public async Task<GenericRespDTO<string>> GenerateSale([FromBody] GenericReqDTO<SaleReqDTO>  reqDTO) {

            ValidReqDto(reqDTO);

            return await _saleService.GenerateSale(reqDTO);
           
        }

        [Authorize]
        [HttpGet]
        [Route("facturas")]
        public async Task<GenericRespDTO<List<SaleResDTO>>> ListSales() {
        
            return await _saleService.ListSales();
        }

        private void ValidReqDto(GenericReqDTO<SaleReqDTO> reqDTO) {

            if (!ModelState.IsValid)
            {

                _logger.LogInformation("El objeto es incorrecto");

                var listErrors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                string mensagesErrores = string.Join(",", listErrors) ?? "Los campos son incorrectos"; ;

                throw new GenericException($"Error de validacion: {mensagesErrores}");
            }
        }
    }
}
