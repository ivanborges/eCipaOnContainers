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
    internal class GerenciarMembroDaCipaCommandHandler : IRequestHandler<AdicionarMembroACipaCommand>,
        IRequestHandler<RemoverMembroDaCipaCommand>
    {
        private readonly IUserPrincipalBuilder userPrincipalBuilder;
        private readonly ICipaWriteOnlyRepository cipaWriteOnlyRepository;
        private readonly IAuditTrailProvider auditTrailProvider;

        public GerenciarMembroDaCipaCommandHandler(IUserPrincipalBuilder userPrincipalBuilder,
            ICipaWriteOnlyRepository cipaWriteOnlyRepository,
            IAuditTrailProvider auditTrailProvider)
        {
            this.userPrincipalBuilder = userPrincipalBuilder ?? throw new ArgumentNullException(nameof(userPrincipalBuilder));
            this.cipaWriteOnlyRepository = cipaWriteOnlyRepository ?? throw new ArgumentNullException(nameof(cipaWriteOnlyRepository));
            this.auditTrailProvider = auditTrailProvider ?? throw new ArgumentNullException(nameof(auditTrailProvider));
        }

        public async Task<Unit> Handle(AdicionarMembroACipaCommand request, CancellationToken cancellationToken)
        {
            request.Cipa.AdicionarMembro(request.UserName, request.NomeCompleto, request.Funcao);

            return await ProcederComAAtualizacaoDaCipaAsync(request.Cipa);
        }

        public async Task<Unit> Handle(RemoverMembroDaCipaCommand request, CancellationToken cancellationToken)
        {
            request.Cipa.RemoverMembro(request.MembroId);

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