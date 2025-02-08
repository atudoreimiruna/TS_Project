using Proiect1.BLL.Interfaces;
using Proiect1.BLL.Models;
using Proiect1.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Proiect1.BLL.Managers;

public class ReviewManager : IReviewManager
{
    private readonly IReviewRepository reviewRepository;
    private readonly IUserRepository userRepository;
    public ReviewManager(IReviewRepository reviewRepository, IUserRepository userRepository)
    {
        this.reviewRepository = reviewRepository;
        this.userRepository = userRepository;
    }

    public List<Review> GetAllReviews()
    {
        return reviewRepository.GetReviewsToList();
    }

    public List<Review> GetUserReviews(int id)
    {
        return reviewRepository.GetUserReviewsIQueryable(id).ToList();
    }

    public List<Review> GetBookReviews(string bookName)
    {
        return reviewRepository.GetBookReviewsIQueryable(bookName).ToList();
    }

    public void CreateReview(ReviewModel model)
    {
        var newReview = new Review
        {
            UserId = model.UserId,
            BookId = model.BookId,
            Title = model.Title,
            Comment = model.Comment
        };
        string userName = userRepository.GetUserNameById(newReview.UserId);
        newReview.UserName = userName;
        newReview.PublishDate = DateTime.Now;
        reviewRepository.CreateReview(newReview);
    }

    public Review GetReviewById(int id)
    {
        return reviewRepository.GetReviewById(id);
    }

    public void UpdateReview(ReviewModel model)
    {
        var review = GetReviewById(model.Id);
        if (model.Title != "")
            review.Title = model.Title;
        if (model.Comment != "")
            review.Comment = model.Comment;

        reviewRepository.UpdateReview(review);
    }

    public void DeleteReview(int id)
    {
        var review = GetReviewById(id);
        reviewRepository.DeleteReview(review);
    }

    public List<Review> GetReviewsofFriends(int id)
    {
        return reviewRepository.GetReviewsOfFriendsIQueryable(id).ToList();
    }
}