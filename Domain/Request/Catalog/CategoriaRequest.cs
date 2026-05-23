using Domain.Enumeraciones;

namespace Domain.Request.Catalog;

public class CategoriaRequest
{
    public required string Nombre {get; set;}
    public required string Icono {get; set;}
    public required string ColorHex {get; set;}
    public required TipoCategoria Tipo {get; set;}
}