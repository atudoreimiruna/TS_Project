namespace Proiect1.BLL.Models
{
    public class ReviewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
    }
}