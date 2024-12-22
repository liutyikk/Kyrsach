using Kyrsach.Entities;

namespace Kyrsach.Repository;

public interface IUserRepository
{
    void Create(User user);
    User Read(int id);
    User ReadByName(string name);
    List<User> ReadAll();
}