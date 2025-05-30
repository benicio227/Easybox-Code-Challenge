using CaixaFacil.Core.Entities;
using CaixaFacil.Core.Repositories;
using CaixaFacil.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CaixaFacil.Infrastructure.Repositories;
public class CaixaRepository : ICaixaRepository
{
    private readonly CaixaFacilDbContext _context;
    public CaixaRepository(CaixaFacilDbContext context)
    {
        _context = context;
    }

    public async Task<Caixa> Add(Caixa caixa)
    {
        await _context.Caixas.AddAsync(caixa);
        await _context.SaveChangesAsync();
        return caixa;
    }

    public async Task<List<Caixa>> GetAll()
    {
        var caixas = await _context.Caixas.ToListAsync();

        return caixas;
    }
}
