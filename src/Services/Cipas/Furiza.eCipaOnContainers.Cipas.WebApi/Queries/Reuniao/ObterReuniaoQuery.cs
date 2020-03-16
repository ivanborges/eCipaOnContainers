using MediatR;
using System;

namespace Furiza.eCipaOnContainers.Cipas.WebApi.Queries.Reuniao
{
    public class ObterReuniaoQuery : IRequest<ObterReuniaoQueryResult>
    {
        public Guid ReuniaoId { get; set; }
    }
}