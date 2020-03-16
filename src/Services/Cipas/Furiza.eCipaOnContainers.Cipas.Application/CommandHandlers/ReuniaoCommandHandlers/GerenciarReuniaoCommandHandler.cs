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
    internal class GerenciarReuniaoCommandHandler : IRequestHandler<AtualizarReuniaoCommand>,
        IRequestHandler<CancelarReuniaoCommand>,
        IRequestHandler<DefinirPlanoDeAcaoDaReuniaoCommand>,
        IRequestHandler<RemoverPlanoDeAcaoDaReuniaoCommand>
    {
        private readonly IUserPrincipalBuilder userPrincipalBuilder;
        private readonly IReuniaoWriteOnlyRepository reuniaoWriteOnlyRepository;
        private readonly IAuditTrailProvider auditTrailProvider;

        public GerenciarReuniaoCommandHandler(IUserPrincipalBuilder userPrincipalBuilder,
            IReuniaoWriteOnlyRepository reuniaoWriteOnlyRepository,
            IAuditTrailProvider auditTrailProvider)
        {
            this.userPrincipalBuilder = userPrincipalBuilder ?? throw new ArgumentNullException(nameof(userPrincipalBuilder));
            this.reuniaoWriteOnlyRepository = reuniaoWriteOnlyRepository ?? throw new ArgumentNullException(nameof(reuniaoWriteOnlyRepository));
            this.auditTrailProvider = auditTrailProvider ?? throw new ArgumentNullException(nameof(auditTrailProvider));
        }

        public async Task<Unit> Handle(AtualizarReuniaoCommand request, CancellationToken cancellationToken)
        {
            request.Reuniao.DefinirNovoMesDeReferencia(request.MesDeReferencia);

            if (request.Reuniao.DataPrevista != request.DataPrevista)
                request.Reuniao.DefinirNovaPrevisao(request.DataPrevista);

            request.Reuniao.DefinirNovoLocal(request.Local);

            return await ProcederComAAtualizacaoDaReuniaoAsync(request.Reuniao);
        }

        public async Task<Unit> Handle(CancelarReuniaoCommand request, CancellationToken cancellationToken)
        {
            request.Reuniao.Cancelar();

            return await ProcederComAAtualizacaoDaReuniaoAsync(request.Reuniao);
        }

        public async Task<Unit> Handle(DefinirPlanoDeAcaoDaReuniaoCommand request, CancellationToken cancellationToken)
        {
            request.Reuniao.DefinirPlanoDeAcao(request.PlanoDeAcaoId);

            return await ProcederComAAtualizacaoDaReuniaoAsync(request.Reuniao);
        }

        public async Task<Unit> Handle(RemoverPlanoDeAcaoDaReuniaoCommand request, CancellationToken cancellationToken)
        {
            if (request.Reuniao.PlanoDeAcaoId != request.PlanoDeAcaoId)
                throw new PlanoDeAcaoInvalidoException();

            request.Reuniao.DefinirPlanoDeAcao(null);

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