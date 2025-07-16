
namespace InventarioVeagroApi.Messages.Response
{
    public record UserResDTO(
     int Id,
     string Name,
     string Email,
     string Dni,
     string RolName,
     string StatusRecord,
     bool StatusAccount,
     string Address,
     string Cellphone
 );

}
