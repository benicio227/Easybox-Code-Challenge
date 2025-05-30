using CaixaFacil.Core.Entities;

namespace CaixaFacil.Core.Repositories;
public interface IPedidoRepository
{
    Task<Pedido> Add(Pedido pedido);
    Task<List<Pedido>> GetAll(Pedido pedido);
    Task<List<Pedido>> GetByIdsAsync(List<int> ids);
}
