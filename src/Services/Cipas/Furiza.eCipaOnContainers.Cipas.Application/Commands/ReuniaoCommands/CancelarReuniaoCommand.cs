using Furiza.eCipaOnContainers.Cipas.Domain.Models.ReuniaoAggregate;
using MediatR;

namespace Furiza.eCipaOnContainers.Cipas.Application.Commands.ReuniaoCommands
{
    public class CancelarReuniaoCommand : IRequest
    {
        public Reuniao Reuniao { get; set; }
    }
}