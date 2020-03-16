using MediatR;
using System;

namespace Furiza.eCipaOnContainers.Cipas.WebApi.Queries.Reuniao
{
    public class ObterConsentsDoAusenteQuery : IRequest<ObterConsentsDoAusenteQueryResult>
    {
        public Guid ReuniaoId { get; set; }
        public Guid AtaId { get; set; }
        public Guid AusenteId { get; set; }
    }
}