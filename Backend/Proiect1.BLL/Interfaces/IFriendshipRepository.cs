using Proiect1.BLL.DTOs;
using Proiect1.DAL.Entities;
using System.Collections.Generic;

namespace Proiect1.BLL.Interfaces
{
    public interface IFriendshipRepository
    {
        void AddFriendship(Friendship friendship);
        List<FriendshipGetDTO> GetFriendshipsToList();
        void DeleteFriendship(Friendship friendship);
        Friendship GetFriendshipById(int id);
    }
}