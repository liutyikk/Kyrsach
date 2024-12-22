using Kyrsach.Entities;

namespace Kyrsach.Repository;

public class ProductRepository : IProductRepository
{
    private readonly DbContext _db;

    public ProductRepository(DbContext db)
    {
        _db = db;
    }

    public void Create(Product product) => _db.Products.Add(product);
    public Product Read(int id) => _db.Products.FirstOrDefault(p => p.Id == id);
    public List<Product> ReadAll() => _db.Products;
    public void Update(Product product)
    {
        var existingProduct = Read(product.Id);
        if (existingProduct != null)
        {
            existingProduct.Quantity = product.Quantity;
        }
    }
}