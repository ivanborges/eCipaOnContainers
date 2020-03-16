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
    internal class GerenciarAssuntoDaAtaDeReuniaoCommandHandler : IRequestHandler<AdicionarAssuntoAAtaDeReuniaoCommand>,
        IRequestHandler<RemoverAssuntoDaAtaDeReuniaoCommand>,
        IRequestHandler<AtualizarAssuntoDaAtaDeReuniaoCommand>
    {
        private readonly IUserPrincipalBuilder userPrincipalBuilder;
        private readonly IReuniaoWriteOnlyRepository reuniaoWriteOnlyRepository;
        private readonly IAuditTrailProvider auditTrailProvider;

        public GerenciarAssuntoDaAtaDeReuniaoCommandHandler(IUserPrincipalBuilder userPrincipalBuilder,
            IReuniaoWriteOnlyRepository reuniaoWriteOnlyRepository,
            IAuditTrailProvider auditTrailProvider)
        {
            this.userPrincipalBuilder = userPrincipalBuilder ?? throw new ArgumentNullException(nameof(userPrincipalBuilder));
            this.reuniaoWriteOnlyRepository = reuniaoWriteOnlyRepository ?? throw new ArgumentNullException(nameof(reuniaoWriteOnlyRepository));
            this.auditTrailProvider = auditTrailProvider ?? throw new ArgumentNullException(nameof(auditTrailProvider));
        }
        
        public async Task<Unit> Handle(AdicionarAssuntoAAtaDeReuniaoCommand request, CancellationToken cancellationToken)
        {
            if (request.Reuniao.Ata == null)
                throw new AtaDeReuniaoAindaNaoGeradaException();

            if (request.Reuniao.Ata.Id != request.AtaId)
                throw new AtaDeReuniaoInvalidaException();

            request.Reuniao.Ata.AdicionarAssunto(userPrincipalBuilder.UserPrincipal.UserName, request.ClassificacaoDaInformacao, request.Tipo, request.Descricao, request.Keywords);

            return await ProcederComAAtualizacaoDaReuniaoAsync(request.Reuniao);
        }

        public async Task<Unit> Handle(AtualizarAssuntoDaAtaDeReuniaoCommand request, CancellationToken cancellationToken)
        {
            if (request.Reuniao.Ata == null)
                throw new AtaDeReuniaoAindaNaoGeradaException();

            if (request.Reuniao.Ata.Id != request.AtaId)
                throw new AtaDeReuniaoInvalidaException();

            var assunto = request.Reuniao.Ata.ObterAssunto(request.AssuntoId);

            assunto.ClassificacaoDaInformacao = request.ClassificacaoDaInformacao;
            assunto.Tipo = request.Tipo;
            assunto.DefinirNovaDescricao(userPrincipalBuilder.UserPrincipal.UserName, request.Reuniao.Ata, request.Descricao);
            assunto.Keywords = request.Keywords?.Trim();

            return await ProcederComAAtualizacaoDaReuniaoAsync(request.Reuniao);
        }

        public async Task<Unit> Handle(RemoverAssuntoDaAtaDeReuniaoCommand request, CancellationToken cancellationToken)
        {
            if (request.Reuniao.Ata == null)
                throw new AtaDeReuniaoAindaNaoGeradaException();

            if (request.Reuniao.Ata.Id != request.AtaId)
                throw new AtaDeReuniaoInvalidaException();

            request.Reuniao.Ata.RemoverAssunto(request.AssuntoId);

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