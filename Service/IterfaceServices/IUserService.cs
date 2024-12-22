using Kyrsach.Entities;

namespace Kyrsach.Service;

public interface IUserService
{
    User Register(string name, string password);
    User Login(string name, string password);
    void AddBalance(User user, decimal amount);
}