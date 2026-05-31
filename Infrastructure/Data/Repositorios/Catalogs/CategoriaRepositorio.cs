using Domain.Entidades.Catalog;
using Domain.Repositorios.Catalog;
using Infrastructure.Data.Contexts;
using Infrastructure.Data.Repositorios.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositorios.Catalogs;

public class CategoriaRepositorio(ApplicationDbContext context) : RepositorioUsuarioBase<Categoria>(context), ICategoriaRepositorio
{
    public async Task<int> ObtenerCantidadCategorias(int usuarioId)
    {
        return await _dbSet.Where(c => c.UsuarioId == usuarioId && c.Activo).CountAsync();
    }
}