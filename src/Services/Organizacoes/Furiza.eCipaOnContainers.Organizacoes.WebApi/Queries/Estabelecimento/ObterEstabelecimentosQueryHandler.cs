using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.Organizacoes.WebApi.Queries.Estabelecimento
{
    internal class ObterEstabelecimentosQueryHandler : IRequestHandler<ObterEstabelecimentosQuery, ObterEstabelecimentosQueryResult>
    {
        private readonly OrganizacoesQueryContext coreBusinessQueryContext;

        public ObterEstabelecimentosQueryHandler(OrganizacoesQueryContext coreBusinessQueryContext)
        {
            this.coreBusinessQueryContext = coreBusinessQueryContext ?? throw new ArgumentNullException(nameof(coreBusinessQueryContext));
        }

        public async Task<ObterEstabelecimentosQueryResult> Handle(ObterEstabelecimentosQuery request, CancellationToken cancellationToken)
        {
            var query = $@"
                select top (@quantidade)
                    e.*
                from
                    [{coreBusinessQueryContext.DatabaseName}]..[Estabelecimentos] e with(nolock)
                where
                    e.[Status] = @status";

            if (!string.IsNullOrWhiteSpace(request.Codigo))
                query += " and e.[Codigo] like @codigo";

            if (!string.IsNullOrWhiteSpace(request.Nome))
                query += " and e.[Nome] like @nome";

            query += @"
                order by
                    e.[CreationDate] desc";

            var queryResult = new ObterEstabelecimentosQueryResult()
            {
                Estabelecimentos = await coreBusinessQueryContext.QueryAsync<ObterEstabelecimentosQueryResult.ObterEstabelecimentosQueryResultInnerEstabelecimento>(query, new
                {
                    request.Quantidade,
                    request.Status,
                    codigo = $"%{request.Codigo}%",
                    nome = $"%{request.Nome}%"
                })
            };

            return queryResult;
        }
    }
}