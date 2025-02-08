using Proiect1.DAL.Entities;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Proiect1.BLL.Interfaces
{
    public interface ITokenHelper
    {
        Task<string> CreateAccessToken(User _User);
        string CreateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string _Token);
    }
}
