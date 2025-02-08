using Proiect1.BLL.DTOs;
using Proiect1.DAL.Entities;
using System.Collections.Generic;

namespace Proiect1.BLL.Interfaces
{
    public interface IUserRepository
    {
        List<UserDTO> GetAllUsersToList();
        User GetUserById(int id);
        string GetUserNameById(int id);
        void DeleteUser(User user);
    }
}