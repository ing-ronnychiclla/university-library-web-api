using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DSW1_T2_ChicllaZamoraRonny.Domain.Ports.Out;
using DSW1_T2_ChicllaZamoraRonny.Infrastructure.Data;
using DSW1_T2_ChicllaZamoraRonny.Infrastructure.Repositories;

namespace DSW1_T2_ChicllaZamoraRonny.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(connectionString)); // Recuerda: Paquete Npgsql.EntityFrameworkCore.PostgreSQL

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}