using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.Cipas.WebApi.Queries.Reuniao
{
    internal class ObterConsentsDoAusenteQueryHandler : IRequestHandler<ObterConsentsDoAusenteQuery, ObterConsentsDoAusenteQueryResult>
    {
        private readonly CipasQueryContext cipasQueryContext;

        public ObterConsentsDoAusenteQueryHandler(CipasQueryContext cipasQueryContext)
        {
            this.cipasQueryContext = cipasQueryContext ?? throw new ArgumentNullException(nameof(cipasQueryContext));
        }

        public async Task<ObterConsentsDoAusenteQueryResult> Handle(ObterConsentsDoAusenteQuery request, CancellationToken cancellationToken)
        {
            var query = $@"
                select
                    *
                from
                    [{cipasQueryContext.DatabaseName}]..[ConsentsDeAusentes] with(nolock)
                where
                    [AusenteId] = @ausenteId
                order by
					[CreationDate] desc";

            var queryResult = new ObterConsentsDoAusenteQueryResult()
            {
                Consents = await cipasQueryContext.QueryAsync<ObterConsentsDoAusenteQueryResult.ObterConsentsDoAusenteQueryResultInnerConsent>(query, new
                {
                    request.AusenteId
                })
            };

            return queryResult;
        }
    }
}