using InventarioVeagroApi.Messages.Response;
using InventarioVeagroApi.Models;

namespace InventarioVeagroApi.Services
{
    public interface ICustomerRepoService
    {

        Task ExistsCustomerByDni(string dni);
        Task SaveCustomer(Customer customer);
        Task<List<Customer>> ListCustomer();
        Task<Customer>FindCustomerById(int id);
        Task<Customer> UpdateCustomer(int id);

    }
}
