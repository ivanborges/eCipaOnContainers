using Furiza.eCipaOnContainers.Cipas.Domain.Models.ReuniaoAggregate;
using MediatR;
using System;

namespace Furiza.eCipaOnContainers.Cipas.Application.Commands.ReuniaoCommands
{
    public class AdicionarParticipanteConvidadoAAtaDeReuniaoCommand : IRequest
    {
        public Reuniao Reuniao { get; set; }
        public Guid AtaId { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public string Organizacao { get; set; }
        public string Funcao { get; set; }
    }
}