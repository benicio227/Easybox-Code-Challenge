using CaixaFacil.Application.Models;
using CaixaFacil.Core.Entities;
using CaixaFacil.Core.Repositories;
using MediatR;

namespace CaixaFacil.Application.Commands.EmpacotamentoCommand;
public class InserirEmpacotamentoHandler : IRequestHandler<InserirEmpacotamentoCommand, List<EmpacotamentoViewModel>>
{
    private readonly ICaixaRepository _caixaReposiory;
    private readonly IPedidoRepository _pedidoRepository;

    public InserirEmpacotamentoHandler(ICaixaRepository caixaReposiory, IPedidoRepository pedidoRepository)
    {
        _caixaReposiory = caixaReposiory;
        _pedidoRepository = pedidoRepository;
    }
    public async Task<List<EmpacotamentoViewModel>> Handle(InserirEmpacotamentoCommand request, CancellationToken cancellationToken)
    {
        var caixasDisponiveis = await _caixaReposiory.GetAll(); 
        var pedidos = await _pedidoRepository.GetByIdsAsync(request.PedidosId);


        var resultado = new List<EmpacotamentoViewModel>();

        foreach (var pedido in pedidos)
        {
            var caixasUsadas = new List<CaixaComProdutos>(); 

            var produtosRestantes = new List<Produto>(pedido.Produtos); 

            while (produtosRestantes.Any()) 
            {
                var caixa = caixasDisponiveis.FirstOrDefault(c => c.Volume >= produtosRestantes.First().Volume);
                if (caixa == null)
                    throw new Exception("Nenhuma caixa disponível para o produto");

                var produtosNaCaixa = new List<ProdutoDto>();
                double volumeOcupado = 0;

                foreach (var produto in produtosRestantes.ToList())
                {
                    if (volumeOcupado + produto.Volume <= caixa.Volume)
                    {
                        produtosNaCaixa.Add(new ProdutoDto
                        {
                            Id = produto.Id,
                            Name = produto.Name,
                            Altura = produto.Altura,
                            Largura = produto.Largura,
                            Comprimento = produto.Comprimento
                        });

                        volumeOcupado += produto.Volume;
                        produtosRestantes.Remove(produto);
                    }
                }

                caixasUsadas.Add(new CaixaComProdutos
                {
                    NomeCaixa = caixa.Name,
                    Produtos = produtosNaCaixa
                });
            }

            resultado.Add(new EmpacotamentoViewModel
            {
                PedidoId = pedido.Id,
                Caixas = caixasUsadas
            });
        }
        return resultado;
    }
}
