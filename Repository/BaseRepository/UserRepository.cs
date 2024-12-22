using Kyrsach.Entities;

namespace Kyrsach.Repository;

public class UserRepository : IUserRepository
{
    private readonly DbContext _db;

    public UserRepository(DbContext db)
    {
        _db = db;
    }

    public void Create(User user) => _db.Users.Add(user);
    public User Read(int id) => _db.Users.FirstOrDefault(u => u.Id == id);
    public User ReadByName(string name) => _db.Users.FirstOrDefault(u => u.Name == name);
    public List<User> ReadAll() => _db.Users;
}