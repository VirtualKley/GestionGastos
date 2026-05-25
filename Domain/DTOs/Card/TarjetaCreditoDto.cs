using Domain.Enumeraciones;

namespace Domain.DTOs.Card;

public class TarjetaCreditoDto
{
    public int Id {get; set;}
    public string NombreBanco {get; set;}
    public string UltimoCuatroDigitos {get; set;}
    public string NombreTitular {get; set;}
    public RedPago RedPago {get; set;}
    public int MesVencimiento {get; set;}
    public int AnioVencimiento {get; set;}
    public decimal LimiteCredito {get; set;}
    public int DiaCorte {get; set;}
    public string ColorGradiente {get; set;}
}