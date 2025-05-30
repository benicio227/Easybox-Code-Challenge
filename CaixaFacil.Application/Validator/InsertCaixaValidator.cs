using CaixaFacil.Application.Commands.CaixaCommand;
using FluentValidation;

namespace CaixaFacil.Application.Validator;
public class InsertCaixaValidator : AbstractValidator<InserirCaixaCommand>
{
    public InsertCaixaValidator()
    {
        RuleFor(x => x.Name)
               .NotEmpty().WithMessage("O nome da caixa é obrigatório.")
               .MaximumLength(100).WithMessage("O nome da caixa deve ter no máximo 100 caracteres.");

        RuleFor(x => x.Altura)
            .GreaterThan(0).WithMessage("A altura deve ser maior que zero.");

        RuleFor(x => x.Largura)
            .GreaterThan(0).WithMessage("A largura deve ser maior que zero.");

        RuleFor(x => x.Comprimento)
            .GreaterThan(0).WithMessage("O comprimento deve ser maior que zero.");
    }
}
