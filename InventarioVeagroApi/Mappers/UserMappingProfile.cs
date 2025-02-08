using AutoMapper;
using InventarioVeagroApi.Messages.Request;
using InventarioVeagroApi.Messages.Response;
using InventarioVeagroApi.Models;

namespace InventarioVeagroApi.Mappers


{
    public class UserMappingProfile: Profile
    {

        public UserMappingProfile() {

            CreateMap<User, UserResDTO>();
            CreateMap<UserReqDTO, User>();
        }
    }
}
