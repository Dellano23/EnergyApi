using Fiap.Api.Energy.Models;

namespace Fiap.Api.Energy.Services
{
    public interface IAuthService
    {
        UserModel Authenticate(string username, string password);
    }
}