
using FluentValidation;
using InventarioVeagroApi.Filters;
using InventarioVeagroApi.Mappers;
using InventarioVeagroApi.Messages.Request;
using InventarioVeagroApi.Middleware;
using InventarioVeagroApi.Models;
using InventarioVeagroApi.Security.Service;
using InventarioVeagroApi.Services;
using InventarioVeagroApi.Services.impl;
using InventarioVeagroApi.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json;

namespace InventarioVeagroApi.Server

{
    public class Program
    {

        public static void Main(String[]  args) 
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            builder.Services.AddControllers();
                //// agregar propiedades para la serializacion, para mapear el camel case al formato de los dto
                // .AddJsonOptions(options =>
                // {
                //     options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                // }); ;
            builder.Services.AddAutoMapper(
                typeof(ProductMappingProfile),
                typeof(UserMappingProfile),
                typeof(CustomerMappingProfile)
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
            builder.Services.AddValidatorsFromAssemblyContaining<AuthReqDTOValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<CustomerReqDTOValidator>();

            // registrar dependencias en el contenedor de dependencias de .NET

            // Scope: crear una instancia por cada solicitud http
            builder.Services.AddScoped<IUserService, UserServiceImpl>();
            builder.Services.AddScoped<ISaleService, SaleServiceImpl>();
            builder.Services.AddScoped<IAuthService, AuthServiceImpl>();
            builder.Services.AddScoped<ICustomerService, CustomerServiceImpl>();
            builder.Services.AddScoped<IValidatorService, ValidatoServiceImpl>();
            builder.Services.AddScoped<ICustomerRepoService, CustomerRepoServiceImpl>();
            builder.Services.AddScoped<IMapperService, MapperServiceImpl>();
            builder.Services.AddScoped<IReportService, ReportServiceImpl>();
            builder.Services.AddScoped<IPdfService, PdfServiceImpl>();

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


            // configuracion de cors
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyOrigin() // Permite cualquier origen.
                          .AllowAnyMethod() //  Permite cualquier método (GET, POST, etc.).
                          .AllowAnyHeader();  //  Permite cualquier encabezado.
                });
            });


            // Configurar autenticación con JWT
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {

                        ValidateIssuer = false, // No valida el emisor del token
                        ValidateAudience = false, // No valida el destinatario del token
                        ValidateLifetime = true, // Sí valida la expiración del token
                        ValidateIssuerSigningKey = true, // Sí valida la clave de firma

                        // si los valores ValidateIssuer y  ValidateAudience son true, descomentar las lineas de abajo
                        //ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        //ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                    };
                });



            var app = builder.Build();

            app.UseCors(); // Habilita CORS en toda la aplicación

            // Usar el middleware global para manejar excepciones
            app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

            // Habilitar autenticación y autorización en la app
            app.UseAuthentication();
            app.UseAuthorization();


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

