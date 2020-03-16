using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.Organizacoes.WebApi.Queries.Estabelecimento
{
    internal class ObterEstabelecimentoQueryHandler : IRequestHandler<ObterEstabelecimentoQuery, ObterEstabelecimentoQueryResult>
    {
        private readonly OrganizacoesQueryContext coreBusinessQueryContext;

        public ObterEstabelecimentoQueryHandler(OrganizacoesQueryContext coreBusinessQueryContext)
        {
            this.coreBusinessQueryContext = coreBusinessQueryContext ?? throw new ArgumentNullException(nameof(coreBusinessQueryContext));
        }

        public async Task<ObterEstabelecimentoQueryResult> Handle(ObterEstabelecimentoQuery request, CancellationToken cancellationToken)
        {
            var query = $@"
                select
                    e.*
                from
                    [{coreBusinessQueryContext.DatabaseName}]..[Estabelecimentos] e with(nolock)
                where
                    e.[Id] = @estabelecimentoId";

            var queryResult = (await coreBusinessQueryContext.QueryAsync<ObterEstabelecimentoQueryResult>(query, new
            {
                request.EstabelecimentoId
            })).FirstOrDefault();

            return queryResult;
        }
    }
}