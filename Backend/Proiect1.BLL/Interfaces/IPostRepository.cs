using Proiect1.DAL.Entities;
using System.Linq;

namespace Proiect1.BLL.Interfaces
{
    public interface IPostRepository
    {
        IQueryable<Post> GetAllUserPostsIQueryable(int id);
        Post GetPostById(int id);
        void CreatePost(Post post);
        void UpdatePost(Post post);
        void DeletePost(Post post);
        IQueryable<Post> GetAllPostsIQueryable();
        IQueryable<Post> GetPostsOfFriendsIQueryable(int id);
    }
}