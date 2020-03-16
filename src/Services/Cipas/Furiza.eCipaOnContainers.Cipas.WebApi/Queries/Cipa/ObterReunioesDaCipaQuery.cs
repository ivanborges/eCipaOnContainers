using MediatR;
using System;

namespace Furiza.eCipaOnContainers.Cipas.WebApi.Queries.Cipa
{
    public class ObterReunioesDaCipaQuery : IRequest<ObterReunioesDaCipaQueryResult>
    {
        public Guid CipaId { get; set; }
    }
}