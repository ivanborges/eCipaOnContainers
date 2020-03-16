using Furiza.eCipaOnContainers.Cipas.Domain.Models.ReuniaoAggregate;
using MediatR;
using System;

namespace Furiza.eCipaOnContainers.Cipas.Application.Commands.ReuniaoCommands
{
    public class AprovarAtaDeReuniaoCommand : IRequest
    {
        public Reuniao Reuniao { get; set; }
        public Guid AtaId { get; set; }
    }
}