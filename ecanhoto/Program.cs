
using ecanhoto.Context;
using ecanhoto.Helpers;
using ecanhoto.Model;
using ecanhoto.Services;
using Microsoft.OpenApi.Models;

namespace ecanhoto
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.


            builder.Services.AddControllers();

            builder.Services.AddDbContext<DataContext, DataContext>();
            builder.Services.AddScoped<DataContext>();

            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddHttpContextAccessor();


            // Configuração CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:5173") // frontend
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });

            builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

                
            
            

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(swagger =>
            {
                //This is to generate the Default UI of Swagger Documentation
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API E-Canhotos",
                    Description = "A API do e-Canhoto oferece uma interface robusta e fácil de usar para a gestão digital de canhotos de entrega.\r\n    Com esta API, as empresas podem automatizar a criação, gerenciamento e armazenamento de comprovantes de entrega,\r\n    garantindo maior eficiência e rastreabilidade no processo logístico."
                });
                // To Enable authorization using Swagger (JWT)
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                });
                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowSpecificOrigin");

            app.UseAuthorization();

            // Configure UserHelper with IHttpContextAccessor
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var httpContextAccessor = services.GetRequiredService<IHttpContextAccessor>();
                UserHelper.Configure(httpContextAccessor);
            }

            app.UseMiddleware<JwtMiddleware>();

            app.MapControllers();

            app.Run();
        }
    }
}
