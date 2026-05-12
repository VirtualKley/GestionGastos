using Domain.Entidades.Auth;
using Domain.Repositorios.Base;

namespace Domain.Repositorios.Base;

public interface IUsuarioRepositorio : IRepositorioBase<Usuario>
{
    Task<Usuario?> ObtenerPorEmailAsync(string email);
    Task<bool> ExisteEmailAsync(string email);
}