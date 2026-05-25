namespace Application.Interfaces.Base;

public interface IBaseService<Dto, Req>
{
    Task<IEnumerable<Dto>> ConsultarPorUsuarioAsync(int usuarioId);
    Task<Dto> CrearAsync(Req request, int usuarioId);
    Task<Dto> ActualizaAsync(int id, Req request, int usuarioId);
    Task<Dto> EliminarAsync(int id, int usuarioId);
    Task<Dto> ObtenerPorIdAsync(int id, int usuarioId);
}