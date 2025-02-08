using Proiect1.BLL.DTOs;
using Proiect1.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proiect1.BLL.Interfaces
{
    public interface IUserManager
    {
        List<UserDTO> GetUsers();
        string GetUserNameById(int id);
        void DeleteUser(int id);
        User GetUserById(int id);
        Task SendEmailTemplate(EmailReceiverDTO emailDto);
    }
}