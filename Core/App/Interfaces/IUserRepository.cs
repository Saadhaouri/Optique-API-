using Optique_Domaine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.App.Interfaces;

public interface IUserRepository
{
    IEnumerable<User> GetUsers();
    User GetUserById(string userId);
    void InsertUser(User user);
    void UpdateUser(User user);
    void DeleteUser(string userId);
    void Save();
}
