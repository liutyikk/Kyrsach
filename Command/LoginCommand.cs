using Kyrsach.Entities;
using Kyrsach.Service;

namespace Kyrsach.Command;

public class LoginCommand : ICommand
{
    private readonly IUserService _userService;
    private User _currentUser;

    public LoginCommand(IUserService userService)
    {
        _userService = userService;
    }

    public void Execute()
    {
        Console.Write("Enter Name: ");
        var name = Console.ReadLine();
        Console.Write("Enter Password: ");
        var password = Console.ReadLine();

        try
        {
            _currentUser = _userService.Login(name, password);
            Console.WriteLine($"Welcome, {_currentUser.Name}!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Login failed: {ex.Message}");
        }
    }

    public User GetCurrentUser()
    {
        return _currentUser;
    }
}