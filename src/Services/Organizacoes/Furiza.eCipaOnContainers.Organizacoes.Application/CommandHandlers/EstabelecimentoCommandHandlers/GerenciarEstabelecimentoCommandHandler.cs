using Furiza.Audit.Abstractions;
using Furiza.Base.Core.Identity.Abstractions;
using MediatR;
using Furiza.eCipaOnContainers.Organizacoes.Application.Commands.EstabelecimentoCommands;
using Furiza.eCipaOnContainers.Organizacoes.Domain.Exceptions;
using Furiza.eCipaOnContainers.Organizacoes.Domain.Models;
using Furiza.eCipaOnContainers.Organizacoes.Domain.Models.EstabelecimentoAggregate;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.Organizacoes.Application.CommandHandlers.EstabelecimentoCommandHandlers
{
    internal class GerenciarEstabelecimentoCommandHandler : IRequestHandler<AtualizarEstabelecimentoCommand>,
        IRequestHandler<AlternarStatusDeAtividadeDoEstabelecimentoCommand>
    {
        private readonly IUserPrincipalBuilder userPrincipalBuilder;
        private readonly IEstabelecimentoReadOnlyRepository estabelecimentoReadOnlyRepository;
        private readonly IEstabelecimentoWriteOnlyRepository estabelecimentoWriteOnlyRepository;
        private readonly IAuditTrailProvider auditTrailProvider;

        public GerenciarEstabelecimentoCommandHandler(IUserPrincipalBuilder userPrincipalBuilder,
            IEstabelecimentoReadOnlyRepository estabelecimentoReadOnlyRepository,
            IEstabelecimentoWriteOnlyRepository estabelecimentoWriteOnlyRepository,
            IAuditTrailProvider auditTrailProvider)
        {
            this.userPrincipalBuilder = userPrincipalBuilder ?? throw new ArgumentNullException(nameof(userPrincipalBuilder));
            this.estabelecimentoReadOnlyRepository = estabelecimentoReadOnlyRepository ?? throw new ArgumentNullException(nameof(estabelecimentoReadOnlyRepository));
            this.estabelecimentoWriteOnlyRepository = estabelecimentoWriteOnlyRepository ?? throw new ArgumentNullException(nameof(estabelecimentoWriteOnlyRepository));
            this.auditTrailProvider = auditTrailProvider ?? throw new ArgumentNullException(nameof(auditTrailProvider));
        }

        public async Task<Unit> Handle(AtualizarEstabelecimentoCommand request, CancellationToken cancellationToken)
        {
            if (request.Estabelecimento.Codigo.ToLower() != request.Codigo.Trim().ToLower())
            {
                if (await estabelecimentoReadOnlyRepository.GetByCodigoAsync(request.Codigo.Trim()) != null)
                    throw new CodigoDeEstabelecimentoEmUsoException();

                request.Estabelecimento.Codigo = request.Codigo.Trim();
            }

            request.Estabelecimento.Nome = request.Nome.Trim();

            return await ProcederComAAtualizacaoDoEstabelecimentoAsync(request.Estabelecimento);
        }

        public async Task<Unit> Handle(AlternarStatusDeAtividadeDoEstabelecimentoCommand request, CancellationToken cancellationToken)
        {
            if (request.Estabelecimento.Status == StatusAtividade.Ativo)
                request.Estabelecimento.Inativar();
            else
                request.Estabelecimento.Ativar();

            return await ProcederComAAtualizacaoDoEstabelecimentoAsync(request.Estabelecimento);
        }

        #region [+] Privates
        private async Task<Unit> ProcederComAAtualizacaoDoEstabelecimentoAsync(Estabelecimento estabelecimento)
        {
            estabelecimentoWriteOnlyRepository.Update(estabelecimento);

            await estabelecimentoWriteOnlyRepository.UnitOfWork.SaveEntitiesAsync();

            await auditTrailProvider.AddTrailsAsync(AuditOperation.Update, userPrincipalBuilder.UserPrincipal.UserName, new AuditableObjects<Estabelecimento>(estabelecimento.Id.ToString(), estabelecimento));

            return Unit.Value;
        }
        #endregion
    }
}