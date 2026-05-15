using Domain.Enumeraciones;

namespace Domain.Entidades.Auth;

public class Usuario
{
    public int Id {get; set;}
    public string Nombre {get; set;} = string.Empty;
    public string Email {get; set;} = string.Empty;
    public string PasswordHash {get; set;} = string.Empty;
    public RolUsuario Rol {get; set;} = RolUsuario.User;
    public bool Activo {get; set;} = true;
    public DateTime FechaCreacion {get; set;} = DateTime.UtcNow;
}