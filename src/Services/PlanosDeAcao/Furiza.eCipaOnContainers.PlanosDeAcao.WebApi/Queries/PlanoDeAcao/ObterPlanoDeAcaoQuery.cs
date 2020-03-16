using MediatR;
using System;

namespace Furiza.eCipaOnContainers.PlanosDeAcao.WebApi.Queries.PlanoDeAcao
{
    public class ObterPlanoDeAcaoQuery : IRequest<ObterPlanoDeAcaoQueryResult>
    {
        public Guid PlanoDeAcaoId { get; set; }
    }
}