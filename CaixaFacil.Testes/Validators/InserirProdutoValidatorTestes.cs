using CaixaFacil.Application.Commands.ProdutoCommand;
using CaixaFacil.Application.Validator;
using FluentValidation.TestHelper;

namespace CaixaFacil.Testes.Validators;
public class InserirProdutoValidatorTestes
{
    private readonly InserirProdutoValidator _validator = new();

    [Fact]
    public void Deve_retornar_erros_para_campos_invalidos()
    {
        var model = new InserirProdutoCommand
        {
            Name = "",
            Altura = 0,
            Largura = -1,
            Comprimento = 0,
            PedidoId = 0
        };

        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(x => x.Name);
        result.ShouldHaveValidationErrorFor(x => x.Altura);
        result.ShouldHaveValidationErrorFor(x => x.Largura);
        result.ShouldHaveValidationErrorFor(x => x.Comprimento);
        result.ShouldHaveValidationErrorFor(x => x.PedidoId);
    }

    [Fact]
    public void Deve_passar_quando_dados_sao_validos()
    {
        var model = new InserirProdutoCommand
        {
            Name = "Produto 1",
            Altura = 5,
            Largura = 5,
            Comprimento = 5,
            PedidoId = 1
        };

        var result = _validator.TestValidate(model);
        result.ShouldNotHaveAnyValidationErrors();
    }
}
