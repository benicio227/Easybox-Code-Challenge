using CaixaFacil.Application.Commands.PedidoCommand;
using FluentValidation;

namespace CaixaFacil.Application.Validator;
public class InserirPedidoValidator : AbstractValidator<InserirPedidoCommand>
{
    public InserirPedidoValidator()
    {
        RuleFor(x => x.Produtos)
            .NotEmpty().WithMessage("O pedido deve conter ao menos um produto.");

        RuleForEach(x => x.Produtos).SetValidator(new ProdutoCommandModelValidator());
    }
}

public class ProdutoCommandModelValidator : AbstractValidator<ProdutoCommandModel>
{
    public ProdutoCommandModelValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("O nome do produto é obrigatório.")
            .MaximumLength(100).WithMessage("O nome deve ter no máximo 100 caracteres.");

        RuleFor(x => x.Altura)
            .GreaterThan(0).WithMessage("A altura deve ser maior que zero.");

        RuleFor(x => x.Largura)
            .GreaterThan(0).WithMessage("A largura deve ser maior que zero.");

        RuleFor(x => x.Comprimento)
            .GreaterThan(0).WithMessage("O comprimento deve ser maior que zero.");
    }
}