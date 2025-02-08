
using InventarioVeagroApi.Filters;
using InventarioVeagroApi.Mappers;
using InventarioVeagroApi.Middleware;
using InventarioVeagroApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventarioVeagroApi.Server

{
    public class Program
    {

        public static void Main(String[]  args) 
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            builder.Services.AddControllers();
            builder.Services.AddAutoMapper(typeof(ProductMappingProfile));

            // aggrear contexto de coneccion 
            builder.Services.AddDbContext<ProductContext>( o => {

                o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });


            //  // Deshabilitar el manejo automático de validaciones, 
            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                // evite que Asp.Net devuelva automaticamente un 400 cuando el modelo que se recibe en
                // los metodos de los controlladores y manejar los erroes personalmente
                options.SuppressModelStateInvalidFilter = true; // Deshabilitar el manejo automático de validaciones
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Usar el middleware global para manejar excepciones
            app.UseMiddleware<GlobalExceptionHandlerMiddleware>();



            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();

        }



    }

}

