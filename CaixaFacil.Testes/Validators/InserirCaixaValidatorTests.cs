using CaixaFacil.Application.Commands.CaixaCommand;
using CaixaFacil.Application.Validator;
using FluentValidation.TestHelper;

namespace CaixaFacil.Testes.Validators;
public class InserirCaixaValidatorTests
{
    private readonly InsertCaixaValidator _validator = new();

    [Fact]
    public void Deve_retornar_erro_se_nome_estiver_vazio()
    {
        var model = new InserirCaixaCommand { Name = "" };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Name);
    }

    [Fact]
    public void Deve_retornar_erro_se_dimensoes_nao_fore_maiores_que_zero()
    {
        var model = new InserirCaixaCommand { Altura = 0, Largura = -1, Comprimento = 0 };
        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(x => x.Altura);
        result.ShouldHaveValidationErrorFor(x => x.Largura);
        result.ShouldHaveValidationErrorFor(x => x.Comprimento);
    }

    [Fact]
    public void Deve_passar_quando_dados_sao_validos()
    {
        var model = new InserirCaixaCommand
        {
            Name = "Caixa Padrão",
            Altura = 10,
            Largura = 10,
            Comprimento = 10
        };

        var result = _validator.TestValidate(model);
        result.ShouldNotHaveAnyValidationErrors();
    }
}
