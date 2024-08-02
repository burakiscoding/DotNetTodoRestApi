using DotNetTodoRestApi.Models;

namespace DotNetTodoRestApi.Services
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
