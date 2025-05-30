using CaixaFacil.Application.Commands.CaixaCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CaixaFacil.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CaixaController : ControllerBase
{
    private readonly IMediator _mediator;

    public CaixaController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CriarCaixa([FromBody] InserirCaixaCommand command)
    {
        try
        {
            var resultado = await _mediator.Send(command);
            return Created("", resultado);
        }
        catch (Exception ex)
        {
            return BadRequest(new { erro = ex.Message });
        }
    }
}
