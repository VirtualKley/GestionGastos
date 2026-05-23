using Domain.Entidades.Auth;
using Domain.Entidades.Base;
using Domain.Enumeraciones;

namespace Domain.Entidades.Catalog;

public class Categoria : BaseUsuario
{
    public int Id {get; set;}

    public required string Nombre {get; set;}
    public required string Icono {get; set;}
    public required string ColorHex {get; set;}
    public required TipoCategoria Tipo {get; set;}
    
}