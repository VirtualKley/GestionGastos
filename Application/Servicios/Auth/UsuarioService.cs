using Application.Interfaces.Auth;
using Domain.DTOs.Auth;
using Domain.Repositorios.Base;
using Mapster;

namespace Application.Servicios.Auth;

public class UsuarioService(IUsuarioRepositorio usuarioRepositorio) : IUsuarioService
{
    public readonly IUsuarioRepositorio _usuarioRepositorio = usuarioRepositorio;

    public async Task<IEnumerable<UsuarioDto>> ObtenerTodosAsync()
    {
        var usuarios = await _usuarioRepositorio.ObtenerTodosAsync();
        return usuarios.Adapt<IEnumerable<UsuarioDto>>();
    }

    public async Task DeshabilitarAsync(int id)
    {
        var usuario = await _usuarioRepositorio.ObtenerPorIdAsync(id)
            ?? throw new KeyNotFoundException($"Usuario con id {id} no encontrado");

        if (!usuario.Activo)
            throw new InvalidOperationException("El usuario ya se encuentra deshabilitado");

        usuario.Activo = false;
        await _usuarioRepositorio.ActualizarAsync(usuario);
    }
}