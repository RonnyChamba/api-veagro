using InventarioVeagroApi.Controllers;
using InventarioVeagroApi.Messages.Response;
using InventarioVeagroApi.Models;
using InventarioVeagroApi.Util;
using Microsoft.EntityFrameworkCore;

namespace InventarioVeagroApi.Services.impl
{
    public class DashboardServiceImpl(ILogger<DashboardServiceImpl> logger, ISaleService saleService, ProductContext productContext) : IDashboardService
    {

        private readonly ILogger<DashboardServiceImpl> _logger = logger;
        private readonly ISaleService _saleService = saleService;
        private readonly ProductContext _productContext = productContext;

        public async Task<GenericRespDTO<DashBoardChartRespDTO>> GetInfoDashboard()
        {

            _logger.LogInformation("Obteniendo GetInfoDashboard");
            var currentYear = DateTime.Now.Year;
            var currentMonth = DateTime.Now.Month;


            var mesesConNombres = Enumerable.Range(1, currentMonth)
                .Select(m => new
                {
                    Numero = m,
                    Nombre = new DateTime(currentYear, m, 1).ToString("MMMM")
                })
                .ToList();
            _logger.LogInformation("Numero de meses: {meses}", mesesConNombres);

            var ventasQuery = await _productContext.Sale
                .Where(s => s.CreateDate.Year == currentYear)
                .GroupBy(s => s.CreateDate.Month)
                .Select(g => new
                {
                    Mes = g.Key,
                    Total = g.Sum(s => s.Total)
                }).ToListAsync();

            // Combinar para que siempre estén todos los meses
            var ventasFinal = mesesConNombres.Select(m => new 
            {
               Mes = m.Nombre,
               Total = ventasQuery.FirstOrDefault(v => v.Mes == m.Numero)?.Total ?? 0 
            }
           ).ToList();



            // Ventas por cantidad de productos
            var productosPorMes = await _productContext.SaleDetail
                .Where(sd => sd.Sale.CreateDate.Year == currentYear)
                .GroupBy(sd => sd.Sale.CreateDate.Month)
                .Select(g => new
                {
                    Mes = g.Key,
                    CantidadProductos = g.Sum(sd => sd.Amount)
                })
                .ToListAsync();

            // Rellenar meses que no tienen ventas
            var productosFinal = Enumerable.Range(1, currentMonth)
                .Select(m => new
                {
                    Mes = new DateTime(currentYear, m, 1).ToString("MMMM"),
                    CantidadProductos = productosPorMes.FirstOrDefault(v => v.Mes == m)?.CantidadProductos ?? 0
                })
                .ToList();


            var resp = new DashBoardChartRespDTO(
                mesesConNombres.Select(item=> item.Nombre).ToList(),
                ventasFinal.Select(item=> item.Total).ToList(),
                productosFinal.Select(item => item.CantidadProductos).ToList()
                );
           
            return GeneralUtil.CreateSuccessResp(resp, "Informacion obtenida correctamente");

            
        }
    }
}
