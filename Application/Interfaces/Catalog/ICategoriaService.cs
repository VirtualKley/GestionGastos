using Application.Interfaces.Base;
using Domain.DTOs.Catalog;
using Domain.Request.Catalog;

namespace Application.Interfaces.Catalog;

public interface ICategoriaService : IBaseService<CategoriaDto, CategoriaRequest>
{
}