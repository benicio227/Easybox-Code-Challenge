namespace CaixaFacil.Core.Repositories;
public interface IUserRepository
{
    Task<(string Username, string PasswordHash)?> GetByUsernameAsync(string username);
}
