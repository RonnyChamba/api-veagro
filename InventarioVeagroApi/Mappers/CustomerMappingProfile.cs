using AutoMapper;
using InventarioVeagroApi.Messages.Request;
using InventarioVeagroApi.Messages.Response;
using InventarioVeagroApi.Models;
namespace InventarioVeagroApi.Mappers

{
    /**
     * Clase para mapear objetos
     */
    public class CustomerMappingProfile :Profile
    {

        public CustomerMappingProfile() {

            CreateMap<CustomerReqDTO, Customer>();
            CreateMap<Customer, CustomerRespDTO>();
        }
        

    }
}
