using Furiza.eCipaOnContainers.Cipas.Domain.Models.CipaAggregate;
using MediatR;

namespace Furiza.eCipaOnContainers.Cipas.Application.Commands.CipaCommands
{
    public class AlternarStatusDeAtividadeDaCipaCommand : IRequest
    {
        public Cipa Cipa { get; set; }
    }
}