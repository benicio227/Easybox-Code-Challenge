using CaixaFacil.Application.Models;
using MediatR;

namespace CaixaFacil.Application.Commands.LoginCommand;
public class InserirLoginCommand : IRequest<LoginViewModel>
{
    public string Email {  get; set; }
    public string Password {  get; set; }
}
