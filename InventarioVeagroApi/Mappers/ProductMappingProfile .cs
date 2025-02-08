using AutoMapper;
using InventarioVeagroApi.Messages.Request;
using InventarioVeagroApi.Messages.Response;
using InventarioVeagroApi.Models;
namespace InventarioVeagroApi.Mappers

{
    /**
     * Clase para mapear objetos
     */
    public class ProductMappingProfile :Profile
    {

        public ProductMappingProfile() {

            CreateMap<ProductReqDTO, Product>();
            CreateMap<Product, ProductResDTO>();
        }
        

    }
}
