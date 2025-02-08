using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Proiect1.DAL.Entities;

public class User : IdentityUser<int>
{
      public string RefreshToken { get; set; }
      public virtual ICollection<UserRole> UserRoles { get; set; }
      public virtual ICollection<Post> Posts { get; set; }
      public virtual ICollection<UserChallenge> UserChallenges { get; set; }
      public virtual ICollection<Review> Reviews { get; set; }
    public virtual ICollection<Friendship> Friendships { get; set; }
}
