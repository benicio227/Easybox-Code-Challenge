using MediatR;

namespace CaixaFacil.Application.Commands.ProdutoCommand;
public class InserirProdutoCommand : IRequest<int>
{
    public int Id { get; set; }
    public int PedidoId { get; set; }
    public string Name { get; set; } = string.Empty;
    public double Altura { get; set; }
    public double Largura { get; set; }
    public double Comprimento { get; set; }
}
