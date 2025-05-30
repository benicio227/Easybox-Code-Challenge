using CaixaFacil.Core.Entities;
using CaixaFacil.Core.Repositories;
using CaixaFacil.Infrastructure.Persistence;

namespace CaixaFacil.Infrastructure.Repositories;
public class ProdutoRepository : IProdutoRepository
{
    private readonly CaixaFacilDbContext _context;

    public ProdutoRepository(CaixaFacilDbContext context)
    {
        _context = context;
    }
    public async Task<Produto> Add(Produto produto)
    {
        await _context.Produtos.AddAsync(produto);
        await _context.SaveChangesAsync();
        return produto;
    }
}
