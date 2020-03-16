using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.Cipas.WebApi.Queries.Reuniao
{
    internal class ObterAlteracoesDoAssuntoQueryHandler : IRequestHandler<ObterAlteracoesDoAssuntoQuery, ObterAlteracoesDoAssuntoQueryResult>
    {
        private readonly CipasQueryContext cipasQueryContext;

        public ObterAlteracoesDoAssuntoQueryHandler(CipasQueryContext cipasQueryContext)
        {
            this.cipasQueryContext = cipasQueryContext ?? throw new ArgumentNullException(nameof(cipasQueryContext));
        }

        public async Task<ObterAlteracoesDoAssuntoQueryResult> Handle(ObterAlteracoesDoAssuntoQuery request, CancellationToken cancellationToken)
        {
            var query = $@"
                select
                    *
                from
                    [{cipasQueryContext.DatabaseName}]..[Alteracoes] with(nolock)
                where
                    [AssuntoId] = @assuntoId
                order by
					[CreationDate] desc";

            var queryResult = new ObterAlteracoesDoAssuntoQueryResult()
            {
                Alteracoes = await cipasQueryContext.QueryAsync<ObterAlteracoesDoAssuntoQueryResult.ObterAlteracoesDoAssuntoQueryResultInnerAlteracao>(query, new
                {
                    request.AssuntoId
                })
            };

            return queryResult;
        }
    }
}