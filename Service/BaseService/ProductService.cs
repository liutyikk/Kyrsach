using Kyrsach.Entities;
using Kyrsach.Repository;

namespace Kyrsach.Service;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public List<Product> GetAllProducts() => _productRepository.ReadAll();
}