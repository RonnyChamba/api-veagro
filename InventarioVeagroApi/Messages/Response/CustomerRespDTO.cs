namespace InventarioVeagroApi.Messages.Response
{
    public record CustomerRespDTO(
     int Id,
     string Name,
     string Address,
     string Cellphone,
     string Email,
     string Dni,
     string StatusRecord
    );
}
