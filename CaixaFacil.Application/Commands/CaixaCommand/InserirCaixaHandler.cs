using CaixaFacil.Core.Entities;
using CaixaFacil.Core.Repositories;
using MediatR;

namespace CaixaFacil.Application.Commands.CaixaCommand;

public class CriarCaixaHandler : IRequestHandler<InserirCaixaCommand, int>
{
    private readonly ICaixaRepository _caixaRepository;

    public CriarCaixaHandler(ICaixaRepository caixaRepository)
    {
        _caixaRepository = caixaRepository;
    }

    public async Task<int> Handle(InserirCaixaCommand request, CancellationToken cancellationToken)
    {
        var caixa = new Caixa
        {
            Id = request.Id,
            Name = request.Name,
            Altura = request.Altura,
            Largura = request.Largura,
            Comprimento = request.Comprimento
        };

        await _caixaRepository.Add(caixa);
        return caixa.Id;
    }
}
