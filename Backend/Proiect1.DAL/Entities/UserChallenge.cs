namespace Proiect1.DAL.Entities
{
    public class UserChallenge
    {
        public int UserId { get; set; }
        public int ChallengeId { get; set; }

        public virtual User User { get; set; }
        public virtual Challenge Challenge { get; set; }
    }
}
