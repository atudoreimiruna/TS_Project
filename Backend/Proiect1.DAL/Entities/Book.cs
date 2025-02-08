using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect1.DAL.Entities
{
    public class Book
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string PublishDate { get; set; }
        public string ImagePath { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
