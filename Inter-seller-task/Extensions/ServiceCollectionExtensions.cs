using Inter_seller_task.Data;
using Inter_seller_task.Models.Entities;
using Inter_seller_task.Repositories.Interfaces;
using Inter_seller_task.Repositories.Repository;
using Inter_seller_task.Services.Interfaces;
using Inter_seller_task.Services.Servic;
using Inter_seller_task.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace Inter_seller_task.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {

            //DbContext 
            services.AddDbContext<ApplicationDbContext>(option => 
            option.UseSqlServer(configuration.GetConnectionString("StartConnection")));
            //Jwt

         //   services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

            // Repositories
            services.AddScoped<IUserRepository, UserRepository>();



            // Services
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IJwtService, JwtService>();

            // Password Hashing

            services.AddScoped<PasswordHasher<User>>();

            // AutoMapper

             services.AddAutoMapper(typeof(Program).Assembly);


            //Controllers
            services.AddControllers();

            return services;
        }

    }
}
