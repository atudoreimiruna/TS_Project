namespace Proiect1.BLL.DTOs
{
    public class FriendshipGetDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int FriendId { get; set; }
        public string FriendName { get; set; }
    }
}