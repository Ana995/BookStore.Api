using System.Threading.Tasks;
using BookStore.Ports.Web.LogIn.Models;

namespace BookStore.Domain.LogIn.Interfaces
{
    public interface IAuthenticationService
    {
        Task<AuthenticatedUserModel> LogIn(AuthenticationUser userForAuthentication);
        Task LogOut();
    }

}
