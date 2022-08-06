using APIRotonda.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace APIRotonda.Context
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IngredientePlato>().HasKey(ip => new { ip.fkIngrediente, ip.fkPlato });
            modelBuilder.Entity<PedidoPlato>().HasKey(pp => new { pp.fkPlato, pp.fkPedido });
            modelBuilder.Entity<Cliente>().HasIndex(x => x.cedula).IsUnique();
            modelBuilder.Entity<Restaurante>().HasIndex(x => x.nit).IsUnique();
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Ingrediente> Ingrediente { get; set; }
        public DbSet<IngredientePlato> IngredientePlato { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<PedidoPlato> PedidoPlato { get; set; }
        public DbSet<Plato> Plato { get; set; }
        public DbSet<Restaurante> Restaurante { get; set; }
        public DbSet<TipoPlato> TipoPlato { get; set; }
    }
}
