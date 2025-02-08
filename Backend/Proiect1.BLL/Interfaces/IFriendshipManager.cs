using Proiect1.BLL.DTOs;
using Proiect1.BLL.Models;
using Proiect1.DAL.Entities;
using System.Collections.Generic;

namespace Proiect1.BLL.Interfaces
{
    public interface IFriendshipManager
    {
        void AddFriendship(FriendshipModel model);
        List<FriendshipGetDTO> GetAllFriendships();
        void DeleteFriendship(int id);
        Friendship GetFriendshipById(int id);

    }
}