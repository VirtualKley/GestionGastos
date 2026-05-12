using Domain.Entidades.Auth;
using Domain.Repositorios.Base;
using Infrastructure.Data.Contexts;
using Infrastructure.Data.Repositorios.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositorios.Auth;

public class UsuarioRepositorio(ApplicationDbContext context) : RepositorioBase<Usuario>(context), IUsuarioRepositorio
{
    public async Task<Usuario?> ObtenerPorEmailAsync(string email) =>
        await _dbSet.FirstOrDefaultAsync(u => u.Email == email);

    public async Task<bool> ExisteEmailAsync(string email) =>
        await _dbSet.AnyAsync(u => u.Email == email);
}