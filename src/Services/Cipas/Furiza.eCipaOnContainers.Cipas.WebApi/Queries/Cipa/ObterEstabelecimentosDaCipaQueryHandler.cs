using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.Cipas.WebApi.Queries.Cipa
{
    internal class ObterEstabelecimentosDaCipaQueryHandler : IRequestHandler<ObterEstabelecimentosDaCipaQuery, ObterEstabelecimentosDaCipaQueryResult>
    {
        private readonly CipasQueryContext cipasQueryContext;

        public ObterEstabelecimentosDaCipaQueryHandler(CipasQueryContext cipasQueryContext)
        {
            this.cipasQueryContext = cipasQueryContext ?? throw new ArgumentNullException(nameof(cipasQueryContext));
        }

        public async Task<ObterEstabelecimentosDaCipaQueryResult> Handle(ObterEstabelecimentosDaCipaQuery request, CancellationToken cancellationToken)
        {
            var query = $@"
                select
                    eo.*, ec.[Id] RelId, ec.[Tipo]
                from
                    [{cipasQueryContext.DatabaseName}]..[Estabelecimentos] ec with(nolock)
                inner join
                    [{cipasQueryContext.OrganizacoesDatabaseName}]..[Estabelecimentos] eo with(nolock)
                    on ec.[EstabelecimentoId] = eo.[Id]
                where
                    ec.[CipaId] = @cipaId
                order by
					eo.[Codigo]";

            var queryResult = new ObterEstabelecimentosDaCipaQueryResult()
            {
                Estabelecimentos = await cipasQueryContext.QueryAsync<ObterEstabelecimentosDaCipaQueryResult.ObterEstabelecimentosDaCipaQueryResultInnerEstabelecimento>(query, new
                {
                    request.CipaId
                })
            };

            return queryResult;
        }
    }
}