using Microsoft.EntityFrameworkCore;
using StoreDatabase.Entities;

namespace StoreDatabase.Data;
public class StoreContext : DbContext {
    public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, ProductName = "Cheese Pizza", ProductPrice = 9.0f },
                new Product { ProductId = 2, ProductName = "Pepperoni Pizza", ProductPrice = 10.0f},
                new Product { ProductId = 3, ProductName = "Supreme Pizza", ProductPrice = 12.0f},
                new Product { ProductId = 4, ProductName = "Bread Sticks", ProductPrice = 5.0f},
                new Product { ProductId = 5, ProductName = "Soft Drink", ProductPrice = 2.0f},
                new Product { ProductId = 6, ProductName = "Side Salad", ProductPrice = 3.0f}
            );
    }
}
