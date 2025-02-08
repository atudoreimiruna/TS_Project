using Proiect1.BLL.Models;
using Proiect1.DAL.Entities;
using System.Collections.Generic;

namespace Proiect1.BLL.Interfaces
{
    public interface IReviewManager
    {
        List<Review> GetUserReviews(int id);
        List<Review> GetBookReviews(string bookName);
        void CreateReview(ReviewModel model);
        Review GetReviewById(int id);
        void UpdateReview(ReviewModel model);
        void DeleteReview(int id);
        List<Review> GetAllReviews();
        List<Review> GetReviewsofFriends(int id);
    }
}