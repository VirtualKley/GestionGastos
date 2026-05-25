using Domain.Entidades.Base;
using Domain.Enumeraciones;

namespace Domain.Entidades.Card;

public class TarjetaCredito : BaseUsuario
{
    public int Id {get; set;}
    public required string NombreBanco {get; set;}
    public required string UltimoCuatroDigitos {get; set;}
    public required string NombreTitular {get; set;}
    public RedPago RedPago {get; set;}
    public required int MesVencimiento {get; set;}
    public required int AnioVencimiento {get; set;}
    public required decimal LimiteCredito {get; set;}
    public required int DiaCorte {get; set;}
    public required string ColorGradiente {get; set;}
}