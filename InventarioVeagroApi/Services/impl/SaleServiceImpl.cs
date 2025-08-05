using InventarioVeagroApi.Exceptions;
using InventarioVeagroApi.Messages.Request;
using InventarioVeagroApi.Messages.Response;
using InventarioVeagroApi.Models;
using InventarioVeagroApi.Util;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace InventarioVeagroApi.Services.impl
{
    public class SaleServiceImpl : ISaleService
    {
        private readonly ILogger<SaleServiceImpl> _logger;
        private readonly ProductContext _productContext;
        private readonly IMapperService _mapperService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SaleServiceImpl(ILogger<SaleServiceImpl> logger,
            ProductContext productContext,
            IMapperService mapperService,
            IHttpContextAccessor httpContextAccessor)
        {

            _logger = logger;
            _productContext = productContext;
            _mapperService = mapperService;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<GenericRespDTO<string>> GenerateSale(GenericReqDTO<SaleReqDTO> reqDTO)
        {

            _logger.LogInformation("saleReqDTO: {}", reqDTO);
            
            Sale saleEntity = _mapperService.MapToSale(reqDTO.payload);

            _logger.LogInformation("Detalles: {}", saleEntity.Details.Count);

            foreach (var detail in saleEntity.Details) {

                var productFound = await _productContext.Products
               .Where(product => product.mainCode == detail.MainCode && ConstantVeagro.STATUS_ACTIVE.Equals(product.recordStatus))
               .FirstOrDefaultAsync();

                if (productFound is null)
                {

                    throw new NotFoundException($"El producto con codigo {detail.MainCode} no existe en la base de datos");
                }

                _logger.LogInformation("Asignando el codigo principal al detalle de la venta.");
                detail.ProductId = productFound.id;
            }

            if (saleEntity.Dni== "9999999999999") {
                saleEntity.IdCustomer = null;
            }

            var user = _httpContextAccessor.HttpContext?.User;
            var userId = user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            _logger.LogInformation("Id usuario session {}", userId);
            if (string.IsNullOrEmpty(userId)) {
                  throw new GenericException("No se encontro el usuario");
            }

            saleEntity.IdUser = int.Parse(userId);

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
