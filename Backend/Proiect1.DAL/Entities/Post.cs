using System;

namespace Proiect1.DAL.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public User User { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public DateTime PublishDate { get; set; }
    }
}