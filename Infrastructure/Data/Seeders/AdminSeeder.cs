using Domain.Entidades.Auth;
using Domain.Enumeraciones;
using Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data.Seeders;

public static class AdminSeeder
{
    public static async Task SeedAsync(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();

        var context = scope.ServiceProvider
            .GetRequiredService<ApplicationDbContext>();

        var logger = scope.ServiceProvider
            .GetRequiredService<ILogger<ApplicationDbContext>>();

        try
        {
            var existeAdmin = await context.Usuarios
                .AnyAsync(u => u.Rol == RolUsuario.Admin);

            if (existeAdmin)
            {
                logger.LogInformation("Admin ya existe - seeder omitido");
                return;
            }

            var admin = new Usuario
            {
                Nombre = "Administrador",
                Email = "kleyner@gmail.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin123", workFactor: 11),
                Rol = RolUsuario.Admin,
                Activo = true,
                FechaCreacion = DateTime.UtcNow
            };

            await context.Usuarios.AddAsync(admin);
            await context.SaveChangesAsync();

            logger.LogInformation("Admin creado exitosamente.");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al ejecuta el seeder de Admin");
            throw;
        }
    }
}