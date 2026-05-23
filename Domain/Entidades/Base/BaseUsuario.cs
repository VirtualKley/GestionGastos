using Domain.Entidades.Auth;

namespace Domain.Entidades.Base;

public abstract class BaseUsuario : BaseEntity
{
    public int UsuarioId {get; set;}
    public Usuario Usuario {get; set;} = null!;
}