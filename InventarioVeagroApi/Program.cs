
using FluentValidation;
using InventarioVeagroApi.Filters;
using InventarioVeagroApi.Mappers;
using InventarioVeagroApi.Messages.Request;
using InventarioVeagroApi.Middleware;
using InventarioVeagroApi.Models;
using InventarioVeagroApi.Services;
using InventarioVeagroApi.Services.impl;
using InventarioVeagroApi.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace InventarioVeagroApi.Server

{
    public class Program
    {

        public static void Main(String[]  args) 
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            builder.Services.AddControllers();
            builder.Services.AddAutoMapper(
                typeof(ProductMappingProfile),
                typeof(UserMappingProfile)
                );


            // aggrear contexto de coneccion 
            builder.Services.AddDbContext<ProductContext>( o => {

                o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            // agregar validadores
            //builder.Services.AddValidatorsFromAssemblyContaining<UserReqDTO>();
            //builder.Services.AddValidatorsFromAssemblyContaining(typeof(GenericReqDTO<>)); // Registrar el validador genérico

            // registrar validador individuales
            //builder.Services.AddValidatorsFromAssemblyContaining<GenericReqDTO>();
            builder.Services.AddValidatorsFromAssemblyContaining<UserReqDTOValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<UserUpdateReqDTOValidator>();

            // registrar dependencias en el contenedor de dependencias de .NET

            // Scope: crear una instancia por cada solicitud http
            builder.Services.AddScoped<IUserService, UserServiceImpl>();

            // Scope singleton: crea un sola instancia
            //builder.Services.AddSingleton<IUserService, UserServiceImpl>();


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


            // Configurar el logging con el nivel deseado
            //builder.Logging.ClearProviders();
            builder.Logging.AddConsole(); // Agregar un proveedor de logs a la consola
            builder.Logging.AddDebug();   // Agregar logs para la ventana de depuración
           // builder.Logging.AddEventSourceLogger(); // Si quieres eventos en el log

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

