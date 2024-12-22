using Kyrsach.Entities;

namespace Kyrsach.Service;

public interface IProductService
{
    List<Product> GetAllProducts();
}