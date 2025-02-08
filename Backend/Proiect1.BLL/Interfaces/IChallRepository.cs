using Proiect1.DAL.Entities;
using System.Linq;

namespace Proiect1.BLL.Interfaces
{
    public interface IChallRepository
    {
        IQueryable<Challenge> GetChallengesIQueryable();
        Challenge GetChallengeById(int id);
        Challenge GetNewestChallenge();
        void CreateChallenge(Challenge challenge);
        void UpdateChallenge(Challenge challenge);
        void DeleteChallenge(Challenge challenge);
    }
}