using Microsoft.EntityFrameworkCore;

namespace InventarioVeagroApi.Models
{
    /**
     * Permite definir el contexto de base de datos, se crea uno solo para cada base de datos
     * ,
     */
    public class ProductContext : DbContext
    {

        // se debe llamar al constructor padre
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        { 
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Sale> Sale { get; set; }
        public DbSet<SaleDetail> SaleDetail { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<Product>().HasIndex(c=> c.mainCode).IsUnique();
            modelBuilder.Entity<User>().HasIndex(c=> c.Dni).IsUnique();
            base.OnModelCreating(modelBuilder);
        }
    }
}
