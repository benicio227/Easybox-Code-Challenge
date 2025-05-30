using CaixaFacil.Core.Entities;

namespace CaixaFacil.Core.Repositories;
public interface ICaixaRepository
{
    Task<Caixa> Add(Caixa caixa);
    Task<List<Caixa>> GetAll();
}
