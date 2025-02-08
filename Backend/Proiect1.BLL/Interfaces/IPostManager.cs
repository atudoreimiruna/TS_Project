using Proiect1.BLL.Models;
using Proiect1.DAL.Entities;
using System.Collections.Generic;

namespace Proiect1.BLL.Interfaces
{
    public interface IPostManager
    {
        List<Post> GetAllUserPosts(int id);
        Post GetPostById(int id);
        void CreatePost(PostModel model);
        void UpdatePost(PostModel model);
        public void DeletePost(int id);
        List<Post> GetAllPosts();
        List<Post> GetPostsofFriends(int id);
    }
}