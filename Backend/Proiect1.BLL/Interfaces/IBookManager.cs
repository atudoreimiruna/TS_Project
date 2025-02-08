using Proiect1.BLL.Models;
using Proiect1.DAL.Entities;
using System.Collections.Generic;

namespace Proiect1.BLL.Interfaces
{
    public interface IBookManager
    {
        void AddBook(BookModel model);
        List<Book> GetAllBooks();
        Book GetBook(string title);
        List<Book> GetBookRecommendations();
    }
}
