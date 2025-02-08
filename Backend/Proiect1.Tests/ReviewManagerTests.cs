using Moq;
using Proiect1.BLL.Interfaces;
using Proiect1.BLL.Managers;
using Proiect1.BLL.Models;
using Proiect1.DAL.Entities;

namespace Proiect1.Tests;

public class ReviewManagerTests
{
    private Mock<IReviewRepository> mockReviewRepository;
    private Mock<IUserRepository> mockUserRepository;

    public ReviewManagerTests()
    {
        mockReviewRepository = new Mock<IReviewRepository>();
        mockUserRepository = new Mock<IUserRepository>();
    }

    [Fact]
    public void GetUserReviews_ShouldReturnListOfUserReviews()
    {
        // Arrange
        var userId = 1;
        var reviewManager = new ReviewManager(mockReviewRepository.Object, mockUserRepository.Object);

        // Act
        var result = reviewManager.GetUserReviews(userId);

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public void GetBookReviews_ShouldReturnListOfBookReviews()
    {
        // Arrange
        var bookName = "SampleBook";
        var reviewManager = new ReviewManager(mockReviewRepository.Object, mockUserRepository.Object);

        // Act
        var result = reviewManager.GetBookReviews(bookName);

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public void CreateReview_ShouldCreateNewReview()
    {
        // Arrange
        var reviewModel = new ReviewModel 
        { 
            UserId = 1, 
            BookId = 1, 
            Title = "New Review", 
            Comment = "Good book!" 
        };
        var userName = "TestUser";
        mockUserRepository
            .Setup(repo => repo
                .GetUserNameById(reviewModel.UserId))
                .Returns(userName);
        var reviewManager = new ReviewManager(mockReviewRepository.Object, mockUserRepository.Object);

        // Act
        reviewManager
            .CreateReview(reviewModel);

        // Assert
        mockReviewRepository.Verify(repo => repo.CreateReview(It.IsAny<Review>()), Times.Once);
    }

    [Fact]
    public void GetReviewById_ShouldReturnReview()
    {
        // Arrange
        var reviewId = 1;
        var expectedReview = new Review 
        { 
            Id = reviewId, 
            UserId = 1, 
            BookId = 1, 
            Title = "Test Review", 
            Comment = "Nice book!" 
        };
        mockReviewRepository
            .Setup(repo => repo
                .GetReviewById(reviewId))
                .Returns(expectedReview);
        var reviewManager = new ReviewManager(mockReviewRepository.Object, mockUserRepository.Object);

        // Act
        var result = reviewManager.GetReviewById(reviewId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedReview.Id, result.Id);
    }

    [Fact]
    public void UpdateReview_ShouldUpdateReview()
    {
        // Arrange
        var reviewId = 1;
        var reviewModel = new ReviewModel 
        { 
            Id = reviewId, 
            Title = "Updated Review", 
            Comment = "Updated Comment" 
        };
        var existingReview = new Review 
        {
            Id = reviewId, 
            UserId = 1, 
            BookId = 1, 
            Title = "Original Review", 
            Comment = "Original Comment" 
        };
        mockReviewRepository
            .Setup(repo => repo
                .GetReviewById(reviewId))
                .Returns(existingReview);
        var reviewManager = new ReviewManager(mockReviewRepository.Object, mockUserRepository.Object);

        // Act
        reviewManager.UpdateReview(reviewModel);

        // Assert
        Assert.Equal(reviewModel.Title, existingReview.Title);
        Assert.Equal(reviewModel.Comment, existingReview.Comment);
        mockReviewRepository
            .Verify(repo => repo
            .UpdateReview(existingReview), Times.Once);
    }

    [Fact]
    public void DeleteReview_ShouldDeleteReview()
    {
        // Arrange
        var reviewId = 1;
        var existingReview = new Review 
        { 
            Id = reviewId, 
            UserId = 1, 
            BookId = 1, 
            Title = "To be deleted", 
            Comment = "Delete me!" 
        };
        mockReviewRepository
            .Setup(repo => repo
                .GetReviewById(reviewId))
                .Returns(existingReview);
        var reviewManager = new ReviewManager(mockReviewRepository.Object, mockUserRepository.Object);

        // Act
        reviewManager.DeleteReview(reviewId);

        // Assert
        mockReviewRepository
            .Verify(repo => repo
                .DeleteReview(existingReview), Times.Once);
    }
}
