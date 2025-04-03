using AutoMapper;
using InventarioVeagroApi.Messages.Request;
using InventarioVeagroApi.Messages.Response;
using InventarioVeagroApi.Models;

namespace InventarioVeagroApi.Mappers
{
    public class SaleMappingProfile : Profile
    {

       public SaleMappingProfile()
        {

            CreateMap<SaleReqDTO, Sale>();
            CreateMap<ProductSaleReqDTO, SaleDetail>();
            CreateMap<Sale, SaleResDTO>()
                 .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => src.CreateDate.ToString("yyyy-MM-dd HH:mm:ss"))); ;
            CreateMap<SaleDetail, SaleDetailResDTO>();
        }
    }
}
