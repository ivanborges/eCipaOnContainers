using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.Cipas.WebApi.Queries.Reuniao
{
    internal class ObterConsentsDoParticipanteQueryHandler : IRequestHandler<ObterConsentsDoParticipanteQuery, ObterConsentsDoParticipanteQueryResult>
    {
        private readonly CipasQueryContext cipasQueryContext;

        public ObterConsentsDoParticipanteQueryHandler(CipasQueryContext cipasQueryContext)
        {
            this.cipasQueryContext = cipasQueryContext ?? throw new ArgumentNullException(nameof(cipasQueryContext));
        }

        public async Task<ObterConsentsDoParticipanteQueryResult> Handle(ObterConsentsDoParticipanteQuery request, CancellationToken cancellationToken)
        {
            var query = $@"
                select
                    *
                from
                    [{cipasQueryContext.DatabaseName}]..[ConsentsDeParticipantes] with(nolock)
                where
                    [ParticipanteId] = @participanteId
                order by
					[CreationDate] desc";

            var queryResult = new ObterConsentsDoParticipanteQueryResult()
            {
                Consents = await cipasQueryContext.QueryAsync<ObterConsentsDoParticipanteQueryResult.ObterConsentsDoParticipanteQueryResultInnerConsent>(query, new
                {
                    request.ParticipanteId
                })
            };

            return queryResult;
        }
    }
}