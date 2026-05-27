using Domain.Enumeraciones;

namespace Domain.DTOs.Card;

public class TarjetaCreditoDto
{
    public int Id {get; set;}
    public string NombreBanco {get; set;} = string.Empty;
    public string UltimoCuatroDigitos {get; set;} = string.Empty;
    public string NombreTitular {get; set;} = string.Empty;
    public RedPago RedPago {get; set;}
    public int MesVencimiento {get; set;}
    public int AnioVencimiento {get; set;}
    public decimal LimiteCredito {get; set;}
    public int DiaCorte {get; set;}
    public string ColorGradiente {get; set;} = string.Empty;
    public bool Activo { get; set; }
    public DateTime CreadoEn {get; set;}

    public decimal SaldoUtilizado {get; set;}
    public decimal SaldoDisponible {get; set;}
    public decimal PagoMinimoActual {get; set;}
    public decimal PagoTotalActual {get; set;}
    public decimal FechaCorteActual {get; set;}
}