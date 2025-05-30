using CaixaFacil.Application.Commands.PedidoCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CaixaFacil.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PedidoController : ControllerBase
{
    private readonly IMediator _mediator;

    public PedidoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CriarPedido([FromBody] InserirPedidoCommand command)
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
