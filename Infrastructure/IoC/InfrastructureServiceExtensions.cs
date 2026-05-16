using Domain.Repositorios.Base;
using Infrastructure.Data.Contexts;
using Infrastructure.Data.Repositorios.Auth;
using Infrastructure.Data.Seeders;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.IoC;

public static class InfrastructureServiceExtensions
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("PostgreSQL")));

        services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

        return services;
    }

    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        await AdminSeeder.SeedAsync(app.Services);
    }
}