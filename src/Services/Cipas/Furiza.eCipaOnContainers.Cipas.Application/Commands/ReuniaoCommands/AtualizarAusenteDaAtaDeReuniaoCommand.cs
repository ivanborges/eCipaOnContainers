using MediatR;
using Furiza.eCipaOnContainers.Cipas.Domain.Models.ReuniaoAggregate;
using System;

namespace Furiza.eCipaOnContainers.Cipas.Application.Commands.ReuniaoCommands
{
    public class AtualizarAusenteDaAtaDeReuniaoCommand : IRequest
    {
        public Reuniao Reuniao { get; set; }
        public Guid AtaId { get; set; }
        public Guid AusenteId { get; set; }
        public JustificativaAusencia Justificativa { get; set; }
    }
}