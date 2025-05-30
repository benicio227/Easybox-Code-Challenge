using CaixaFacil.Core.Entities;
using CaixaFacil.Core.Repositories;
using MediatR;

namespace CaixaFacil.Application.Commands.PedidoCommand;

public class CriarPedidoHandler : IRequestHandler<InserirPedidoCommand, int>
{
    private readonly IPedidoRepository _pedidoRepository;

    public CriarPedidoHandler(IPedidoRepository pedidoRepository)
    {
        _pedidoRepository = pedidoRepository;
    }

    public async Task<int> Handle(InserirPedidoCommand request, CancellationToken cancellationToken)
    {
        var pedido = new Pedido
        {
            Produtos = request.Produtos.Select(p => new Produto
            {
                Id = p.Id,
                Name = p.Name,
                Altura = p.Altura,
                Largura = p.Largura,
                Comprimento = p.Comprimento
            }).ToList()
        };

        await _pedidoRepository.Add(pedido);
        return pedido.Id;
    }
}
