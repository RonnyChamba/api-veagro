namespace InventarioVeagroApi.Messages.Response
{
    public record DashBoardChartRespDTO(List<string> Labels, List<decimal> VentasTotales, List<decimal> ProductosVendidos);
}
