using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.Cipas.WebApi.Queries.Reuniao
{
    internal class ObterReuniaoQueryHandler : IRequestHandler<ObterReuniaoQuery, ObterReuniaoQueryResult>
    {
        private readonly CipasQueryContext cipasQueryContext;

        public ObterReuniaoQueryHandler(CipasQueryContext cipasQueryContext)
        {
            this.cipasQueryContext = cipasQueryContext ?? throw new ArgumentNullException(nameof(cipasQueryContext));
        }

        public async Task<ObterReuniaoQueryResult> Handle(ObterReuniaoQuery request, CancellationToken cancellationToken)
        {
            var query = $@"
                select
                    r.*, 
                    c.[Codigo] CipaCodigo,
                    a.[Id] AtaId, a.[CreationDate] AtaCreationDate, a.[CreationUser] AtaCreationUser, a.[Codigo], a.[CodigoCipa], a.[Numero], a.[Local], a.[Inicio], a.[Termino], a.[Status], a.[Finalizacao_Data], a.[Finalizacao_Ator], a.[Aprovacao_Data], a.[Aprovacao_Ator], a.[Fechamento_Data], a.[Fechamento_Ator],
                    p.[Id] ParticipanteId, p.[NomeCompleto] ParticipanteNomeCompleto, p.[Email] ParticipanteEmail, p.[PossuiConsentValido] ParticipantePossuiConsentValido, p.[EConvidado], p.[Organizacao], p.[Funcao],
                    au.[Id] AusenteId, au.[NomeCompleto] AusenteNomeCompleto, au.[Email] AusenteEmail, au.[Justificativa], au.[PossuiConsentValido] AusentePossuiConsentValido,
                    ass.[Id] AssuntoId, ass.[CreationDate] AssuntoCreationDate, ass.[CreationUser] AssuntoCreationUser, ass.[ClassificacaoDaInformacao], ass.[Tipo], ass.[Numero] AssuntoNumero, ass.[Descricao], ass.[Keywords], ass.[Versao]
                from
                    [{cipasQueryContext.DatabaseName}]..[Reunioes] r with(nolock)
                inner join
                    [{cipasQueryContext.DatabaseName}]..[Cipas] c with(nolock)
                    on r.[CipaId] = c.[Id]
                left join
                    [{cipasQueryContext.DatabaseName}]..[Atas] a with(nolock)
                    on r.[Id] = a.[ReuniaoId]
                left join
                    [{cipasQueryContext.DatabaseName}]..[Participantes] p with(nolock)
                    on a.[Id] = p.[AtaId]
                left join
                    [{cipasQueryContext.DatabaseName}]..[Ausentes] au with(nolock)
                    on a.[Id] = au.[AtaId]
                left join
                    [{cipasQueryContext.DatabaseName}]..[Assuntos] ass with(nolock)
                    on a.[Id] = ass.[AtaId]
                where
                    r.[Id] = @reuniaoId
                order by
					p.[NomeCompleto], au.[NomeCompleto], ass.[Numero]";

            var obterReuniaoQueryResultList = new List<ObterReuniaoQueryResult>();

            await cipasQueryContext
                .QueryAsync<ObterReuniaoQueryResult,
                ObterReuniaoQueryResult.ObterReuniaoQueryResultInnerAta,
                ObterReuniaoQueryResult.ObterReuniaoQueryResultInnerParticipante,
                ObterReuniaoQueryResult.ObterReuniaoQueryResultInnerAusente,
                ObterReuniaoQueryResult.ObterReuniaoQueryResultInnerAssunto>(query,
                    (reuniao, ata, participante, ausente, assunto) =>
                    {
                        var reuniaoOutput = obterReuniaoQueryResultList.FirstOrDefault(p => p.Id.Value == reuniao.Id.Value);
                        if (reuniaoOutput == null)
                        {
                            reuniaoOutput = reuniao;

                            obterReuniaoQueryResultList.Add(reuniaoOutput);
                        }

                        if (ata != null)
                        {
                            if (reuniaoOutput.Ata == null)
                            {
                                reuniaoOutput.Ata = ata;
                                reuniaoOutput.Ata.Participantes = new List<ObterReuniaoQueryResult.ObterReuniaoQueryResultInnerParticipante>();
                                reuniaoOutput.Ata.Ausentes = new List<ObterReuniaoQueryResult.ObterReuniaoQueryResultInnerAusente>();
                                reuniaoOutput.Ata.Assuntos = new List<ObterReuniaoQueryResult.ObterReuniaoQueryResultInnerAssunto>();
                            }

                            if (participante != null && !reuniaoOutput.Ata.Participantes.Any(p => p.ParticipanteId == participante.ParticipanteId))
                                reuniaoOutput.Ata.Participantes.Add(participante);

                            if (ausente != null && !reuniaoOutput.Ata.Ausentes.Any(a => a.AusenteId == ausente.AusenteId))
                                reuniaoOutput.Ata.Ausentes.Add(ausente);

                            if (assunto != null && !reuniaoOutput.Ata.Assuntos.Any(a => a.AssuntoId == assunto.AssuntoId))
                                reuniaoOutput.Ata.Assuntos.Add(assunto);
                        }

                        return reuniaoOutput;
                    },
                    param: new
                    {
                        request.ReuniaoId
                    },
                    splitOn: "AtaId,ParticipanteId,AusenteId,AssuntoId");

            return obterReuniaoQueryResultList.FirstOrDefault();
        }
    }
}