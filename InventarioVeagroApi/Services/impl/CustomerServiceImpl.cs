
using InventarioVeagroApi.Exceptions;
using InventarioVeagroApi.Messages.Request;
using InventarioVeagroApi.Messages.Response;
using InventarioVeagroApi.Models;
using InventarioVeagroApi.Util;
using Microsoft.EntityFrameworkCore;

namespace InventarioVeagroApi.Services.impl
{
    public class CustomerServiceImpl: ICustomerService
    {

        private readonly ILogger<CustomerServiceImpl> _logger;
        private readonly IValidatorService _validatorService;
        private readonly ICustomerRepoService _customerRepoService;
        private readonly IMapperService _mapperService;
        private readonly ProductContext _productContext;

        public CustomerServiceImpl(ILogger<CustomerServiceImpl> logger, IValidatorService validatorService, ICustomerRepoService customerRepoService, IMapperService mapperService, ProductContext productContext)
        {
            _logger = logger;
            _validatorService = validatorService;
            _customerRepoService = customerRepoService;
            _mapperService = mapperService;
            _productContext = productContext;
       
        }
        async Task<GenericRespDTO<string>> ICustomerService.CreateCustomer(GenericReqDTO<CustomerReqDTO> reqDTO)
        {
            _logger.LogInformation("Req CreateCustomer {}", reqDTO);

           await _validatorService.ValidatorReqCustomer(reqDTO.payload);

            await _customerRepoService.ExistsCustomerByDni(reqDTO.payload.Dni);

            var customerEntity = _mapperService.MapToCustomer(reqDTO.payload);

            await _customerRepoService.SaveCustomer(customerEntity);

            return GeneralUtil.CreateSuccessResp("", "Cliente registrado correctamente");
        }

     

        async Task<GenericRespDTO<string>> ICustomerService.DeleteCustomer(int id)
        {

            var customerToDelete = await _productContext
                .Customers
                .Where(item => item.Id == id && ConstantVeagro.STATUS_ACTIVE.Equals(item.StatusRecord))
                .FirstOrDefaultAsync() 
                ?? throw new NotFoundException($"No se encontro el cliente con id {id}");

            customerToDelete.StatusRecord = ConstantVeagro.STATUS_DELETE;

             await _productContext.SaveChangesAsync();

            return GeneralUtil.CreateSuccessResp(customerToDelete.Id.ToString(), "Cliente eliminado correctamente");

        }

        async Task<GenericRespDTO<CustomerRespDTO>> ICustomerService.FindCustomer(int id)
        {

            var customer = await _customerRepoService.FindCustomerById(id);

            var customerResp = _mapperService.MapToCustomerResp(customer);

            return GeneralUtil.CreateSuccessResp(customerResp, "Cliente encontrado correctamente");
        }

       async Task<GenericRespDTO<List<CustomerRespDTO>>> ICustomerService.ListCustomer()
        {

            var listCustomer = await _customerRepoService.ListCustomer();

            var listMapperCustomer = _mapperService.MapToListCustomer(listCustomer);

            return GeneralUtil.CreateSuccessResp(listMapperCustomer, "Informacion obtenida correctamente");
        }

        async Task<GenericRespDTO<string>> ICustomerService.UpdateCustomer(GenericReqDTO<CustomerReqDTO> reqDTO, int ide)
        {

            var customerToUpdate = await _productContext
                .Customers
                .Where(item => item.Id == ide && ConstantVeagro.STATUS_ACTIVE.Equals(item.StatusRecord))
                .FirstOrDefaultAsync() ?? throw new NotFoundException($"El cliente con id {ide} no existe.");


            var dataToUpdate = reqDTO.payload;

            customerToUpdate.Email = dataToUpdate.Email;
            customerToUpdate.Address = dataToUpdate.Address;
            customerToUpdate.Cellphone = dataToUpdate.Cellphone;
            customerToUpdate.Name = dataToUpdate.Name;

            await _productContext.SaveChangesAsync();

            return GeneralUtil.CreateSuccessResp(customerToUpdate.Id.ToString(), "Cliente actualizado correctamente");
        }
    }
}
