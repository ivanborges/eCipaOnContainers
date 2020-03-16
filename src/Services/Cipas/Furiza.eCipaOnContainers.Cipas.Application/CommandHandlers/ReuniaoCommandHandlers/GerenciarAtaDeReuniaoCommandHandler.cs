using Furiza.eCipaOnContainers.Cipas.Application.Commands;
using Furiza.eCipaOnContainers.Cipas.Application.Commands.ReuniaoCommands;
using Furiza.eCipaOnContainers.Cipas.Domain.Exceptions;
using Furiza.eCipaOnContainers.Cipas.Domain.Models.CipaAggregate;
using Furiza.eCipaOnContainers.Cipas.Domain.Models.ReuniaoAggregate;
using Furiza.Audit.Abstractions;
using Furiza.Base.Core.Identity.Abstractions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.Cipas.Application.CommandHandlers.ReuniaoCommandHandlers
{
    internal class GerenciarAtaDeReuniaoCommandHandler : IRequestHandler<GerarAtaDeReuniaoCommand, CriarCommandResult>,
        IRequestHandler<AtualizarAtaDeReuniaoCommand>,
        IRequestHandler<FinalizarAtaDeReuniaoCommand>,
        IRequestHandler<ReabrirAtaDeReuniaoCommand>,
        IRequestHandler<AprovarAtaDeReuniaoCommand>
    {
        private readonly IUserPrincipalBuilder userPrincipalBuilder;
        private readonly ICipaReadOnlyRepository cipaReadOnlyRepository;
        private readonly IReuniaoReadOnlyRepository reuniaoReadOnlyRepository;
        private readonly IReuniaoWriteOnlyRepository reuniaoWriteOnlyRepository;
        private readonly IAuditTrailProvider auditTrailProvider;

        public GerenciarAtaDeReuniaoCommandHandler(IUserPrincipalBuilder userPrincipalBuilder,
            ICipaReadOnlyRepository cipaReadOnlyRepository,
            IReuniaoReadOnlyRepository reuniaoReadOnlyRepository,
            IReuniaoWriteOnlyRepository reuniaoWriteOnlyRepository,
            IAuditTrailProvider auditTrailProvider)
        {
            this.userPrincipalBuilder = userPrincipalBuilder ?? throw new ArgumentNullException(nameof(userPrincipalBuilder));
            this.cipaReadOnlyRepository = cipaReadOnlyRepository ?? throw new ArgumentNullException(nameof(cipaReadOnlyRepository));
            this.reuniaoReadOnlyRepository = reuniaoReadOnlyRepository ?? throw new ArgumentNullException(nameof(reuniaoReadOnlyRepository));
            this.reuniaoWriteOnlyRepository = reuniaoWriteOnlyRepository ?? throw new ArgumentNullException(nameof(reuniaoWriteOnlyRepository));
            this.auditTrailProvider = auditTrailProvider ?? throw new ArgumentNullException(nameof(auditTrailProvider));
        }

        public async Task<CriarCommandResult> Handle(GerarAtaDeReuniaoCommand request, CancellationToken cancellationToken)
        {
            var cipa = await cipaReadOnlyRepository.GetByIdAsync(request.Reuniao.CipaId);
            var numeroProximaAta = await reuniaoReadOnlyRepository.GetNumeroDaUltimaAtaAsync(cipa.Codigo) + 1;

            request.Reuniao.GerarAta(userPrincipalBuilder.UserPrincipal.UserName, numeroProximaAta, cipa.Codigo, request.Local, request.Inicio, request.Termino);

            await ProcederComAAtualizacaoDaReuniaoAsync(request.Reuniao);

            return new CriarCommandResult(request.Reuniao.Ata.Id, request.Reuniao.Ata.Codigo);
        }

        public async Task<Unit> Handle(AtualizarAtaDeReuniaoCommand request, CancellationToken cancellationToken)
        {
            if (request.Reuniao.Ata == null)
                throw new AtaDeReuniaoAindaNaoGeradaException();

            if (request.Reuniao.Ata.Id != request.AtaId)
                throw new AtaDeReuniaoInvalidaException();

            request.Reuniao.Ata.DefinirNovoLocal(request.Local);
            request.Reuniao.Ata.DefinirNovoPeriodo(request.Inicio, request.Termino);

            return await ProcederComAAtualizacaoDaReuniaoAsync(request.Reuniao);
        }

        public async Task<Unit> Handle(FinalizarAtaDeReuniaoCommand request, CancellationToken cancellationToken)
        {
            if (request.Reuniao.Ata == null)
                throw new AtaDeReuniaoAindaNaoGeradaException();

            if (request.Reuniao.Ata.Id != request.AtaId)
                throw new AtaDeReuniaoInvalidaException();

            request.Reuniao.Ata.Finalizar(userPrincipalBuilder.UserPrincipal.UserName);

            return await ProcederComAAtualizacaoDaReuniaoAsync(request.Reuniao);
        }

        public async Task<Unit> Handle(ReabrirAtaDeReuniaoCommand request, CancellationToken cancellationToken)
        {
            if (request.Reuniao.Ata == null)
                throw new AtaDeReuniaoAindaNaoGeradaException();

            if (request.Reuniao.Ata.Id != request.AtaId)
                throw new AtaDeReuniaoInvalidaException();

            request.Reuniao.Ata.Reabrir();

            return await ProcederComAAtualizacaoDaReuniaoAsync(request.Reuniao);
        }

        public async Task<Unit> Handle(AprovarAtaDeReuniaoCommand request, CancellationToken cancellationToken)
        {
            if (request.Reuniao.Ata == null)
                throw new AtaDeReuniaoAindaNaoGeradaException();

            if (request.Reuniao.Ata.Id != request.AtaId)
                throw new AtaDeReuniaoInvalidaException();

            request.Reuniao.Ata.Aprovar(userPrincipalBuilder.UserPrincipal.UserName);

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