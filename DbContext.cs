using Kyrsach.Entities;

namespace Kyrsach;

public class DbContext
{
    public List<User> Users { get; set; } = new List<User>();
    public List<Product> Products { get; set; } = new List<Product>();
    public List<PurchaseHistory> PurchaseHistories { get; set; } = new List<PurchaseHistory>();

    public DbContext()
    {
        Products.Add(new Product { Id = 1, Name = "Mouse", Price = 300, Quantity = 10 });
        Products.Add(new Product { Id = 2, Name = "Keyboard", Price = 500, Quantity = 15 });
        Products.Add(new Product { Id = 3, Name = "Monitor", Price = 4000, Quantity = 5 });
        Products.Add(new Product { Id = 4, Name = "Headphones", Price = 1500, Quantity = 20 });
        Products.Add(new Product { Id = 5, Name = "Microphone", Price = 2500, Quantity = 8 });
    }
}
