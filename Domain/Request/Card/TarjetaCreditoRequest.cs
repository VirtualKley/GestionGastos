using Domain.Enumeraciones;

namespace Domain.Request.Card;

public class TarjetaCreditoRequest
{
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