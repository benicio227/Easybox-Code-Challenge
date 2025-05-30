using CaixaFacil.Application.Commands.LoginCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CaixaFacil.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    private readonly IMediator _mediator;

    public LoginController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] InserirLoginCommand command)
    {
        try
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        catch (Exception ex)
        {
        
            return Unauthorized(new { message = ex.Message });
        }
    }
}
