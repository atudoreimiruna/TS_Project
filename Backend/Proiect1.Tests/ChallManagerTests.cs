using Moq;
using Proiect1.BLL.Interfaces;
using Proiect1.BLL.Managers;
using Proiect1.BLL.Models;
using Proiect1.DAL.Entities;

namespace Proiect1.Tests;

public class ChallManagerTests
{
    private Mock<IChallRepository> mockChallRepository;

    public ChallManagerTests()
    {
        mockChallRepository = new Mock<IChallRepository>();
    }

    [Fact]
    public void GetChallenges_ShouldReturnListOfChallenges()
    {
        // Arrange
        var challManager = new ChallManager(mockChallRepository.Object);

        // Act
        var result = challManager.GetChallenges();

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public void GetNewestChallenge_ShouldReturnChallenge()
    {
        // Arrange
        var expectedChallenge = new Challenge { Id = 1, Title = "Newest Challenge", Description = "Description" };
        mockChallRepository
            .Setup(repo => repo
                .GetNewestChallenge())
                .Returns(expectedChallenge);
        var challManager = new ChallManager(mockChallRepository.Object);

        // Act
        var result = challManager.GetNewestChallenge();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedChallenge.Id, result.Id);
    }

    [Fact]
    public void GetChallengeById_ShouldReturnChallenge()
    {
        // Arrange
        var challengeId = 1;
        var expectedChallenge = new Challenge { Id = challengeId, Title = "Test Challenge", Description = "Description" };
        mockChallRepository
            .Setup(repo => repo
                .GetChallengeById(challengeId))
                .Returns(expectedChallenge);
        var challManager = new ChallManager(mockChallRepository.Object);

        // Act
        var result = challManager.GetChallengeById(challengeId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedChallenge.Id, result.Id);
    }

    [Fact]
    public void CreateChallenge_ShouldCreateNewChallenge()
    {
        // Arrange
        var challengeModel = new ChallengeModel { Title = "New Challenge", Description = "Description" };
        var challManager = new ChallManager(mockChallRepository.Object);

        // Act
        challManager.CreateChallenge(challengeModel);

        // Assert
        mockChallRepository
            .Verify(repo => repo
                .CreateChallenge(It.IsAny<Challenge>()), Times.Once);
    }

    [Fact]
    public void UpdateChallenge_ShouldUpdateChallenge()
    {
        // Arrange
        var challengeId = 1;
        var challengeModel = new ChallengeModel 
        { 
            Id = challengeId, 
            Title = "Updated Challenge", 
            Description = "Updated Description" 
        };
        var existingChallenge = new Challenge 
        { 
            Id = challengeId, 
            Title = "Original Challenge", 
            Description = "Original Description" 
        };

        mockChallRepository
            .Setup(repo => repo
                .GetChallengeById(challengeId))
                .Returns(existingChallenge);
        var challManager = new ChallManager(mockChallRepository.Object);

        // Act
        challManager.UpdateChallenge(challengeModel);

        // Assert
        Assert.Equal(challengeModel.Title, existingChallenge.Title);
        Assert.Equal(challengeModel.Description, existingChallenge.Description);
        mockChallRepository
            .Verify(repo => repo
                .UpdateChallenge(existingChallenge), Times.Once);
    }

    [Fact]
    public void DeleteChallenge_ShouldDeleteChallenge()
    {
        // Arrange
        var challengeId = 1;
        var existingChallenge = new Challenge 
        { 
            Id = challengeId, 
            Title = "To be deleted", 
            Description = "Description" 
        };
        mockChallRepository
            .Setup(repo => repo
                .GetChallengeById(challengeId))
                .Returns(existingChallenge);
        var challManager = new ChallManager(mockChallRepository.Object);

        // Act
        challManager.DeleteChallenge(challengeId);

        // Assert
        mockChallRepository.Verify(repo => repo.DeleteChallenge(existingChallenge), Times.Once);
    }
}
