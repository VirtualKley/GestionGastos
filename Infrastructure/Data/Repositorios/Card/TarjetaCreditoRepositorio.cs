using Domain.Entidades.Card;
using Domain.Repositorios.Card;
using Infrastructure.Data.Contexts;
using Infrastructure.Data.Repositorios.Base;

namespace Infrastructure.Data.Repositorios.Card;

public class TarjetaCreditoRepositorio(ApplicationDbContext context) : RepositorioUsuarioBase<TarjetaCredito>(context), ITarjetaCreditoRepositorio
{
    
}