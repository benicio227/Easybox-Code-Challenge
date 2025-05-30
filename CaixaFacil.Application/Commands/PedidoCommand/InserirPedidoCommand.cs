using MediatR;

namespace CaixaFacil.Application.Commands.PedidoCommand;

public class InserirPedidoCommand : IRequest<int>
{
    public List<ProdutoCommandModel> Produtos { get; set; } = new();
}

public class ProdutoCommandModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public double Altura { get; set; }
    public double Largura { get; set; }
    public double Comprimento { get; set; }
}
