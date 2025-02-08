using AutoMapper;
using FluentValidation;
using InventarioVeagroApi.Exceptions;
using InventarioVeagroApi.Messages.Request;
using InventarioVeagroApi.Messages.Response;
using InventarioVeagroApi.Models;
using InventarioVeagroApi.Util;
using Microsoft.EntityFrameworkCore;

namespace InventarioVeagroApi.Services.impl
{
    public class UserServiceImpl : IUserService

    {
        private readonly ProductContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<UserServiceImpl> _logger;
        private readonly IValidator<UserReqDTO> _validator;
        private readonly IValidator<UserUpdateReqDTO> _validatorUpdateUser;
        public UserServiceImpl(ProductContext context, IMapper mapper, ILogger<UserServiceImpl> logger, IValidator<UserReqDTO> validator, IValidator<UserUpdateReqDTO> validatorUpdate) { 
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _validator = validator;
            _validatorUpdateUser = validatorUpdate;

        }

       async  Task<GenericRespDTO<string>> IUserService.CreateUser(GenericReqDTO<UserReqDTO> reqDTO)
        {
            _logger.LogInformation("Req  CreateUser() {}", reqDTO);


            var validationResult = await _validator.ValidateAsync(reqDTO.payload);
            if (!validationResult.IsValid)
            {
                var errores = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
                throw new GenericException($"El objeto recibido es inválido: {errores}");
            }

            // consulta 
            bool exists = await _context.Users
                                        .AnyAsync(item => item.Dni.Equals(reqDTO.payload.Dni));

            if (exists) {

                throw new GenericException($"La identificacion {reqDTO.payload.Dni} ya existe");
            }

            // Aplicamos el mapeo de User
            var user = _mapper.Map<User>(reqDTO.payload);
            user.StatusRecord = ConstantVeagro.STATUS_ACTIVE;
            user.StatusAccount = true;

            await _context.Users.AddAsync(user);

            await _context.SaveChangesAsync();

            return GeneralUtil.CreateSuccessResp("", "Usuario creado correctamente");
        }

       async Task<GenericRespDTO<string>> IUserService.DeleteUser(int ide)
        {

            _logger.LogInformation("Ide usuario {}", ide);
            var userFount = await _context.Users
                .Where(user => user.Id == ide && user.StatusRecord.Equals(ConstantVeagro.STATUS_ACTIVE))
                .FirstOrDefaultAsync();

            if (userFount == null)
            {
                throw new NotFoundException($"No existe el usuario con ide {ide}");
            }

            userFount.StatusRecord = ConstantVeagro.STATUS_DELETE;

            await   _context.SaveChangesAsync();

            return GeneralUtil.CreateSuccessResp("", "Usuario eliminado correctamente");
        }

        async  Task<GenericRespDTO<UserResDTO>> IUserService.FindUser(int ide)
        {

            _logger.LogInformation("Ide usuario {}", ide);
            var userFount =  await _context.Users
                .Where(user => user.Id == ide && user.StatusRecord.Equals(ConstantVeagro.STATUS_ACTIVE))
                .FirstOrDefaultAsync();

            if (userFount == null) 
            { 
                throw new NotFoundException($"No existe el usuario con ide {ide}");
            }

            var userResp = _mapper.Map<UserResDTO>(userFount);
            return GeneralUtil.CreateSuccessResp(userResp, "Usuario encontrado correctamente");
        }

        async Task<GenericRespDTO<List<UserResDTO>>> IUserService.ListUser()
        {
            var listUserEntities = await _context.Users.ToListAsync();

            var productDtoList = _mapper.Map<List<UserResDTO>>(listUserEntities);

            return GeneralUtil.CreateSuccessResp(productDtoList, "Informacion obtenida correctamente");
        }

       async Task<GenericRespDTO<string>> IUserService.UpdateUser(GenericReqDTO<UserUpdateReqDTO> reqDTO, int ide)
        {

            _logger.LogInformation("Ide usuario {}", ide);

            var validationResult = await _validatorUpdateUser.ValidateAsync(reqDTO.payload);
            if (!validationResult.IsValid)
            {
                var errores = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
                throw new GenericException($"El objeto recibido es inválido: {errores}");
            }

            var userFount = await _context.Users
                .Where(user => user.Id == ide && user.StatusRecord.Equals(ConstantVeagro.STATUS_ACTIVE))
                .FirstOrDefaultAsync();

            if (userFount == null)
            {
                throw new NotFoundException($"No existe el usuario con ide {ide}");
            }

            userFount.Email = reqDTO.payload.Email;
            userFount.Name = reqDTO.payload.Name;
            await _context.SaveChangesAsync();

            return GeneralUtil.CreateSuccessResp("", "Usuario actualizado correctamente");
        }
    }
}
