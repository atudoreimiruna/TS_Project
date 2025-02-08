using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect1.DAL.Entities
{
    public class Review
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int BookId { get; set; }
        public User User { get; set; }
        public Book Book { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public DateTime PublishDate { get; set; }
        public virtual ICollection<Book> Books { get; set; }

    }
}