using Proiect1.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect1.BLL.Interfaces
{
    public interface IBookRepository
    {
        void AddBook(Book book);
        IQueryable<Book> GetBooksIQueryable();
        IQueryable<Book> GetBooksRecommendationsIQueryable();
        Book GetBook(string title);
    }
}
