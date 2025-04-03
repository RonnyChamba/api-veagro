using AutoMapper;
using InventarioVeagroApi.Messages.Request;
using InventarioVeagroApi.Messages.Response;
using InventarioVeagroApi.Models;
using InventarioVeagroApi.Util;

namespace InventarioVeagroApi.Services.impl
{
    public class MapperServiceImpl : IMapperService
    {

        private readonly IMapper _mapper;

        public MapperServiceImpl(IMapper mapper)
        { 
            _mapper = mapper;
        }

        public Sale MapToSale(SaleReqDTO saleReqDTO)
        {

            Sale sale = new Sale()
            {
                Total = saleReqDTO.Total,
                IdCustomer = saleReqDTO.Customer.IdCustomer,
                Name = saleReqDTO.Customer.Name,
                Address = saleReqDTO.Customer.Address,
                Cellphone = saleReqDTO.Customer.Cellphone,
                Email = saleReqDTO.Customer.Email,
                Dni = saleReqDTO.Customer.Dni,
                CreateDate = DateTime.Now

            };

            List<SaleDetail> detalles = new List<SaleDetail>();

           foreach(ProductSaleReqDTO product in saleReqDTO.Products)
           {
                SaleDetail saleDetail = _mapper.Map<SaleDetail>(product);

                detalles.Add(saleDetail);
           }


            sale.Details = detalles;
            return sale;
        }

        public SaleResDTO SaleResDTO(Sale sale)
        {

         return _mapper.Map<SaleResDTO>(sale);
        }

        Customer IMapperService.MapToCustomer(CustomerReqDTO customer)
        {

            var customerEntity = _mapper.Map<Customer>(customer);
            customerEntity.StatusRecord = ConstantVeagro.STATUS_ACTIVE;

            return customerEntity;
        }

        CustomerRespDTO IMapperService.MapToCustomerResp(Customer customer)
        {
            return _mapper.Map<CustomerRespDTO>(customer);
        }

        List<CustomerRespDTO> IMapperService.MapToListCustomer(List<Customer> listCustomers)
        {
            return _mapper.Map<List<CustomerRespDTO>>(listCustomers);
        }
    }
}
