using InventarioVeagroApi.Messages.Request;
using InventarioVeagroApi.Messages.Response;
using InventarioVeagroApi.Models;

namespace InventarioVeagroApi.Services
{
    public interface IMapperService
    {

        Customer MapToCustomer(CustomerReqDTO customer);
        CustomerRespDTO MapToCustomerResp(Customer customer);
        List<CustomerRespDTO> MapToListCustomer(List<Customer> listCustomers);

        Sale MapToSale(SaleReqDTO saleReqDTO);


        SaleResDTO SaleResDTO(Sale sale);
    }
}
