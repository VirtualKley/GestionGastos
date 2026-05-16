using Domain.DTOs.Auth;

namespace Application.Interfaces.Auth;

public interface IUsuarioService
{
    Task<IEnumerable<UsuarioDto>> ObtenerTodosAsync();
    Task DeshabilitarAsync(int id);
}