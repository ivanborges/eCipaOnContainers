using MediatR;
using System;

namespace Furiza.eCipaOnContainers.Organizacoes.WebApi.Queries.Estabelecimento
{
    public class ObterCipasDoEstabelecimentoQuery : IRequest<ObterCipasDoEstabelecimentoQueryResult>
    {
        public Guid EstabelecimentoId { get; set; }
    }
}