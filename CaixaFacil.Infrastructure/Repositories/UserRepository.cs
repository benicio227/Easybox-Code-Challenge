using CaixaFacil.Core.Repositories;
using CaixaFacil.Infrastructure.Auth;

namespace CaixaFacil.Infrastructure.Repositories;
public class UserRepository : IUserRepository
{
    private readonly List<(string Username, string PasswordHash)> _users = new()
    {
        ("admin", AuthService.HashPassword("123456"))
    };

    public Task<(string Username, string PasswordHash)?> GetByUsernameAsync(string username)
    {
        var user = _users.FirstOrDefault(u => u.Username == username);

      
        if (EqualityComparer<(string Username, string PasswordHash)>.Default.Equals(user, default))
        {
            return Task.FromResult<(string Username, string PasswordHash)?>(null);
        }

        return Task.FromResult<(string Username, string PasswordHash)?>(user);
    }
}


