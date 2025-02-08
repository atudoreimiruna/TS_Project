using Proiect1.BLL.Interfaces;
using Proiect1.DAL;
using Proiect1.DAL.Entities;
using System.Linq;

namespace Proiect1.BLL.Repositories
{
    public class ChallRepository : IChallRepository
    {
        private readonly AppDbContext db;

        public ChallRepository(AppDbContext db)
        {
            this.db = db;
        }

        public IQueryable<Challenge> GetChallengesIQueryable()
        {
            var challenges = db.Challenges
                .OrderByDescending(x => x.DateOfCreation);

            return challenges;
        }

        public Challenge GetChallengeById(int id)
        {
            var challenge = db.Challenges
                .FirstOrDefault(x => x.Id == id);

            return challenge;
        }

        public Challenge GetNewestChallenge()
        {
            var newestChall = GetChallengesIQueryable()
                .FirstOrDefault();

            return newestChall;
        }

        public void CreateChallenge(Challenge challenge)
        {
            db.Challenges.Add(challenge);
            db.SaveChanges();
        }

        public void UpdateChallenge(Challenge challenge)
        {
            db.Challenges.Update(challenge);
            db.SaveChanges();
        }

        public void DeleteChallenge(Challenge challenge)
        {
            db.Challenges.Remove(challenge);
            db.SaveChanges();
        }
    }
}