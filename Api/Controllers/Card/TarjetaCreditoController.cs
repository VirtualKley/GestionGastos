using Application.Interfaces.Card;
using Domain.Request.Card;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Card;

public class TarjetaCreditoController(ITarjetaCreditoService tarjetaCreditoService) : BaseController
{
    public readonly ITarjetaCreditoService _tarjetaCreditoService = tarjetaCreditoService;

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> ObtenerCategorias()
    {
        var result = await _tarjetaCreditoService.ConsultarPorUsuarioAsync(GetUsuario());
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> ObtenerPorId(int id)
    {
        var result = await _tarjetaCreditoService.ObtenerPorIdAsync(id, GetUsuario());
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Crear([FromBody] TarjetaCreditoRequest request)
    {
        var result = await _tarjetaCreditoService.CrearAsync(request, GetUsuario());
        return Ok(result);
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> Actualizar(int id, [FromBody] TarjetaCreditoRequest request)
    {
        var result = await _tarjetaCreditoService.ActualizaAsync(id, request, GetUsuario());
        return Ok(result);
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> Eliminar(int id)
    {
        var result = await _tarjetaCreditoService.EliminarAsync(id, GetUsuario());
        return Ok(new { message = "Tarjeta eliminada correctamente" });
    }
}