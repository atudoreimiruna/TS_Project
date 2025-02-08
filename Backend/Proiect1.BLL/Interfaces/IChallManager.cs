using Proiect1.BLL.Models;
using Proiect1.DAL.Entities;
using System.Collections.Generic;

namespace Proiect1.BLL.Interfaces
{
    public interface IChallManager
    {
        List<Challenge> GetChallenges();
        Challenge GetNewestChallenge();
        Challenge GetChallengeById(int id);
        void CreateChallenge(ChallengeModel model);
        void UpdateChallenge(ChallengeModel model);
        void DeleteChallenge(int id);
    }
}