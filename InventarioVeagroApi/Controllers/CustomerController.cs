using InventarioVeagroApi.Messages.Request;
using InventarioVeagroApi.Messages.Response;
using InventarioVeagroApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventarioVeagroApi.Controllers
{
    [ApiController]
    [Route("clientes")]
    public class CustomerController: ControllerBase
    {

        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService) {
            _customerService = customerService;
        }

        [Authorize]
        [HttpPost]
        [Route("guardar")]

        public async  Task<GenericRespDTO<string>> CreateCustomer([FromBody] GenericReqDTO<CustomerReqDTO> reqDTO)
        {
           return await  _customerService.CreateCustomer(reqDTO);

        }
        [Authorize]
        [HttpGet]
        [Route("listar")]
        public async Task<GenericRespDTO<List<CustomerRespDTO>>> FindAll() { 
        
            return await _customerService.ListCustomer();
        }


        [Authorize]
        [HttpGet]
        [Route("ver/{id}")]
        public async Task<GenericRespDTO<CustomerRespDTO>> FinByIde(int id) { 
        
            return await _customerService.FindCustomer(id);
        }

        [Authorize]
        [HttpDelete]
        [Route("eliminar/{id}")]
        public async Task<GenericRespDTO<string>> DeleteById(int id) {

            return await _customerService.DeleteCustomer(id);
        }

        [Authorize]
        [HttpPut]
        [Route("actualizar/{id}")]
        public async Task<GenericRespDTO<string>> UpdateCustomer([FromBody] GenericReqDTO<CustomerReqDTO> reqDTO, int id ) {

            return await _customerService.UpdateCustomer(reqDTO, id);
        }
    }
}
