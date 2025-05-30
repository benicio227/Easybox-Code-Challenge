using CaixaFacil.Application.Commands.EmpacotamentoCommand;
using FluentValidation;

namespace CaixaFacil.Application.Validator;
public class InserirEmpacotamentoValidator : AbstractValidator<InserirEmpacotamentoCommand>
{
    public InserirEmpacotamentoValidator()
    {
        RuleFor(x => x.PedidosId)
            .NotNull().WithMessage("A lista de pedidos não pode ser nula.")
            .NotEmpty().WithMessage("Informe ao menos um pedido para empacotar.");
    }
}
