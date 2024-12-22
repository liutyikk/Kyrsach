using Kyrsach.Entities;
using Kyrsach.Service;

namespace Kyrsach.Command;

public class ViewPurchaseHistoryCommand : ICommand
{
    private readonly IPurchaseHistoryService _purchaseHistoryService;
    private User _currentUser;

    public ViewPurchaseHistoryCommand(IPurchaseHistoryService purchaseHistoryService, User currentUser)
    {
        _purchaseHistoryService = purchaseHistoryService;
        _currentUser = currentUser;
    }

    public void Execute()
    {
        var history = _purchaseHistoryService.GetPurchaseHistory(_currentUser);
        if (history.Any())
        {
            Console.WriteLine("Purchase History:");
            foreach (var purchase in history)
            {
                Console.WriteLine($"Product ID: {purchase.ProductId}, Quantity: {purchase.Quantity}, Date: {purchase.PurchaseDate}");
            }
        }
        else
        {
            Console.WriteLine("No purchase history available.");
        }
    }
}