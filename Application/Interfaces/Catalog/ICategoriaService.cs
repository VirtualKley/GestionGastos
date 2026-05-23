using Domain.DTOs.Catalog;
using Domain.Request.Catalog;

namespace Application.Interfaces.Catalog;

public interface ICategoriaService
{
    Task<IEnumerable<CategoriaDto>> ConsultarPorUsuarioAsync(int usuarioId);
    Task<CategoriaDto> CrearAsync(CategoriaRequest request, int usuarioId);
    Task<CategoriaDto> ActualizaAsync(int id, CategoriaRequest request, int usuarioId);
    Task<CategoriaDto> EliminarAsync(int id, int usuarioId);
    Task<CategoriaDto> ObtenerPorIdAsync(int id, int usuarioId);
}