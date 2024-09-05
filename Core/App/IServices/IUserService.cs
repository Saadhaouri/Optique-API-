using Core.App.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.App.IServices;

public interface IUserService
{
    IEnumerable<UserDto> GetUsers();
    UserDto GetUserById(string userId);
    void AddUser(UserDto user);
    void UpdateUser(UserDto user);
    void DeleteUser(string userId);
}
