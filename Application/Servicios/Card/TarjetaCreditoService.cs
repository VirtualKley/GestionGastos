using Application.Interfaces.Card;
using Domain.DTOs.Card;
using Domain.DTOs.Transactions;
using Domain.Entidades.Card;
using Domain.Repositorios.Card;
using Domain.Request.Card;
using Mapster;

namespace Application.Servicios.Card;

public class TarjetaCreditoService(ITarjetaCreditoRepositorio tarjetaCreditoRepositorio) : ITarjetaCreditoService
{
    public readonly ITarjetaCreditoRepositorio _tarjetaCreditoRepositorio = tarjetaCreditoRepositorio;
    public async Task<TarjetaCreditoDto> ActualizaAsync(int id, TarjetaCreditoRequest request, int usuarioId)
    {
        var tarjeta = await ObtenerYValidarAsync(id, usuarioId);

        request.Adapt(tarjeta);
        await _tarjetaCreditoRepositorio.ActualizarAsync(tarjeta);
        return tarjeta.Adapt<TarjetaCreditoDto>();
    }

    public Task<IEnumerable<MovimientoDto>> ConsultarMovimientosPorTarjetaAsync(int tarjetaId, int usuarioId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TarjetaPeriodoDto>> ConsultarPeriodosPorTarjetaAsync(int tarjetaId, int usuarioId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<TarjetaCreditoDto>> ConsultarPorUsuarioAsync(int usuarioId)
    {
        var tarjetas = await _tarjetaCreditoRepositorio.ConsultarPorUsuarioAsync(usuarioId);
        return tarjetas.Adapt<IEnumerable<TarjetaCreditoDto>>();
    }

    public async Task<TarjetaCreditoDto> CrearAsync(TarjetaCreditoRequest request, int usuarioId)
    {
        var tarjeta = request.Adapt<TarjetaCredito>();
        tarjeta.UsuarioId = usuarioId;

        await _tarjetaCreditoRepositorio.AgregarAsync(tarjeta);
        return tarjeta.Adapt<TarjetaCreditoDto>();

    }

    public async Task<TarjetaCreditoDto> EliminarAsync(int id, int usuarioId)
    {
        var tarjeta = await ObtenerYValidarAsync(id, usuarioId);
        await _tarjetaCreditoRepositorio.EliminarAsync(tarjeta);
        return tarjeta.Adapt<TarjetaCreditoDto>();
    }

    public async Task<TarjetaCreditoDto> ObtenerPorIdAsync(int id, int usuarioId)
    {
        var tarjeta = await ObtenerYValidarAsync(id, usuarioId);
        return tarjeta.Adapt<TarjetaCreditoDto>();
    }

    private async Task<TarjetaCredito> ObtenerYValidarAsync(int id, int usuarioId)
    {
        var tarjeta = await _tarjetaCreditoRepositorio.ObtenerPorIdAsync(id)
            ?? throw new KeyNotFoundException($"Tarjeta {id} no encontrada");

        if (tarjeta.UsuarioId != usuarioId)
            throw new UnauthorizedAccessException($"No posee permiso para ver la tarjeta");

        return tarjeta;
    }
}