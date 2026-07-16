using BeeWeb.Models;
using Microsoft.DotNet.Scaffolding.Shared.Project;
using Microsoft.EntityFrameworkCore;

namespace BeeWeb.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Usuario> TblUsuario => Set<Usuario>();
        public DbSet<Rol> TblRol => Set<Rol>();
        public DbSet<Cliente> TblCliente => Set<Cliente>();
        public DbSet<Negocio> TblNegocio => Set<Negocio>();
        public DbSet<Articulo> TblArticulo => Set<Articulo>();
        public DbSet<Categoria> TblCategoria => Set<Categoria>();
        public DbSet<Marca> TblMarca => Set<Marca>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //primary keys
            modelBuilder.Entity<Usuario>().HasKey(u => u.UsurioId);
            modelBuilder.Entity<Rol>().HasKey(u => u.RolId);
            modelBuilder.Entity<Cliente>().HasKey(c => c.ClienteId);
            modelBuilder.Entity<Negocio>().HasKey(n => n.NegocioId);
            modelBuilder.Entity<Articulo>().HasKey(a => a.ArticuloId);
            modelBuilder.Entity<Categoria>().HasKey(c=>c.CategoriaId);
            modelBuilder.Entity<Marca>().HasKey(m => m.MarcaId);

            //relacionar 1 a 1 de usuario a cliente
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Cliente)
                .WithOne(c => c.Usuario)
                .HasForeignKey<Cliente>(c => c.UsuarioId);
            
            //relacion * a * usuario roles
            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Roles)
                .WithMany(r => r.Usuarios);
            base.OnModelCreating(modelBuilder);

            //relacion de 1 a * usuario negocios
            modelBuilder.Entity<Usuario>()
                .HasMany(x => x.Negocios)
                .WithOne(n => n.Usuario)
                .HasForeignKey(x => x.UsuarioId)
                .IsRequired();

            //relacion 1 a * (una categoria puede tener muchos articulos)
            modelBuilder.Entity<Categoria>()
                .HasMany(x => x.Articulos)
                .WithOne(x => x.Categoria)
                .HasForeignKey(x => x.ArticuloId)
                .IsRequired();

            //relaciones 1 a * (una marca puede tener muchos articulos)
            modelBuilder.Entity<Marca>()
                .HasMany(x => x.Articulos)
                .WithOne(x => x.Marca)
                .HasForeignKey(x => x.MarcaId)
                .IsRequired();

        }

    }
}
