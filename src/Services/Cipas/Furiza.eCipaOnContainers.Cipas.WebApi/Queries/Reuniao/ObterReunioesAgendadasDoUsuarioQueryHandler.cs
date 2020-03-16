using Furiza.eCipaOnContainers.Cipas.Domain.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.Cipas.WebApi.Queries.Reuniao
{
    internal class ObterReunioesAgendadasDoUsuarioQueryHandler : IRequestHandler<ObterReunioesAgendadasDoUsuarioQuery, ObterReunioesAgendadasDoUsuarioQueryResult>
    {
        private readonly CipasQueryContext cipasQueryContext;

        public ObterReunioesAgendadasDoUsuarioQueryHandler(CipasQueryContext cipasQueryContext)
        {
            this.cipasQueryContext = cipasQueryContext ?? throw new ArgumentNullException(nameof(cipasQueryContext));
        }

        public async Task<ObterReunioesAgendadasDoUsuarioQueryResult> Handle(ObterReunioesAgendadasDoUsuarioQuery request, CancellationToken cancellationToken)
        {
            var query = $@"
                select
                    r.[Id], r.[CipaId], r.[MesDeReferencia], r.[DataPrevista], r.[Local], r.[Status], r.[Extraordinaria]
                from
                    [{cipasQueryContext.DatabaseName}]..[Reunioes] r with(nolock)
                inner join
                    [{cipasQueryContext.DatabaseName}]..[Cipas] c with(nolock)
                    on r.[CipaId] = c.[Id]
                inner join
                    [{cipasQueryContext.DatabaseName}]..[Membros] m with(nolock)
                    on c.[Id] = m.[CipaId]
                where
                    r.[Status] not in @notStatusReuniao and c.[Status] = @statusCipa and m.[UserName] = @userName
                order by
					r.[DataPrevista]";

            var queryResult = new ObterReunioesAgendadasDoUsuarioQueryResult()
            {
                Reunioes = await cipasQueryContext.QueryAsync<ObterReunioesAgendadasDoUsuarioQueryResult.ObterReunioesAgendadasDoUsuarioQueryResultInnerReuniao>(query, new
                {
                    notStatusReuniao = new[] { StatusAgendamento.Realizado, StatusAgendamento.Cancelado },
                    statusCipa = StatusAtividade.Ativo,
                    request.UserName
                })
            };

            return queryResult;
        }
    }
}