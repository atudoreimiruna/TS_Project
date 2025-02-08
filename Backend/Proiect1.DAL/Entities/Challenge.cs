using System;
using System.Collections.Generic;

namespace Proiect1.DAL.Entities
{
    public class Challenge
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateOfCreation { get; set; }
        public virtual ICollection<UserChallenge> UserChallenges { get; set; }

    }
}