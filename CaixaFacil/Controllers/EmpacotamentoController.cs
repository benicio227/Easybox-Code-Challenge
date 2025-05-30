using CaixaFacil.Application.Commands.EmpacotamentoCommand;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CaixaFacil.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmpacotamentoController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmpacotamentoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> InserirEmpacotamento([FromBody] InserirEmpacotamentoCommand command)
    {
        try
        {
            var resultado = await _mediator.Send(command);
            return Ok(resultado);
        }
        catch (Exception ex)
        {
            return BadRequest(new { erro = ex.Message });
        }
    }
}
