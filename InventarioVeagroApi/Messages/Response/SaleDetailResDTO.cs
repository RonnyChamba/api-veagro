
namespace InventarioVeagroApi.Messages.Response
{
    public record SaleDetailResDTO(
     int Id,
     string Name,
     string MainCode,
     string? AuxiliaryCode,
     string? Description,
     decimal Price,
     decimal Amount,
     decimal Subtotal,
     string MeasurementUnit
 );
}
