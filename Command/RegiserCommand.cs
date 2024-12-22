using Kyrsach.Service;

namespace Kyrsach.Command;

public class RegisterCommand : ICommand
{
    private readonly IUserService _userService;

    public RegisterCommand(IUserService userService)
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
            _userService.Register(name, password);
            Console.WriteLine("Registration successful!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Registration failed: {ex.Message}");
        }
    }
}
