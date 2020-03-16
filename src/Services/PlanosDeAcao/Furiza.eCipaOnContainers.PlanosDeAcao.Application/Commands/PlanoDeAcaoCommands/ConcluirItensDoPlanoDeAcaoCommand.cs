using Furiza.eCipaOnContainers.PlanosDeAcao.Domain.Models.PlanoDeAcaoAggregate;
using MediatR;

namespace Furiza.eCipaOnContainers.PlanosDeAcao.Application.Commands.PlanoDeAcaoCommands
{
    public class ConcluirItensDoPlanoDeAcaoCommand : IRequest
    {
        public PlanoDeAcao PlanoDeAcao { get; set; }
    }
}