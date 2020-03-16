using MediatR;
using System;

namespace Furiza.eCipaOnContainers.Organizacoes.WebApi.Queries.Estabelecimento
{
    public class ObterEstabelecimentoQuery : IRequest<ObterEstabelecimentoQueryResult>
    {
        public Guid EstabelecimentoId { get; set; }
    }
}