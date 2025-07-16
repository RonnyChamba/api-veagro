

namespace InventarioVeagroApi.Messages.Response
{
    public record ProductResDTO(
     int id,
     string name,
     string mainCode,
     string? auxiliaryCode,
     string description,
     decimal price,
     decimal amount,
     string measurementUnit
 );

}
