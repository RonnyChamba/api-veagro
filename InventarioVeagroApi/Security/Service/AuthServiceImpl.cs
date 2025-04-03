using FluentValidation;
using InventarioVeagroApi.Exceptions;
using InventarioVeagroApi.Messages.Request;
using InventarioVeagroApi.Messages.Response;
using InventarioVeagroApi.Models;
using InventarioVeagroApi.Security.Messages;
using InventarioVeagroApi.Util;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace InventarioVeagroApi.Security.Service
{
    public class AuthServiceImpl(ILogger<AuthServiceImpl> logger,
        ProductContext productContext, IValidator<AuthReqDTO> validator,
        IConfiguration _configuration) : IAuthService
    {
        async Task<GenericRespDTO<TokenRespDTO>> IAuthService.AuthLogin(GenericReqDTO<AuthReqDTO> reqDTO)
        {

            logger.LogInformation("Req AuthLogin {}", reqDTO);
            var validationResult =  await validator.ValidateAsync(reqDTO.payload);

            if (!validationResult.IsValid) {

                var errores = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
                throw new GenericException($"El objeto recibido es inválido: {errores}");

            }
            var userAuth = await productContext.Users
                .Where(data => data.Dni.Equals(reqDTO.payload.username))
                .FirstOrDefaultAsync();

            if (userAuth == null || !VerifyPassword(reqDTO.payload.password, userAuth.Password))
            {
                throw new BadCredentialException("Credenciales incorrectas");
            }

            var token = GenerateJwtToken(userAuth);

            var tokenRespDTO = new TokenRespDTO
            {
                token = token,
                username = userAuth.Dni
            };
    

            return GeneralUtil.CreateSuccessResp( tokenRespDTO, "Usuario logeado correctamente");
        }
        // 🔍 Verificar contraseña
        private bool VerifyPassword(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }

        // 🔑 Generar JWT Token
        private string GenerateJwtToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(ClaimTypes.Name, user.Dni),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
        };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(_configuration["Jwt:ExpireMinutes"])),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
