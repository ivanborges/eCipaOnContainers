using Furiza.eCipaOnContainers.Cipas.Application.Commands;
using Furiza.eCipaOnContainers.Cipas.Application.Commands.CipaCommands;
using Furiza.eCipaOnContainers.Cipas.Domain.Models.CipaAggregate;
using Furiza.eCipaOnContainers.Cipas.Domain.ValueObjects;
using Furiza.Audit.Abstractions;
using Furiza.Base.Core.Identity.Abstractions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.Cipas.Application.CommandHandlers.CipaCommandHandlers
{
    internal class CriarCipaCommandHandler : IRequestHandler<CriarCipaCommand, CriarCommandResult>
    {
        private readonly IUserPrincipalBuilder userPrincipalBuilder;
        private readonly ICipaReadOnlyRepository cipaReadOnlyRepository;
        private readonly ICipaWriteOnlyRepository cipaWriteOnlyRepository;
        private readonly IAuditTrailProvider auditTrailProvider;

        public CriarCipaCommandHandler(IUserPrincipalBuilder userPrincipalBuilder,
            ICipaReadOnlyRepository cipaReadOnlyRepository,
            ICipaWriteOnlyRepository cipaWriteOnlyRepository,
            IAuditTrailProvider auditTrailProvider)
        {
            this.userPrincipalBuilder = userPrincipalBuilder ?? throw new ArgumentNullException(nameof(userPrincipalBuilder));
            this.cipaReadOnlyRepository = cipaReadOnlyRepository ?? throw new ArgumentNullException(nameof(cipaReadOnlyRepository));
            this.cipaWriteOnlyRepository = cipaWriteOnlyRepository ?? throw new ArgumentNullException(nameof(cipaWriteOnlyRepository));
            this.auditTrailProvider = auditTrailProvider ?? throw new ArgumentNullException(nameof(auditTrailProvider));
        }

        public async Task<CriarCommandResult> Handle(CriarCipaCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            var mandato = new Vigencia(request.InicioDoMandato, request.TerminoDoMandato);
            var numeroProximaCipa = await cipaReadOnlyRepository.GetNumeroDaUltimaCipaAsync(request.CodigoEmpresa, mandato.Inicio.Value.Year, mandato.Termino.Value.Year) + 1;
            var cipa = new Cipa(numeroProximaCipa, request.CodigoEmpresa, mandato)
            {
                CreationUser = userPrincipalBuilder.UserPrincipal.UserName,
            };

            cipaWriteOnlyRepository.Insert(cipa);

            await cipaWriteOnlyRepository.UnitOfWork.SaveEntitiesAsync();

            await auditTrailProvider.AddTrailsAsync(AuditOperation.Create, userPrincipalBuilder.UserPrincipal.UserName, new AuditableObjects<Cipa>(cipa.Id.ToString(), cipa));

            return new CriarCommandResult(cipa.Id, cipa.Codigo);
        }
    }
}