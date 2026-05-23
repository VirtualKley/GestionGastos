using Application.Interfaces.Catalog;
using Domain.DTOs.Catalog;
using Domain.Entidades.Catalog;
using Domain.Repositorios.Catalog;
using Domain.Request.Catalog;
using Mapster;

namespace Application.Servicios.Catalog;

public class CategoriaService(ICategoriaRepositorio categoriaRepositorio) : ICategoriaService
{
    private readonly ICategoriaRepositorio _categoriaRepositorio = categoriaRepositorio; 
    public async Task<CategoriaDto> ActualizaAsync(int id, CategoriaRequest request, int usuarioId)
    {
        var categoria = await ObtenerYValidarAsync(id, usuarioId);

        request.Adapt(categoria);
        await _categoriaRepositorio.ActualizarAsync(categoria);
        return categoria.Adapt<CategoriaDto>();
    }

    public async Task<IEnumerable<CategoriaDto>> ConsultarPorUsuarioAsync(int usuarioId)
    {
        var categorias = await _categoriaRepositorio.ConsultarPorUsuarioAsync(usuarioId);
        return categorias.Adapt<IEnumerable<CategoriaDto>>();
    }

    public async Task<CategoriaDto> CrearAsync(CategoriaRequest request, int usuarioId)
    {
        var categoria = request.Adapt<Categoria>();
        categoria.UsuarioId = usuarioId;

        await _categoriaRepositorio.AgregarAsync(categoria);
        return categoria.Adapt<CategoriaDto>();
    }

    public async Task<CategoriaDto> EliminarAsync(int id, int usuarioId)
    {
        var categoria = await ObtenerYValidarAsync(id, usuarioId);
        await _categoriaRepositorio.EliminarAsync(categoria);
        return categoria.Adapt<CategoriaDto>();
    }

    public async Task<CategoriaDto> ObtenerPorIdAsync(int id, int usuarioId)
    {
        var categoria = await ObtenerYValidarAsync(id, usuarioId);
        return categoria.Adapt<CategoriaDto>();

    }

    private async Task<Categoria> ObtenerYValidarAsync(int id, int usuarioId)
    {
        var categoria = await _categoriaRepositorio.ObtenerPorIdAsync(id)
            ?? throw new KeyNotFoundException($"Categoria {id} no encontrada");

        if (categoria.UsuarioId != usuarioId)
            throw new UnauthorizedAccessException("No posee permiso para ver esta categoría");

        return categoria;
    }
}