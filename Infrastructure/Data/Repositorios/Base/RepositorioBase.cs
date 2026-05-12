
using Domain.Repositorios.Base;
using Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositorios.Base;

public class RepositorioBase<T> : IRepositorioBase<T> where T : class
{
    protected readonly ApplicationDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public RepositorioBase(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<T?> ObtenerPorIdAsync(int id) =>
        await _dbSet.FindAsync(id);

    public async Task<IEnumerable<T>> ObtenerTodosAsync() =>
        await _dbSet.ToListAsync();

    public async Task AgregarAsync(T entidad)
    {
        await _dbSet.AddAsync(entidad);
        await _context.SaveChangesAsync();
    }
    public async Task ActualizarAsync(T entidad)
    {
        _dbSet.Update(entidad);
        await _context.SaveChangesAsync();
    }
    public async Task EliminarAsync(T entidad)
    {
        _dbSet.Remove(entidad);
        await _context.SaveChangesAsync();
    }
}