using Microsoft.EntityFrameworkCore;

namespace InventarioVeagroApi.Models
{
    /**
     * Permite definir el contexto de base de datos
     */
    public class ProductContext : DbContext
    {

        // se debe llamar al constructor padre
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        { 
            
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasIndex(c=> c.mainCode).IsUnique();
        }
    }
}
