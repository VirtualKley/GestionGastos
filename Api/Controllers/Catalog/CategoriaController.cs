using Application.Interfaces.Catalog;
using Domain.Request.Catalog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Catalog;

public class CategoriaController(ICategoriaService categoriaService) : BaseController
{
    private readonly ICategoriaService _categoriaService = categoriaService;

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> ObtenerCategorias()
    {
        var result = await _categoriaService.ConsultarPorUsuarioAsync(GetUsuario());
        return Ok(result);
    }

    [HttpGet("cantidad")]
    [Authorize]
    public async Task<IActionResult> ObtenerCantidadCategorias()
    {
        var result = await _categoriaService.ObtenerCantidadCatgoriaAsync(GetUsuario());
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> ObtenerPorId(int id)
    {
        var result = await _categoriaService.ObtenerPorIdAsync(id, GetUsuario());
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Crear([FromBody] CategoriaRequest request)
    {
        var result = await _categoriaService.CrearAsync(request, GetUsuario());
        return Ok(result);
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> Actualizar(int id, [FromBody] CategoriaRequest request)
    {
        var result = await _categoriaService.ActualizaAsync(id, request, GetUsuario());
        return Ok(result);
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> Eliminar(int id)
    {
        var result = await _categoriaService.EliminarAsync(id, GetUsuario());
        return Ok(new { message = "Categoria eliminada correctamente" });
    }


}