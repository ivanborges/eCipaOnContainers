using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.Organizacoes.WebApi.Queries.Estabelecimento
{
    internal class ObterCipasDoEstabelecimentoQueryHandler : IRequestHandler<ObterCipasDoEstabelecimentoQuery, ObterCipasDoEstabelecimentoQueryResult>
    {
        private readonly OrganizacoesQueryContext organizacoesQueryContext;

        public ObterCipasDoEstabelecimentoQueryHandler(OrganizacoesQueryContext organizacoesQueryContext)
        {
            this.organizacoesQueryContext = organizacoesQueryContext ?? throw new ArgumentNullException(nameof(organizacoesQueryContext));
        }

        public async Task<ObterCipasDoEstabelecimentoQueryResult> Handle(ObterCipasDoEstabelecimentoQuery request, CancellationToken cancellationToken)
        {
            var query = $@"
                select
                    c.[Id], c.[Codigo], c.[CreationDate], c.[Status]
                from
                    [{organizacoesQueryContext.CipasDatabaseName}]..[Cipas] c with(nolock)
                inner join
                    [{organizacoesQueryContext.CipasDatabaseName}]..[Estabelecimentos] ec with(nolock)
                    on c.[Id] = ec.[CipaId]
                where
                    ec.[EstabelecimentoId] = @estabelecimentoId
                order by
					c.[CreationDate] desc";

            var queryResult = new ObterCipasDoEstabelecimentoQueryResult()
            {
                Cipas = await organizacoesQueryContext.QueryAsync<ObterCipasDoEstabelecimentoQueryResult.ObterCipasDoEstabelecimentoQueryResultInnerCipa>(query, new
                {
                    request.EstabelecimentoId
                })
            };

            return queryResult;
        }
    }
}