using Moq;
using Proiect1.BLL.Interfaces;
using Proiect1.BLL.Managers;
using Proiect1.BLL.Models;
using Proiect1.DAL.Entities;

namespace Proiect1.Tests;

public class PostManagerTests
{
    private Mock<IPostRepository> mockPostRepository;
    private Mock<IUserRepository> mockUserRepository;

    public PostManagerTests()
    {
        mockPostRepository = new Mock<IPostRepository>();
        mockUserRepository = new Mock<IUserRepository>();
    }

    [Fact]
    public void GetAllUserPosts_ShouldReturnListOfPosts()
    {
        var postManager = new PostManager(mockPostRepository.Object, mockUserRepository.Object);

        var result = postManager.GetAllUserPosts(1);

        Assert.NotNull(result);
    }

    [Fact]
    public void GetAllPosts_ShouldReturnListOfPosts()
    {
        var postManager = new PostManager(mockPostRepository.Object, mockUserRepository.Object);

        var result = postManager.GetAllPosts();

        Assert.NotNull(result);
    }

    [Fact]
    public void GetPostById_ShouldReturnPost()
    {
        // Arrange
        var postId = 1;
        var expectedPost = new Post 
        { 
            Id = postId, 
            UserId = 1, 
            Description = "Test Post" 
        };
        mockPostRepository
            .Setup(repo => repo
                .GetPostById(postId))
                .Returns(expectedPost);
        var postManager = new PostManager(mockPostRepository.Object, mockUserRepository.Object);

        // Act
        var result = postManager.GetPostById(postId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedPost.Id, result.Id);
    }

    [Fact]
    public void CreatePost_ShouldCreateNewPost()
    {
        // Arrange
        var userModel = new PostModel 
        { 
            UserId = 1, 
            Description = "New Post", 
            ImagePath = "path/to/image.jpg" 
        };
        var userName = "TestUser";
        mockUserRepository
            .Setup(repo => repo
                .GetUserNameById(userModel.UserId))
                .Returns(userName);
        var postManager = new PostManager(mockPostRepository.Object, mockUserRepository.Object);

        // Act
        postManager.CreatePost(userModel);

        // Assert
        mockPostRepository
            .Verify(repo => repo
                .CreatePost(It.IsAny<Post>()), Times.Once);
    }

    [Fact]
    public void UpdatePost_ShouldUpdatePost()
    {
        // Arrange
        var postId = 1;
        var postModel = new PostModel 
        { 
            Id = postId, 
            Description = "Updated Post", 
            ImagePath = "path/to/updated-image.jpg" 
        };
        var existingPost = new Post 
        { 
            Id = postId, 
            UserId = 1, 
            Description = "Original Post" 
        };
        mockPostRepository
            .Setup(repo => repo
                .GetPostById(postId))
                .Returns(existingPost);

        var postManager = new PostManager(mockPostRepository.Object, mockUserRepository.Object);

        // Act
        postManager.UpdatePost(postModel);

        // Assert
        Assert.Equal(postModel.Description, existingPost.Description);
        Assert.Equal(postModel.ImagePath, existingPost.ImagePath);
        mockPostRepository.Verify(repo => repo.UpdatePost(existingPost), Times.Once);
    }

    [Fact]
    public void DeletePost_ShouldDeletePost()
    {
        // Arrange
        var postId = 1;
        var existingPost = new Post 
        { 
            Id = postId, 
            UserId = 1, 
            Description = "To be deleted" 
        };

        mockPostRepository
            .Setup(repo => repo
                .GetPostById(postId))
                .Returns(existingPost);
        var postManager = new PostManager(mockPostRepository.Object, mockUserRepository.Object);

        // Act
        postManager.DeletePost(postId);

        // Assert
        mockPostRepository
            .Verify(repo => repo
                .DeletePost(existingPost), Times.Once);
    }
}