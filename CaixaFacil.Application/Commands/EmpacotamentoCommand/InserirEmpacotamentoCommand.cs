using CaixaFacil.Application.Models;
using CaixaFacil.Core.Entities;
using MediatR;

namespace CaixaFacil.Application.Commands.EmpacotamentoCommand;
public class InserirEmpacotamentoCommand : IRequest<List<EmpacotamentoViewModel>>
{
    public List<int> PedidosId { get; set; } = new List<int>();

}
