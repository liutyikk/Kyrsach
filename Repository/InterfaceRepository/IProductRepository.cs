using Kyrsach.Entities;

namespace Kyrsach.Repository;

public interface IProductRepository
{
    void Create(Product product);
    Product Read(int id);
    List<Product> ReadAll();
    void Update(Product product);
}