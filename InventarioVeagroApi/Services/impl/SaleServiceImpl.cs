using InventarioVeagroApi.Messages.Request;
using InventarioVeagroApi.Messages.Response;
using InventarioVeagroApi.Models;
using InventarioVeagroApi.Util;
using Microsoft.EntityFrameworkCore;

namespace InventarioVeagroApi.Services.impl
{
    public class SaleServiceImpl : ISaleService
    {
        private readonly ILogger<SaleServiceImpl> _logger;
        private readonly ProductContext _productContext;
        private readonly IMapperService _mapperService;

        public SaleServiceImpl(ILogger<SaleServiceImpl> logger,
            ProductContext productContext,
            IMapperService mapperService) {

            _logger = logger;
            _productContext = productContext;
            _mapperService = mapperService;
          
        }
        public async Task<GenericRespDTO<string>> GenerateSale(GenericReqDTO<SaleReqDTO> reqDTO)
        {

            _logger.LogInformation("saleReqDTO: {}", reqDTO);
            
            Sale saleEntity = _mapperService.MapToSale(reqDTO.payload);

            _logger.LogInformation("Detalles: {}", saleEntity.Details.Count);

            await _productContext.Sale.AddAsync(saleEntity);

            await _productContext.SaveChangesAsync();

            return GeneralUtil.CreateSuccessResp("", "Venta generada correctamente");

            
        }

        public async Task<GenericRespDTO<List<SaleResDTO>>> ListSales()
        {

            List<Sale> sales = await _productContext.Sale
                .Include(s=> s.Details)
                .ToListAsync();

            List<SaleResDTO> salesResp = sales.Select(sale => _mapperService.SaleResDTO(sale)).ToList();

            return GeneralUtil.CreateSuccessResp(salesResp, "Facturas obtenidas correctamente");
        }
    }
}
