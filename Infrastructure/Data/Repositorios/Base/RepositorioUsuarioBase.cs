using Domain.Entidades.Base;
using Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositorios.Base;

public class RepositorioUsuarioBase<T> (ApplicationDbContext context) : RepositorioBase<T>(context) where T : BaseUsuario //Extensiones de usuario pero que posee ya los metodos de repositorio base
{
    public async Task<IEnumerable<T>> ConsultarPorUsuarioAsync(int usuarioId)
    {
        return await _dbSet
            .Where(e => e.UsuarioId == usuarioId && e.Activo == true)
            .ToListAsync();
    }
}