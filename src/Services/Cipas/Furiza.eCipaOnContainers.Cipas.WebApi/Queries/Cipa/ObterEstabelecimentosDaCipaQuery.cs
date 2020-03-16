using MediatR;
using System;

namespace Furiza.eCipaOnContainers.Cipas.WebApi.Queries.Cipa
{
    public class ObterEstabelecimentosDaCipaQuery : IRequest<ObterEstabelecimentosDaCipaQueryResult>
    {
        public Guid CipaId { get; set; }
    }
}