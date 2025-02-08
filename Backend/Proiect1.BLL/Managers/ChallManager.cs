using Proiect1.BLL.Interfaces;
using Proiect1.BLL.Models;
using Proiect1.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Proiect1.BLL.Managers;

public class ChallManager : IChallManager
{
    private readonly IChallRepository challRepository;

    public ChallManager(IChallRepository challRepository)
    {
        this.challRepository = challRepository;
    }

    public List<Challenge> GetChallenges()
    {
        return challRepository.GetChallengesIQueryable().ToList();
    }

    public Challenge GetNewestChallenge()
    {
        return challRepository.GetNewestChallenge();
    }

    public Challenge GetChallengeById(int id)
    {
        return challRepository.GetChallengeById(id);
    }

    public void CreateChallenge(ChallengeModel model)
    {
        var newChall = new Challenge
        {
            Title = model.Title,
            Description = model.Description
        };

        newChall.DateOfCreation = DateTime.Now;
        challRepository.CreateChallenge(newChall);
    }

    public void UpdateChallenge(ChallengeModel model)
    {
        var challenge = GetChallengeById(model.Id);
        if (model.Title != "")
            challenge.Title = model.Title;
        if (model.Description != "")
            challenge.Description = model.Description;

        challRepository.UpdateChallenge(challenge);
    }

    public void DeleteChallenge(int id)
    {
        var challenge = GetChallengeById(id);
        challRepository.DeleteChallenge(challenge);
    }
}