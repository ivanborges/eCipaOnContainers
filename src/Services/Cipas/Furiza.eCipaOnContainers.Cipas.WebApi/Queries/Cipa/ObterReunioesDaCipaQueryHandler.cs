using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.Cipas.WebApi.Queries.Cipa
{
    internal class ObterReunioesDaCipaQueryHandler : IRequestHandler<ObterReunioesDaCipaQuery, ObterReunioesDaCipaQueryResult>
    {
        private readonly CipasQueryContext cipasQueryContext;

        public ObterReunioesDaCipaQueryHandler(CipasQueryContext cipasQueryContext)
        {
            this.cipasQueryContext = cipasQueryContext ?? throw new ArgumentNullException(nameof(cipasQueryContext));
        }

        public async Task<ObterReunioesDaCipaQueryResult> Handle(ObterReunioesDaCipaQuery request, CancellationToken cancellationToken)
        {
            var query = $@"
                select
                    * 
                from
                    [{cipasQueryContext.DatabaseName}]..[Reunioes] with(nolock)
                where
                    [CipaId] = @cipaId
                order by
					[DataPrevista]";

            var queryResult = new ObterReunioesDaCipaQueryResult()
            {
                Reunioes = await cipasQueryContext.QueryAsync<ObterReunioesDaCipaQueryResult.ObterReunioesDaCipaQueryResultInnerReuniao>(query, new
                {
                    request.CipaId
                })
            };

            return queryResult;
        }
    }
}