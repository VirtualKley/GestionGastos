using Application.Interfaces.Base;
using Domain.DTOs.Card;
using Domain.DTOs.Transactions;
using Domain.Request.Card;

namespace Application.Interfaces.Card;

public interface ITarjetaCreditoService : IBaseService<TarjetaCreditoDto, TarjetaCreditoRequest>
{
    public Task<IEnumerable<TarjetaPeriodoDto>> ConsultarPeriodosPorTarjetaAsync(int tarjetaId, int usuarioId);
    public Task<IEnumerable<MovimientoDto>> ConsultarMovimientosPorTarjetaAsync(int tarjetaId, int usuarioId);
}