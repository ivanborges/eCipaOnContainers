using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.Cipas.WebApi.Queries.Cipa
{
    internal class ObterCipasQueryHandler : IRequestHandler<ObterCipasQuery, ObterCipasQueryResult>
    {
        private readonly CipasQueryContext cipasQueryContext;

        public ObterCipasQueryHandler(CipasQueryContext cipasQueryContext)
        {
            this.cipasQueryContext = cipasQueryContext ?? throw new ArgumentNullException(nameof(cipasQueryContext));
        }

        public async Task<ObterCipasQueryResult> Handle(ObterCipasQuery request, CancellationToken cancellationToken)
        {
            var query = $@"
                select top (@quantidade)
                    *
                from
                    [{cipasQueryContext.DatabaseName}]..[Cipas] with(nolock)
                where
                    [Status] = @status";

            if (!string.IsNullOrWhiteSpace(request.Codigo))
                query += " and [Codigo] like @codigo";

            if (request.CodigoEmpresa.HasValue && request.CodigoEmpresa.Value > 0)
                query += " and [CodigoEmpresa] = @codigoEmpresa";

            query += @"
                order by
                    [CreationDate] desc";

            var queryResult = new ObterCipasQueryResult()
            {
                Cipas = await cipasQueryContext.QueryAsync<ObterCipasQueryResult.ObterCipasQueryResultInnerCipa>(query, new
                {
                    request.Status,
                    request.Quantidade,
                    codigo = $"%{request.Codigo}%",
                    request.CodigoEmpresa
                })
            };

            return queryResult;
        }
    }
}