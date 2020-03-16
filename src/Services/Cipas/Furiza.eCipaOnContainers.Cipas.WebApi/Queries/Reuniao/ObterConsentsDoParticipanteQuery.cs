using MediatR;
using System;

namespace Furiza.eCipaOnContainers.Cipas.WebApi.Queries.Reuniao
{
    public class ObterConsentsDoParticipanteQuery : IRequest<ObterConsentsDoParticipanteQueryResult>
    {
        public Guid ReuniaoId { get; set; }
        public Guid AtaId { get; set; }
        public Guid ParticipanteId { get; set; }
    }
}