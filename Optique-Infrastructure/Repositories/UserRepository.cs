using Core.App.Interfaces;
using Infrastructure.Data;
using Optique_Domaine.Entities;

namespace Para.Infrastructure.Repository;
public class UserRepository : IUserRepository
{
    private readonly OpDbContext _dbContext;

    public UserRepository(OpDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<User> GetUsers()
    {
        return _dbContext.Users.ToList();
    }

    public User GetUserById(string userId)
    {
        return _dbContext.Users.FirstOrDefault(u => u.Id == userId) ?? throw new InvalidOperationException("User Not found ");
    }

    public void InsertUser(User user)
    {
        _dbContext.Users.Add(user);
    }

    public void UpdateUser(User user)
    {
        _dbContext.Users.Update(user);
    }

    public void DeleteUser(string userId)
    {
        var user = _dbContext.Users.FirstOrDefault(u => u.Id == userId);
        if (user != null)
        {
            _dbContext.Users.Remove(user);
        }
    }

    public void Save()
    {
        _dbContext.SaveChanges();
    }
}

