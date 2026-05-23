using Domain.Entidades.Catalog;
using Domain.Repositorios.Catalog;
using Infrastructure.Data.Contexts;
using Infrastructure.Data.Repositorios.Base;

namespace Infrastructure.Data.Repositorios.Catalogs;

public class CategoriaRepositorio(ApplicationDbContext context) : RepositorioUsuarioBase<Categoria>(context), ICategoriaRepositorio
{
    
}