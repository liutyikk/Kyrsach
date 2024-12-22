using Kyrsach.Entities;
using Kyrsach.Service;

namespace Kyrsach.Command;

public class AddBalanceCommand : ICommand
{
    private readonly IUserService _userService;
    private User _currentUser;

    public AddBalanceCommand(IUserService userService, User currentUser)
    {
        _userService = userService;
        _currentUser = currentUser;
    }

    public void Execute()
    {
        Console.Write("Enter amount to add to balance: ");
        if (decimal.TryParse(Console.ReadLine(), out var amount) && amount > 0)
        {
            _userService.AddBalance(_currentUser, amount);
            Console.WriteLine($"Balance successfully added. New balance: {_currentUser.Balance}");
        }
        else
        {
            Console.WriteLine("Invalid amount.");
        }
    }
}