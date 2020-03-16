using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.Cipas.WebApi.Queries.Cipa
{
    internal class ObterCipaQueryHandler : IRequestHandler<ObterCipaQuery, ObterCipaQueryResult>
    {
        private readonly CipasQueryContext cipasQueryContext;

        public ObterCipaQueryHandler(CipasQueryContext cipasQueryContext)
        {
            this.cipasQueryContext = cipasQueryContext ?? throw new ArgumentNullException(nameof(cipasQueryContext));
        }

        public async Task<ObterCipaQueryResult> Handle(ObterCipaQuery request, CancellationToken cancellationToken)
        {
            var query = $@"
                select
                    *
                from
                    [{cipasQueryContext.DatabaseName}]..[Cipas] with(nolock)
                where
                    [Id] = @cipaId";

            var queryResult = (await cipasQueryContext.QueryAsync<ObterCipaQueryResult>(query, new
            {
                request.CipaId
            })).FirstOrDefault();

            if (queryResult != null)
            {
                query = $@"
                    select
                        [Id] MembroId, [UserName], [NomeCompleto], [Funcao]
                    from
                        [{cipasQueryContext.DatabaseName}]..[Membros] with(nolock)
                    where
                        [CipaId] = @cipaId
                    order by
                        [UserName]";

                queryResult.Membros = await cipasQueryContext.QueryAsync<ObterCipaQueryResult.ObterCipaQueryResultInnerMembro>(query, new
                {
                    request.CipaId
                });
            }

            return queryResult;
        }
    }
}