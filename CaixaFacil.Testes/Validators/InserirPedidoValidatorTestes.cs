using CaixaFacil.Application.Commands.PedidoCommand;
using CaixaFacil.Application.Validator;
using FluentValidation.TestHelper;

namespace CaixaFacil.Testes.Validators;
public class InserirPedidoValidatorTestes
{
    private readonly InserirPedidoValidator _validator = new();

    [Fact]
    public void Deve_retornar_erro_se_nao_tiver_produtos()
    {
        var model = new InserirPedidoCommand { Produtos = new() };

        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(x => x.Produtos);
    }

    [Fact]
    public void Deve_retornar_erro_se_produto_invalido()
    {
        var model = new InserirPedidoCommand
        {
            Produtos = new List<ProdutoCommandModel>
            {
                new ProdutoCommandModel
                {
                    Name = "",
                    Altura = 0,
                    Largura = 0,
                    Comprimento = 0
                }
            }
        };

        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor("Produtos[0].Name");
        result.ShouldHaveValidationErrorFor("Produtos[0].Altura");
        result.ShouldHaveValidationErrorFor("Produtos[0].Largura");
        result.ShouldHaveValidationErrorFor("Produtos[0].Comprimento");
    }

    [Fact]
    public void Deve_passar_quando_todos_produtos_sao_validos()
    {
        var model = new InserirPedidoCommand
        {
            Produtos = new List<ProdutoCommandModel>
            {
                new ProdutoCommandModel
                {
                    Name = "Produto válido",
                    Altura = 10,
                    Largura = 10,
                    Comprimento = 10
                }
            }
        };

        var result = _validator.TestValidate(model);
        result.ShouldNotHaveAnyValidationErrors();
    }

}
