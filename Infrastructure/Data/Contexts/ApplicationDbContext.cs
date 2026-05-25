using Domain.Entidades.Auth;
using Domain.Entidades.Card;
using Domain.Entidades.Catalog;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Contexts
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Usuario> Usuarios {get; set;}
        public DbSet<Categoria> Categorias {get; set;}
        public DbSet<TarjetaCredito> TarjetasCredrito {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuarios");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Activo).IsRequired().HasDefaultValue(true);
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.ToTable("categorias");
                entity.HasKey(c => c.Id);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(80);
                entity.Property(e => e.Icono).IsRequired().HasMaxLength(30);
                entity.Property(e => e.ColorHex).IsRequired().HasMaxLength(30);
                entity.Property(e => e.Icono).IsRequired().HasMaxLength(30);
            });

            modelBuilder.Entity<TarjetaCredito>(entity =>
            {
                entity.ToTable("tarjetas_credito");
                entity.HasKey(t => t.Id);
                entity.Property(t => t.UltimoCuatroDigitos).HasMaxLength(4);
                entity.Property(t => t.LimiteCredito).HasPrecision(12, 2);
            });
        } 
    }
}