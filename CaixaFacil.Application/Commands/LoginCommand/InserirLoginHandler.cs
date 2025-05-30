using CaixaFacil.Application.Models;
using CaixaFacil.Core.Repositories;
using CaixaFacil.Infrastructure.Auth;
using MediatR;

namespace CaixaFacil.Application.Commands.LoginCommand;
public class InserirLoginHandler : IRequestHandler<InserirLoginCommand, LoginViewModel>
{

    private readonly IUserRepository _userRepository;
    private readonly AuthService _authService;

    public InserirLoginHandler(IUserRepository userRepository, AuthService authService)
    {
        _userRepository = userRepository;
        _authService = authService;
    }
    public async Task<LoginViewModel> Handle(InserirLoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByUsernameAsync(request.Email);

        if (user == null)
        {
            throw new Exception("Usuário não encontrado.");
        }

        var senhaValida = AuthService.VerifyPassword(request.Password, user.Value.PasswordHash);

        if (!senhaValida)
        {
            throw new Exception("Senha inválida.");
        }

        var token =_authService.GenerateJwtToken(user.Value.Username);

        return new LoginViewModel { Token = token };
    }
}
