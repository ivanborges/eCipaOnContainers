using MediatR;
using System;

namespace Furiza.eCipaOnContainers.Cipas.WebApi.Queries.Cipa
{
    public class ObterCipaQuery : IRequest<ObterCipaQueryResult>
    {
        public Guid CipaId { get; set; }
    }
}