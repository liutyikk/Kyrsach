using Kyrsach.Entities;
using Kyrsach.Service;

namespace Kyrsach.Command;

public class SessionCommand : ICommand
{
    private readonly IUserService _userService;
    private readonly IProductService _productService;
    private readonly IPurchaseHistoryService _purchaseHistoryService;
    private readonly User _currentUser;
    
    public SessionCommand(IUserService userService, IProductService productService, IPurchaseHistoryService purchaseHistoryService, User currentUser)
    {
        _userService = userService;
        _productService = productService;
        _purchaseHistoryService = purchaseHistoryService;
        _currentUser = currentUser;
    }
    
    public void Execute()
    {
        var cli = new CommandLineInterface();
        cli.RegisterCommand("addBalance", new AddBalanceCommand(_userService, _currentUser));
        cli.RegisterCommand("showProducts", new ShowProductsCommand(_productService));
        cli.RegisterCommand("purchaseProduct", new PurchaseProductCommand(_purchaseHistoryService, _productService, _currentUser));
        cli.RegisterCommand("viewPurchaseHistory", new ViewPurchaseHistoryCommand(_purchaseHistoryService, _currentUser));

        string[] choice = { "addBalance", "showProducts", "purchaseProduct", "viewPurchaseHistory", "balance", "logOut" };
        int selectedIndex = 0;
        
        while (true)
        {
            Console.Clear();
            for (int i = 0; i < choice.Length; i++)
            {
                if (i == selectedIndex)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.WriteLine(choice[i]);
                Console.ResetColor();
            }
            
            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.W:
                    selectedIndex = (selectedIndex == 0) ? choice.Length - 1 : selectedIndex - 1;
                    break;
                case ConsoleKey.S:
                    selectedIndex = (selectedIndex == choice.Length - 1) ? 0 : selectedIndex + 1;
                    break;
                case ConsoleKey.Enter:
                    if (choice [selectedIndex] == "addBalance")
                    {
                        cli.ExecuteCommand("addBalance");
                        Console.ReadKey();
                    }
                    else if (choice [selectedIndex] == "showProducts")
                    {
                        cli.ExecuteCommand("showProducts");
                        Console.ReadKey();
                    }
                    else if (choice [selectedIndex] == "purchaseProduct")
                    {
                        cli.ExecuteCommand("purchaseProduct");
                        Console.ReadKey();
                    }
                    else if (choice [selectedIndex] == "viewPurchaseHistory")
                    {
                        cli.ExecuteCommand("viewPurchaseHistory");
                        Console.ReadKey();
                    }
                    else if (choice [selectedIndex] == "balance")
                    {
                        Console.WriteLine($"Your balance: {_currentUser.Balance}");
                        Console.ReadKey();
                    }
                    else if (choice [selectedIndex] == "logOut")
                    {
                        return;
                    }

                    break;
            }
        }
    }
}