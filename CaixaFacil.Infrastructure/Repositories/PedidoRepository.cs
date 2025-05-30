using CaixaFacil.Core.Entities;
using CaixaFacil.Core.Repositories;
using CaixaFacil.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CaixaFacil.Infrastructure.Repositories;
public class PedidoRepository : IPedidoRepository
{
    private readonly CaixaFacilDbContext _context;

    public PedidoRepository(CaixaFacilDbContext context)
    {
        _context = context;
    }
    public async Task<Pedido> Add(Pedido pedido)
    {
        await _context.Pedidos.AddAsync(pedido);
        await _context.SaveChangesAsync();
        return pedido;
    }

    public async Task<List<Pedido>> GetAll(Pedido pedido)
    {
        var pedidos = await _context.Pedidos.ToListAsync();
        return pedidos;
    }

    public async Task<List<Pedido>> GetByIdsAsync(List<int> ids)
    {
        var pedidos = await _context.Pedidos.Include(p => p.Produtos).Where(p => ids.Contains(p.Id)).ToListAsync();
        return pedidos;
    }
}
