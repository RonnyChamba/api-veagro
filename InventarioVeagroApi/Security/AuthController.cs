using InventarioVeagroApi.Messages.Request;
using InventarioVeagroApi.Messages.Response;
using InventarioVeagroApi.Security.Messages;
using InventarioVeagroApi.Security.Service;
using InventarioVeagroApi.Util;
using Microsoft.AspNetCore.Mvc;

namespace InventarioVeagroApi.Security
{

    [ApiController]
    [Route("auth")]
    public class AuthController: ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService) {
        
            _authService = authService;
        }


        [HttpPost]
        [Route("login")]
       async  public  Task<GenericRespDTO<TokenRespDTO>> Auth([FromBody] GenericReqDTO<AuthReqDTO> reqDTO) {
            return await _authService.AuthLogin(reqDTO);
        }
    }
}
