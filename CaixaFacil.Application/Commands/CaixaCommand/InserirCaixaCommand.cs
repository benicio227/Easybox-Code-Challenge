using MediatR;

namespace CaixaFacil.Application.Commands.CaixaCommand;
public class InserirCaixaCommand : IRequest<int>
{
    public int Id {  get; set; }
    public string Name { get; set; } = string.Empty;
    public double Altura { get; set; }
    public double Largura { get; set; }
    public double Comprimento { get; set; }
}
