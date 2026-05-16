using Domain.Enumeraciones;

namespace Domain.DTOs.Auth;

public class UsuarioDto
{
    public int Id {get; set;}
    public string Nombre {get; set;} = string.Empty;
    public string Email {get; set;} = string.Empty;
    public RolUsuario Rol {get; set;}
    public bool Activo {get; set;}
    public DateTime FechaCreacion {get; set;}
}