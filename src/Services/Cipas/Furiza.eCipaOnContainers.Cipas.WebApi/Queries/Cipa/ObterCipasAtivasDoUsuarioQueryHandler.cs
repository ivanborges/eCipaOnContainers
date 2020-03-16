using Furiza.eCipaOnContainers.Cipas.Domain.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.Cipas.WebApi.Queries.Cipa
{
    internal class ObterCipasAtivasDoUsuarioQueryHandler : IRequestHandler<ObterCipasAtivasDoUsuarioQuery, ObterCipasAtivasDoUsuarioQueryResult>
    {
        private readonly CipasQueryContext cipasQueryContext;

        public ObterCipasAtivasDoUsuarioQueryHandler(CipasQueryContext cipasQueryContext)
        {
            this.cipasQueryContext = cipasQueryContext ?? throw new ArgumentNullException(nameof(cipasQueryContext));
        }

        public async Task<ObterCipasAtivasDoUsuarioQueryResult> Handle(ObterCipasAtivasDoUsuarioQuery request, CancellationToken cancellationToken)
        {
            var query = $@"
                select
                    c.[Id], c.[Codigo], c.[Mandato_Inicio], c.[Mandato_Termino], c.[CodigoEmpresa]
                from
                    [{cipasQueryContext.DatabaseName}]..[Cipas] c with(nolock)
                inner join
                    [{cipasQueryContext.DatabaseName}]..[Membros] m with(nolock)
                    on c.[Id] = m.[CipaId]
                where
                    c.[Status] = @status and m.[UserName] = @userName
                order by
                    c.[Codigo]";

            var queryResult = new ObterCipasAtivasDoUsuarioQueryResult()
            {
                Cipas = await cipasQueryContext.QueryAsync<ObterCipasAtivasDoUsuarioQueryResult.ObterCipasAtivasDoUsuarioQueryResultInnerCipa>(query, new
                {
                    status = StatusAtividade.Ativo,
                    request.UserName
                })
            };

            return queryResult;
        }
    }
}