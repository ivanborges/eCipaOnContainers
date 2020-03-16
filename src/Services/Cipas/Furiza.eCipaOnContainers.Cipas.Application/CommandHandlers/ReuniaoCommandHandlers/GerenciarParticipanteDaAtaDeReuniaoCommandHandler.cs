using Furiza.eCipaOnContainers.Cipas.Application.Commands.ReuniaoCommands;
using Furiza.eCipaOnContainers.Cipas.Domain.Exceptions;
using Furiza.eCipaOnContainers.Cipas.Domain.Models.ReuniaoAggregate;
using Furiza.Audit.Abstractions;
using Furiza.Base.Core.Identity.Abstractions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.Cipas.Application.CommandHandlers.ReuniaoCommandHandlers
{
    internal class GerenciarParticipanteDaAtaDeReuniaoCommandHandler : IRequestHandler<AdicionarParticipanteAAtaDeReuniaoCommand>,
        IRequestHandler<AdicionarParticipanteConvidadoAAtaDeReuniaoCommand>,
        IRequestHandler<RemoverParticipanteDaAtaDeReuniaoCommand>,
        IRequestHandler<DarConsentDoParticipanteDaAtaDeReuniaoCommand>
    {
        private readonly IUserPrincipalBuilder userPrincipalBuilder;
        private readonly IReuniaoWriteOnlyRepository reuniaoWriteOnlyRepository;
        private readonly IAuditTrailProvider auditTrailProvider;

        public GerenciarParticipanteDaAtaDeReuniaoCommandHandler(IUserPrincipalBuilder userPrincipalBuilder,
            IReuniaoWriteOnlyRepository reuniaoWriteOnlyRepository,
            IAuditTrailProvider auditTrailProvider)
        {
            this.userPrincipalBuilder = userPrincipalBuilder ?? throw new ArgumentNullException(nameof(userPrincipalBuilder));
            this.reuniaoWriteOnlyRepository = reuniaoWriteOnlyRepository ?? throw new ArgumentNullException(nameof(reuniaoWriteOnlyRepository));
            this.auditTrailProvider = auditTrailProvider ?? throw new ArgumentNullException(nameof(auditTrailProvider));
        }
        
        public async Task<Unit> Handle(AdicionarParticipanteAAtaDeReuniaoCommand request, CancellationToken cancellationToken)
        {
            if (request.Reuniao.Ata == null)
                throw new AtaDeReuniaoAindaNaoGeradaException();

            if (request.Reuniao.Ata.Id != request.AtaId)
                throw new AtaDeReuniaoInvalidaException();

            request.Reuniao.Ata.AdicionarParticipante(request.NomeCompleto, request.Email);

            return await ProcederComAAtualizacaoDaReuniaoAsync(request.Reuniao);
        }

        public async Task<Unit> Handle(AdicionarParticipanteConvidadoAAtaDeReuniaoCommand request, CancellationToken cancellationToken)
        {
            if (request.Reuniao.Ata == null)
                throw new AtaDeReuniaoAindaNaoGeradaException();

            if (request.Reuniao.Ata.Id != request.AtaId)
                throw new AtaDeReuniaoInvalidaException();

            request.Reuniao.Ata.AdicionarParticipanteConvidado(request.NomeCompleto, request.Email, request.Organizacao, request.Funcao);

            return await ProcederComAAtualizacaoDaReuniaoAsync(request.Reuniao);
        }

        public async Task<Unit> Handle(RemoverParticipanteDaAtaDeReuniaoCommand request, CancellationToken cancellationToken)
        {
            if (request.Reuniao.Ata == null)
                throw new AtaDeReuniaoAindaNaoGeradaException();

            if (request.Reuniao.Ata.Id != request.AtaId)
                throw new AtaDeReuniaoInvalidaException();

            request.Reuniao.Ata.RemoverParticipante(request.ParticipanteId);

            return await ProcederComAAtualizacaoDaReuniaoAsync(request.Reuniao);
        }

        public async Task<Unit> Handle(DarConsentDoParticipanteDaAtaDeReuniaoCommand request, CancellationToken cancellationToken)
        {
            if (request.Reuniao.Ata == null)
                throw new AtaDeReuniaoAindaNaoGeradaException();

            if (request.Reuniao.Ata.Id != request.AtaId)
                throw new AtaDeReuniaoInvalidaException();

            var participante = request.Reuniao.Ata.ObterParticipante(request.ParticipanteId);

            if (participante.Email.ToLower() != userPrincipalBuilder.UserPrincipal.Email.ToLower())
                throw new ViolacaoDeConsentException();

            participante.DarConsent(request.Reuniao.Ata.Status, request.Value, request.Justificativa);

            var consentFavoravel = request.Value;
            if (consentFavoravel && !request.Reuniao.Ata.PossuiAlgumaPendencia())
                request.Reuniao.Ata.Fechar(userPrincipalBuilder.UserPrincipal.UserName);

            return await ProcederComAAtualizacaoDaReuniaoAsync(request.Reuniao);
        }

        #region [+] Privates
        private async Task<Unit> ProcederComAAtualizacaoDaReuniaoAsync(Reuniao reuniao)
        {
            reuniaoWriteOnlyRepository.Update(reuniao);

            await reuniaoWriteOnlyRepository.UnitOfWork.SaveEntitiesAsync();

            await auditTrailProvider.AddTrailsAsync(AuditOperation.Update, userPrincipalBuilder.UserPrincipal.UserName, new AuditableObjects<Reuniao>(reuniao.Id.ToString(), reuniao));

            return Unit.Value;
        }
        #endregion
    }
}