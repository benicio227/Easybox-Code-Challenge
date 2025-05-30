using CaixaFacil.Core.Entities;

namespace CaixaFacil.Core.Repositories;
public interface IProdutoRepository
{
    Task<Produto> Add(Produto produto);
}
