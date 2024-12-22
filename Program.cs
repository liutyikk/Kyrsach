using Kyrsach.Command;
using Kyrsach.Repository;
using Kyrsach.Service;

namespace Kyrsach
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var db = new DbContext();

            var userRepository = new UserRepository(db);
            var productService = new ProductService(new ProductRepository(db));
            var purchaseService = new PurchaseHistoryService(new ProductRepository(db), new PurchaseHistoryRepository(db));
            var userService = new UserService(userRepository);

            var cli = new CommandLineInterface();

            cli.RegisterCommand("register", new RegisterCommand(userService));
            cli.RegisterCommand("login", new LoginCommand(userService));
           
            string[] choice = { "register", "login", "exit" };
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
                        if (choice [selectedIndex] == "register")
                        {
                            cli.ExecuteCommand("register");
                        }
                        else if (choice [selectedIndex] == "login")
                        {
                            cli.ExecuteCommand("login");
                            var user = ((LoginCommand) cli.GetCommand("login")).GetCurrentUser();
                            if (user != null)
                            {
                                cli.RegisterCommand("session", new SessionCommand(userService, productService, purchaseService, user));
                                cli.ExecuteCommand("session");
                            }
                        }
                        else if (choice [selectedIndex] == "exit")
                        {
                            return;
                        }
                        break;
                }
            }
        }
    }
}