
namespace InventarioVeagroApi.Messages.Response
{
    public record SaleResDTO(
    int Id,
    decimal Total,
    int IdCustomer,
    string Name,
    string? Address,
    string? Cellphone,
    string? Email,
    string Dni,
    string CreateDate,
    List<SaleDetailResDTO> Details
);
}
