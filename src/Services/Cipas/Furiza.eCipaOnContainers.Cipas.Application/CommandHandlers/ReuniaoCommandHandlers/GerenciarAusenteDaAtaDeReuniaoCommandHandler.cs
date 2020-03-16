using Furiza.Audit.Abstractions;
using Furiza.Base.Core.Identity.Abstractions;
using MediatR;
using Furiza.eCipaOnContainers.Cipas.Application.Commands.ReuniaoCommands;
using Furiza.eCipaOnContainers.Cipas.Domain.Exceptions;
using Furiza.eCipaOnContainers.Cipas.Domain.Models.ReuniaoAggregate;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.Cipas.Application.CommandHandlers.ReuniaoCommandHandlers
{
    internal class GerenciarAusenteDaAtaDeReuniaoCommandHandler : IRequestHandler<AdicionarAusenteAAtaDeReuniaoCommand>,
        IRequestHandler<RemoverAusenteDaAtaDeReuniaoCommand>,
        IRequestHandler<DarConsentDoAusenteDaAtaDeReuniaoCommand>,
        IRequestHandler<AtualizarAusenteDaAtaDeReuniaoCommand>
    {
        private readonly IUserPrincipalBuilder userPrincipalBuilder;
        private readonly IReuniaoWriteOnlyRepository reuniaoWriteOnlyRepository;
        private readonly IAuditTrailProvider auditTrailProvider;

        public GerenciarAusenteDaAtaDeReuniaoCommandHandler(IUserPrincipalBuilder userPrincipalBuilder,
            IReuniaoWriteOnlyRepository reuniaoWriteOnlyRepository,
            IAuditTrailProvider auditTrailProvider)
        {
            this.userPrincipalBuilder = userPrincipalBuilder ?? throw new ArgumentNullException(nameof(userPrincipalBuilder));
            this.reuniaoWriteOnlyRepository = reuniaoWriteOnlyRepository ?? throw new ArgumentNullException(nameof(reuniaoWriteOnlyRepository));
            this.auditTrailProvider = auditTrailProvider ?? throw new ArgumentNullException(nameof(auditTrailProvider));
        }

        public async Task<Unit> Handle(AdicionarAusenteAAtaDeReuniaoCommand request, CancellationToken cancellationToken)
        {
            if (request.Reuniao.Ata == null)
                throw new AtaDeReuniaoAindaNaoGeradaException();

            if (request.Reuniao.Ata.Id != request.AtaId)
                throw new AtaDeReuniaoInvalidaException();

            request.Reuniao.Ata.AdicionarAusente(request.NomeCompleto, request.Email, request.Justificativa);

            return await ProcederComAAtualizacaoDaReuniaoAsync(request.Reuniao);
        }

        public async Task<Unit> Handle(AtualizarAusenteDaAtaDeReuniaoCommand request, CancellationToken cancellationToken)
        {
            if (request.Reuniao.Ata == null)
                throw new AtaDeReuniaoAindaNaoGeradaException();

            if (request.Reuniao.Ata.Id != request.AtaId)
                throw new AtaDeReuniaoInvalidaException();

            request.Reuniao.Ata.ObterAusente(request.AusenteId).DefinirNovaJustificativa(request.Reuniao.Ata.Status, request.Justificativa);

            return await ProcederComAAtualizacaoDaReuniaoAsync(request.Reuniao);
        }

        public async Task<Unit> Handle(RemoverAusenteDaAtaDeReuniaoCommand request, CancellationToken cancellationToken)
        {
            if (request.Reuniao.Ata == null)
                throw new AtaDeReuniaoAindaNaoGeradaException();

            if (request.Reuniao.Ata.Id != request.AtaId)
                throw new AtaDeReuniaoInvalidaException();

            request.Reuniao.Ata.RemoverAusente(request.AusenteId);

            return await ProcederComAAtualizacaoDaReuniaoAsync(request.Reuniao);
        }

        public async Task<Unit> Handle(DarConsentDoAusenteDaAtaDeReuniaoCommand request, CancellationToken cancellationToken)
        {
            if (request.Reuniao.Ata == null)
                throw new AtaDeReuniaoAindaNaoGeradaException();

            if (request.Reuniao.Ata.Id != request.AtaId)
                throw new AtaDeReuniaoInvalidaException();

            var ausente = request.Reuniao.Ata.ObterAusente(request.AusenteId);

            if (ausente.Email.ToLower() != userPrincipalBuilder.UserPrincipal.Email.ToLower())
                throw new ViolacaoDeConsentException();

            ausente.DarConsent(request.Reuniao.Ata.Status, request.Value, request.Justificativa);

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