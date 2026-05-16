using Application.Interfaces.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Auth;

public class UsuarioController(IUsuarioService usuarioService) : BaseController
{
    private readonly IUsuarioService _usuarioService = usuarioService;

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> ObtenerTodos()
    {
        var usuarios = await _usuarioService.ObtenerTodosAsync();
        return Ok(usuarios);
    }

    [HttpPut("{id}/deshabilitar")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Deshabilitar(int id)
    {
        await _usuarioService.DeshabilitarAsync(id);
        return Ok(new { message = $"Usuario {id} deshabilitado correctamente."});
    }
}