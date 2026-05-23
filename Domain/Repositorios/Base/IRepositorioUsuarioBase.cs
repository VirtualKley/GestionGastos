using Domain.Entidades.Base;

namespace Domain.Repositorios.Base;

public interface IRepositorioUsuarioBase<T> : IRepositorioBase<T> where T : BaseUsuario
{
    Task<IEnumerable<T>> ConsultarPorUsuarioAsync(int usuarioId);
}