
// paquete que contiene a ControlloerBase, Roter, ApiController
using Microsoft.AspNetCore.Mvc;
using InventarioVeagroApi.Models;
using InventarioVeagroApi.Messages.Request;
using InventarioVeagroApi.Messages.Response;
using InventarioVeagroApi.Util;
using InventarioVeagroApi.Exceptions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
namespace InventarioVeagroApi.Controllers

{
    /**
     * ApiController, este atributo indica que el controlador sigue las convenciones de los controladores de API, que incluyen validaciones automáticas.
     * [FromBody] en los metodos permite lanzar la validaciones
     */
    [ApiController]
    [Route("productos")]
    public class ProductoController : ControllerBase
    {
        private readonly IMapper _mapper; // Inyectamos AutoMapper
        private readonly ProductContext _context;

        // inyeccion de dependencias
        public ProductoController(IMapper mapper, ProductContext context) // Recibimos IMapper en el constructor
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        [Route("listar")]
        public async Task<GenericRespDTO<List<ProductResDTO>>> ListProducts() {

            var productList =await  _context.Products.ToListAsync();
            var productDtoList = _mapper.Map<List<ProductResDTO>>(productList);

            return GeneralUtil.CreateSuccessResp(productDtoList, "Informacion obtenida correctamente");
        }

        [HttpGet]
        [Route("ver/{ide}")]
        public async Task<GenericRespDTO<ProductResDTO>> FindProduct(int ide)
        {

            var productFound = await _context.Products
                .Where(product => product.id == ide && ConstantVeagro.STATUS_ACTIVE.Equals(product.recordStatus))
                .FirstOrDefaultAsync();
                

            if (productFound == null) {

                throw new NotFoundException($"El producto con ide {ide} no existe en la base de datos");
            }
            var productDtoFound = _mapper.Map<ProductResDTO>(productFound);

            return GeneralUtil.CreateSuccessResp(productDtoFound, "Producto encontrado");

        }

        [HttpPost]
        [Route("guardar")]
        public async Task<GenericRespDTO<string>> SaveProduct([FromBody] GenericReqDTO<ProductReqDTO> reqDTO)
        {
         
            if (!ModelState.IsValid)
            {
                var erroresConcatenados = string.Join(", ", ModelState.Values
                                         .SelectMany(v => v.Errors)
                                         .Select(e => e.ErrorMessage));

                throw new GenericException($"El objeto recibido es inválido {erroresConcatenados}" ); // Ahora el middleware la capturará
                
            }

            // Aplicamos el mapeo de ProductReqDTO a Product
            var product = _mapper.Map<Product>(reqDTO.payload);

            // consulta 
            bool exists = await _context.Products
                                        .AnyAsync(item => item.mainCode.Equals(product.mainCode));

            if (exists) {

                throw new GenericException($"Ya existe un producto con el codigo {product.mainCode}.");
            }
            product.recordStatus = ConstantVeagro.STATUS_ACTIVE;
            product.stockAvailable = product.amount;
            product.createDate = new DateTime();


            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();


            return GeneralUtil.CreateSuccessResp("", "Producto registrado correctamente");
        }



        [HttpPut]
        [Route("actualizar")]
        public async Task<GenericRespDTO<int>> UpdateProduct(int ide, [FromBody] GenericReqDTO<ProductUpdateReqDTO> reqDTO)
        {

            if (!ModelState.IsValid)
            {
                var erroresConcatenados = string.Join(", ", ModelState.Values
                                         .SelectMany(v => v.Errors)
                                         .Select(e => e.ErrorMessage));

                throw new GenericException($"El objeto recibido es inválido {erroresConcatenados}"); // Ahora el middleware la capturará

            }


            var dataToUpdate = reqDTO.payload;
            var productFound = await _context.Products
               .Where(product => product.id == ide && ConstantVeagro.STATUS_ACTIVE.Equals(product.recordStatus))
               .FirstOrDefaultAsync();

            if (productFound == null)
            {

                throw new NotFoundException($"El producto con ide {ide} no existe en la base de datos");
            }

            productFound.name =dataToUpdate.name;
            productFound.description =dataToUpdate.description;
            productFound.price =dataToUpdate.price;
            productFound.amount =dataToUpdate.amount;
            productFound.stockAvailable = productFound.stockAvailable;

            await _context.SaveChangesAsync();
            return GeneralUtil.CreateSuccessResp(productFound.id, "Producto eliminado correctamente");

        }

        [HttpDelete]
        [Route("eliminar/{ide}")]
        public async Task<GenericRespDTO<int>> DeleteProduct(int ide)
        {

            var productFound = await _context.Products
               .Where(product => product.id == ide && ConstantVeagro.STATUS_ACTIVE.Equals(product.recordStatus))
               .FirstOrDefaultAsync();

            if (productFound == null)
            {

                throw new NotFoundException($"El producto con ide {ide} no existe en la base de datos");
            }

            productFound.recordStatus = ConstantVeagro.STATUS_DELETE;

            await _context.SaveChangesAsync();
            return GeneralUtil.CreateSuccessResp(productFound.id, "Producto eliminado correctamente");

        }
    }
}
