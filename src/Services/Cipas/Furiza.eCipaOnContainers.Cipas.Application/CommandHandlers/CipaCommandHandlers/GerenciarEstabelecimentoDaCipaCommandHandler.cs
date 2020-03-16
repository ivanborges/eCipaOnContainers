using Furiza.Audit.Abstractions;
using Furiza.Base.Core.Identity.Abstractions;
using MediatR;
using Furiza.eCipaOnContainers.Cipas.Application.Commands.CipaCommands;
using Furiza.eCipaOnContainers.Cipas.Domain.Models.CipaAggregate;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.Cipas.Application.CommandHandlers.CipaCommandHandlers
{
    internal class GerenciarEstabelecimentoDaCipaCommandHandler : IRequestHandler<AdicionarEstabelecimentoACipaCommand>,
        IRequestHandler<RemoverEstabelecimentoDaCipaCommand>
    {
        private readonly IUserPrincipalBuilder userPrincipalBuilder;
        private readonly ICipaWriteOnlyRepository cipaWriteOnlyRepository;
        private readonly IAuditTrailProvider auditTrailProvider;

        public GerenciarEstabelecimentoDaCipaCommandHandler(IUserPrincipalBuilder userPrincipalBuilder,
            ICipaWriteOnlyRepository cipaWriteOnlyRepository,
            IAuditTrailProvider auditTrailProvider)
        {
            this.userPrincipalBuilder = userPrincipalBuilder ?? throw new ArgumentNullException(nameof(userPrincipalBuilder));
            this.cipaWriteOnlyRepository = cipaWriteOnlyRepository ?? throw new ArgumentNullException(nameof(cipaWriteOnlyRepository));
            this.auditTrailProvider = auditTrailProvider ?? throw new ArgumentNullException(nameof(auditTrailProvider));
        }

        public async Task<Unit> Handle(AdicionarEstabelecimentoACipaCommand request, CancellationToken cancellationToken)
        {
            request.Cipa.AdicionarEstabelecimento(request.EstabelecimentoId, request.Tipo);

            return await ProcederComAAtualizacaoDaCipaAsync(request.Cipa);
        }

        public async Task<Unit> Handle(RemoverEstabelecimentoDaCipaCommand request, CancellationToken cancellationToken)
        {
            request.Cipa.RemoverEstabelecimento(request.EstabelecimentoId);

            return await ProcederComAAtualizacaoDaCipaAsync(request.Cipa);
        }

        #region [+] Privates
        private async Task<Unit> ProcederComAAtualizacaoDaCipaAsync(Cipa cipa)
        {
            cipaWriteOnlyRepository.Update(cipa);

            await cipaWriteOnlyRepository.UnitOfWork.SaveEntitiesAsync();

            await auditTrailProvider.AddTrailsAsync(AuditOperation.Update, userPrincipalBuilder.UserPrincipal.UserName, new AuditableObjects<Cipa>(cipa.Id.ToString(), cipa));

            return Unit.Value;
        }
        #endregion
    }
}