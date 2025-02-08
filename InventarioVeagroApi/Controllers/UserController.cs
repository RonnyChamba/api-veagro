using InventarioVeagroApi.Messages.Request;
using InventarioVeagroApi.Messages.Response;
using InventarioVeagroApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventarioVeagroApi.Controllers
{
    [ApiController]
    [Route("usuarios")]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;

        }

        [HttpPost]
        [Route("guardar")]
        public  async Task<GenericRespDTO<string>> CreateUser( [FromBody] GenericReqDTO<UserReqDTO> reqDTO) {

          return await _userService.CreateUser(reqDTO);
        }

        [HttpGet]
        [Route("listar")]
        public async Task<GenericRespDTO<List<UserResDTO>>> ListUser()
        {

            return await _userService.ListUser();
        }


        [HttpGet]
        [Route("listar/{ide}")]
        public async Task<GenericRespDTO<UserResDTO>> FindUser(int ide)
        {

            return await _userService.FindUser(ide);
        }


        [HttpDelete]
        [Route("eliminar/{ide}")]
        public async Task<GenericRespDTO<string>> DeleteUser(int ide)
        {

            return await _userService.DeleteUser(ide);
        }

        [HttpPut]
        [Route("actualizar/{ide}")]
        public async Task<GenericRespDTO<string>> UpdateUser(GenericReqDTO<UserUpdateReqDTO> reqDTO, int ide)
        {

            return await _userService.UpdateUser(reqDTO, ide);
        }

    }
}
