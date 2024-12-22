using Kyrsach.Service;

namespace Kyrsach.Command;

public class ShowProductsCommand : ICommand
{
    private readonly IProductService _productService;

    public ShowProductsCommand(IProductService productService)
    {
        _productService = productService;
    }

    public void Execute()
    {
        var products = _productService.GetAllProducts();
        Console.WriteLine("Available Products:");
        foreach (var product in products)
        {
            Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}, Quantity: {product.Quantity}");
        }
    }
}