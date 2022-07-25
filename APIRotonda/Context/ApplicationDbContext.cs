using APIRotonda.Models;
using Microsoft.EntityFrameworkCore;

namespace APIRotonda.Context
{
    #pragma warning disable
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IngredientePlato>()
                .HasKey(ip => new { ip.fkIngrediente, ip.fkPlato });
            modelBuilder.Entity<PedidoPlato>()
                .HasKey(pp => new { pp.fkPlato, pp.fkPedido });
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
