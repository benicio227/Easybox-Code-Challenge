using CaixaFacil.Application.Commands.ProdutoCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CaixaFacil.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutoController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProdutoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CriarProduto([FromBody] InserirProdutoCommand command)
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
