using Moq;
using Proiect1.BLL.Interfaces;
using Proiect1.BLL.Managers;
using Proiect1.BLL.Models;
using Proiect1.DAL.Entities;

namespace Proiect1.Tests;

public class BookManagerTests : IClassFixture<BookManagerFixture>
{
    private readonly BookManagerFixture _fixture;

    public BookManagerTests(BookManagerFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void AddBook_ShouldAddBookToRepository()
    {
        // Arrange
        var bookModel = new BookModel
        {
            Title = "Test Book",
            Author = "Test Author",
            Description = "Test Description",
            ImagePath = "TestImagePath",
            PublishDate = DateTime.Now.ToString()
        };

        // Act
        _fixture.BookManager.AddBook(bookModel);

        // Assert
        _fixture.BookRepositoryMock.Verify(repo => repo.AddBook(It.IsAny<Book>()), Times.Once);
    }

    [Fact]
    public void GetAllBooks_ShouldReturnListOfBooks()
    {
        // Arrange
        var expectedBooks = new List<Book>
        {
            new Book 
            { 
                Title = "Test Book",
                Author = "Test Author",
                Description = "Test Description",
                ImagePath = "TestImagePath",
                PublishDate = DateTime.Now.ToString() 
            },
            new Book 
            {
                Title = "Test Book 2",
                Author = "Test Author 2",
                Description = "Test Description 2",
                ImagePath = "TestImagePath 2",
                PublishDate = DateTime.Now.ToString()
            }
        };

        _fixture.BookRepositoryMock.Setup(repo => repo.GetBooksIQueryable()).Returns(expectedBooks.AsQueryable());

        // Act
        var result = _fixture.BookManager.GetAllBooks();

        // Assert
        Assert.Equal(expectedBooks, result);
    }

    [Fact]
    public void GetBook_ShouldReturnBookWithMatchingTitle()
    {
        // Arrange
        var expectedTitle = "Test Book";
        var expectedBook = new Book
        {
            Title = expectedTitle,
            Author = "Test Author",
            Description = "Test Description",
            ImagePath = "TestImagePath",
            PublishDate = DateTime.Now.ToString()
        };

        _fixture.BookRepositoryMock.Setup(repo => repo.GetBook(expectedTitle)).Returns(expectedBook);

        // Act
        var result = _fixture.BookManager.GetBook(expectedTitle);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedTitle, result.Title);
    }
}

public class BookManagerFixture
{
    public Mock<IBookRepository> BookRepositoryMock { get; }
    public IBookManager BookManager { get; }

    public BookManagerFixture()
    {
        var bookRepositoryMock = new Mock<IBookRepository>();

        bookRepositoryMock.Setup(repo => repo.AddBook(It.IsAny<Book>()));

        BookManager = new BookManager(bookRepositoryMock.Object);
        BookRepositoryMock = bookRepositoryMock;
    }
}