using CaixaFacil.Core.Entities;
using CaixaFacil.Core.Repositories;
using MediatR;

namespace CaixaFacil.Application.Commands.ProdutoCommand;

public class CriarProdutoHandler : IRequestHandler<InserirProdutoCommand, int>
{
    private readonly IProdutoRepository _produtoRepository;

    public CriarProdutoHandler(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<int> Handle(InserirProdutoCommand request, CancellationToken cancellationToken)
    {
        var produto = new Produto
        {
            Id = request.Id,
            PedidoId = request.PedidoId,
            Name = request.Name,
            Altura = request.Altura,
            Largura = request.Largura,
            Comprimento = request.Comprimento
        };

        await _produtoRepository.Add(produto);
        return produto.Id;
    }
}
