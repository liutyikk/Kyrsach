using Kyrsach.Entities;
using Kyrsach.Repository;

namespace Kyrsach.Service;


public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public User Register(string name, string password)
    {
        if (_userRepository.ReadByName(name) != null)
        {
            throw new Exception("User with this name already exists.");
        }

        var user = new User { Id = _userRepository.ReadAll().Count + 1, Name = name, Password = password, Balance = 0 };
        _userRepository.Create(user);
        return user;
    }

    public User Login(string name, string password)
    {
        var user = _userRepository.ReadByName(name);
        return user != null && user.Password == password ? user : null;
    }

    public void AddBalance(User user, decimal amount)
    {
        user.Balance += amount;
    }
}