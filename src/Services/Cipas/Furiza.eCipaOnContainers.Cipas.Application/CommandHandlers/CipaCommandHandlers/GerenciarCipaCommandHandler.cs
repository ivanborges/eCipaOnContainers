﻿using Furiza.eCipaOnContainers.Cipas.Application.Commands.CipaCommands;
using Furiza.eCipaOnContainers.Cipas.Domain.Models;
using Furiza.eCipaOnContainers.Cipas.Domain.Models.CipaAggregate;
using Furiza.Audit.Abstractions;
using Furiza.Base.Core.Identity.Abstractions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.Cipas.Application.CommandHandlers.CipaCommandHandlers
{
    internal class GerenciarCipaCommandHandler : IRequestHandler<AtualizarCipaCommand>,
        IRequestHandler<AlternarStatusDeAtividadeDaCipaCommand>
    {
        private readonly IUserPrincipalBuilder userPrincipalBuilder;
        private readonly ICipaWriteOnlyRepository cipaWriteOnlyRepository;
        private readonly IAuditTrailProvider auditTrailProvider;

        public GerenciarCipaCommandHandler(IUserPrincipalBuilder userPrincipalBuilder,
            ICipaWriteOnlyRepository cipaWriteOnlyRepository,
            IAuditTrailProvider auditTrailProvider)
        {
            this.userPrincipalBuilder = userPrincipalBuilder ?? throw new ArgumentNullException(nameof(userPrincipalBuilder));
            this.cipaWriteOnlyRepository = cipaWriteOnlyRepository ?? throw new ArgumentNullException(nameof(cipaWriteOnlyRepository));
            this.auditTrailProvider = auditTrailProvider ?? throw new ArgumentNullException(nameof(auditTrailProvider));
        }

        public async Task<Unit> Handle(AtualizarCipaCommand request, CancellationToken cancellationToken)
        {
            if (request.Cipa.Mandato.Termino.Value.Date != request.TerminoDoMandato)
                request.Cipa.Mandato.DefinirNovoTermino(request.TerminoDoMandato);

            if (request.Cipa.Mandato.Inicio.Value.Date != request.InicioDoMandato)
                request.Cipa.Mandato.DefinirNovoInicio(request.InicioDoMandato);

            return await ProcederComAAtualizacaoDaCipaAsync(request.Cipa);
        }

        public async Task<Unit> Handle(AlternarStatusDeAtividadeDaCipaCommand request, CancellationToken cancellationToken)
        {
            if (request.Cipa.Status == StatusAtividade.Ativo)
                request.Cipa.Inativar();
            else
                request.Cipa.Ativar();

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