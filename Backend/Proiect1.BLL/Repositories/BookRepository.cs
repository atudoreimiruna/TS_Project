using Proiect1.BLL.Interfaces;
using Proiect1.DAL.Entities;
using Proiect1.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect1.BLL.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext db;

        public BookRepository(AppDbContext db)
        {
            this.db = db;
        }

        public void AddBook(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
        }

        public IQueryable<Book> GetBooksIQueryable()
        {
            var books = db.Books.OrderByDescending(x => x.Id);
            return books;
        }

        public IQueryable<Book> GetBooksRecommendationsIQueryable() 
        {
            var books = db.Books.OrderByDescending(x => x.PublishDate);
            return books;
        }

        public Book GetBook(string title)
        {
            var book = db.Books
                .FirstOrDefault(x => x.Title == title);

            return book;
        }

    }
}
