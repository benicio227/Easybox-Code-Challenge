using CaixaFacil.Application.Commands.EmpacotamentoCommand;
using CaixaFacil.Application.Validator;
using FluentValidation.TestHelper;

namespace CaixaFacil.Testes.Validators;
public class InserirEmpacotamentoTestes
{
    private readonly InserirEmpacotamentoValidator _validator = new();

    [Fact]
    public void Deve_retornar_erro_se_lista_for_nula()
    {
        var model = new InserirEmpacotamentoCommand
        {
            PedidosId = null!
        };

        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(x => x.PedidosId)
              .WithErrorMessage("A lista de pedidos não pode ser nula.");
    }

    [Fact]
    public void Deve_retornar_erro_se_lista_estiver_vazia()
    {
        var model = new InserirEmpacotamentoCommand
        {
            PedidosId = new List<int>()
        };

        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(x => x.PedidosId)
              .WithErrorMessage("Informe ao menos um pedido para empacotar.");
    }

    [Fact]
    public void Deve_passar_quando_lista_contem_pedidos()
    {
        var model = new InserirEmpacotamentoCommand
        {
            PedidosId = new List<int> { 1, 2, 3 }
        };

        var result = _validator.TestValidate(model);

        result.ShouldNotHaveAnyValidationErrors();
    }
}
