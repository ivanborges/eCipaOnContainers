using Furiza.eCipaOnContainers.Cipas.Application.Commands;
using Furiza.eCipaOnContainers.Cipas.Application.Commands.ReuniaoCommands;
using Furiza.eCipaOnContainers.Cipas.Domain.Models.ReuniaoAggregate;
using Furiza.Audit.Abstractions;
using Furiza.Base.Core.Identity.Abstractions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.Cipas.Application.CommandHandlers.ReuniaoCommandHandlers
{
    internal class CriarReuniaoCommandHandler : IRequestHandler<CriarReuniaoCommand, CriarCommandResult>
    {
        private readonly IUserPrincipalBuilder userPrincipalBuilder;
        private readonly IReuniaoWriteOnlyRepository reuniaoWriteOnlyRepository;
        private readonly IAuditTrailProvider auditTrailProvider;

        public CriarReuniaoCommandHandler(IUserPrincipalBuilder userPrincipalBuilder,
            IReuniaoWriteOnlyRepository reuniaoWriteOnlyRepository,
            IAuditTrailProvider auditTrailProvider)
        {
            this.userPrincipalBuilder = userPrincipalBuilder ?? throw new ArgumentNullException(nameof(userPrincipalBuilder));
            this.reuniaoWriteOnlyRepository = reuniaoWriteOnlyRepository ?? throw new ArgumentNullException(nameof(reuniaoWriteOnlyRepository));
            this.auditTrailProvider = auditTrailProvider ?? throw new ArgumentNullException(nameof(auditTrailProvider));
        }

        public async Task<CriarCommandResult> Handle(CriarReuniaoCommand request, CancellationToken cancellationToken)
        {
            var reuniao = new Reuniao(userPrincipalBuilder.UserPrincipal.UserName, request.CipaId, request.MesDeReferencia, request.DataPrevista, request.Local, request.Extraordinaria);

            reuniaoWriteOnlyRepository.Insert(reuniao);

            await reuniaoWriteOnlyRepository.UnitOfWork.SaveEntitiesAsync();

            await auditTrailProvider.AddTrailsAsync(AuditOperation.Create, userPrincipalBuilder.UserPrincipal.UserName, new AuditableObjects<Reuniao>(reuniao.Id.ToString(), reuniao));

            return new CriarCommandResult(reuniao.Id);
        }
    }
}