using BeeWeb.Models;
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //primary keys
            modelBuilder.Entity<Usuario>().HasKey(u => u.UsurioId);
            modelBuilder.Entity<Rol>().HasKey(u => u.RolId);
            modelBuilder.Entity<Cliente>().HasKey(c => c.ClienteId);

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
        }

    }
}
