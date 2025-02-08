using Proiect1.BLL.DTOs;
using Proiect1.BLL.Interfaces;
using Proiect1.DAL;
using Proiect1.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Proiect1.BLL.Repositories
{
    public class FriendshipRepository : IFriendshipRepository
    {
        private readonly AppDbContext db;

        public FriendshipRepository(AppDbContext db)
        {
            this.db = db;
        }

        public void AddFriendship(Friendship friendship)
        {
            bool ok = false;
            var friendship_verify = db.Friendships.Where(x => x.UserId == friendship.UserId).ToList();

            foreach (var fs in friendship_verify)
            {
                if (fs.FriendId == friendship.FriendId)
                {
                    ok = true;
                }
            }
            if (ok == false) { db.Friendships.Add(friendship); }

            db.SaveChanges();
        }

        public List<FriendshipGetDTO> GetFriendshipsToList()
        {
            var friendships = db.Friendships.OrderByDescending(x => x.Id).ToList();
            var result = new List<FriendshipGetDTO>();
            foreach (var fs in friendships)
            {
                var user = db.Users.FirstOrDefault(x => x.Id == fs.UserId);
                var userName = user.UserName;
                var friend = db.Users.FirstOrDefault(x => x.Id == fs.FriendId);
                var friendName = friend.UserName;
                var fsDto = new FriendshipGetDTO
                {
                    Id = fs.Id,
                    UserId = fs.UserId,
                    UserName = userName,
                    FriendId = fs.FriendId,
                    FriendName = friendName
                };
                result.Add(fsDto);
            }
            return result;
        }

        public Friendship GetFriendshipById(int id)
        {
            var friendship = db.Friendships
                .FirstOrDefault(x => x.Id == id);

            return friendship;
        }

        public void DeleteFriendship(Friendship friendship)
        {
            db.Friendships.Remove(friendship);
            db.SaveChanges();
        }
    }
}