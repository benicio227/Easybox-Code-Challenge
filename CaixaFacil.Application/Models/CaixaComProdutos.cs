using CaixaFacil.Core.Entities;

namespace CaixaFacil.Application.Models;
public class CaixaComProdutos
{
    public string NomeCaixa {  get; set; }
    public List<ProdutoDto> Produtos {  get; set; } = new List<ProdutoDto>();
}
