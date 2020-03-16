using Furiza.eCipaOnContainers.Cipas.Domain.Models.ReuniaoAggregate;
using MediatR;
using System;

namespace Furiza.eCipaOnContainers.Cipas.Application.Commands.ReuniaoCommands
{
    public class DefinirPlanoDeAcaoDaReuniaoCommand : IRequest
    {
        public Reuniao Reuniao { get; set; }
        public Guid PlanoDeAcaoId { get; set; }
    }
}