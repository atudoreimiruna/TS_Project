using Proiect1.BLL.DTOs;
using Proiect1.BLL.Interfaces;
using Proiect1.BLL.Models;
using Proiect1.DAL.Entities;
using System.Collections.Generic;

namespace Proiect1.BLL.Managers
{
    public class FriendshipManager : IFriendshipManager
    {
        private readonly IFriendshipRepository friendshipRepository;

        public FriendshipManager(IFriendshipRepository friendshipRepository)
        {
            this.friendshipRepository = friendshipRepository;
        }
        public void AddFriendship(FriendshipModel model)
        {
            var newFriendship = new Friendship
            {
                UserId = model.UserId,
                FriendId = model.FriendId
            };

            friendshipRepository.AddFriendship(newFriendship);
        }

        public List<FriendshipGetDTO> GetAllFriendships()
        {
            return friendshipRepository.GetFriendshipsToList();
        }

        public Friendship GetFriendshipById(int id)
        {
            return friendshipRepository.GetFriendshipById(id);
        }

        public void DeleteFriendship(int id)
        {
            var friendship = GetFriendshipById(id);
            friendshipRepository.DeleteFriendship(friendship);
        }
    }
}