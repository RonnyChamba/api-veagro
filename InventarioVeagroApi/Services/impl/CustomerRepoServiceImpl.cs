
using InventarioVeagroApi.Exceptions;
using InventarioVeagroApi.Messages.Response;
using InventarioVeagroApi.Models;
using InventarioVeagroApi.Util;
using Microsoft.EntityFrameworkCore;

namespace InventarioVeagroApi.Services.impl
{
    public class CustomerRepoServiceImpl : ICustomerRepoService
    {


        private readonly ProductContext _productContext;

        public CustomerRepoServiceImpl(ProductContext productContext) {

            _productContext = productContext;
            
        }
        async Task ICustomerRepoService.ExistsCustomerByDni(string dni)
        {
            var existCutomer = await _productContext.Customers.AnyAsync(customer => customer.Dni.Equals(dni));

            if (existCutomer)
            {
                throw new GenericException($"El cliente con dni {dni} ya existe");
            }
        }

       async Task<Customer> ICustomerRepoService.FindCustomerById(int id)
        {

            var customer= await _productContext.Customers
                .Where(item => item.Id == id && item.StatusRecord.Equals(ConstantVeagro.STATUS_ACTIVE))
                .FirstOrDefaultAsync();

            if (customer == null)
            {
                throw new NotFoundException($"El cliente con ide {id} no existe");
            }

            return customer;
        }

        async Task<List<Customer>> ICustomerRepoService.ListCustomer()
        {

            var listCustomers = await _productContext.Customers
                .Where(item => item.StatusRecord.Equals(ConstantVeagro.STATUS_ACTIVE))
                .ToListAsync();

            return listCustomers;
            
        }

        async Task ICustomerRepoService.SaveCustomer(Customer customer)
        {
            await _productContext.Customers.AddAsync(customer);
            await _productContext.SaveChangesAsync();
           
        }

       async Task<Customer> ICustomerRepoService.UpdateCustomer(int id)
        {
            throw new NotImplementedException("");
        }
    }
}
