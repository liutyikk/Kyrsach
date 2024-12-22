using Kyrsach.Entities;
using Kyrsach.Service;

namespace Kyrsach.Command;

public class PurchaseProductCommand : ICommand
{
    private readonly IPurchaseHistoryService _purchaseHistoryService;
    private readonly IProductService _productService;
    private User _currentUser;

    public PurchaseProductCommand(IPurchaseHistoryService purchaseHistoryService, IProductService productService, User currentUser)
    {
        _purchaseHistoryService = purchaseHistoryService;
        _productService = productService;
        _currentUser = currentUser;
    }

    public void Execute()
    {
        Console.Write("Enter Product ID to purchase: ");
        if (int.TryParse(Console.ReadLine(), out var productId))
        {
            Console.Write("Enter quantity: ");
            if (int.TryParse(Console.ReadLine(), out var quantity) && quantity > 0)
            {
                try
                {
                    _purchaseHistoryService.PurchaseProduct(_currentUser, productId, quantity);
                    Console.WriteLine("Purchase successful!");

                    // Show updated products
                    new ShowProductsCommand(_productService).Execute();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Purchase failed: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Invalid quantity.");
            }
        }
        else
        {
            Console.WriteLine("Invalid product ID.");
        }
    }
}