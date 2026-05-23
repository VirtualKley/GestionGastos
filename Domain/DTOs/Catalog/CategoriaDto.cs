using Domain.Enumeraciones;

namespace Domain.DTOs.Catalog;

public class CategoriaDto
{
    public int Id {get; set;}
    public string Nombre {get; set;} = string.Empty;
    public string Icono {get; set;} = string.Empty;
    public string ColorHex {get; set;} = string.Empty;
    public TipoCategoria Tipo {get; set;}
}