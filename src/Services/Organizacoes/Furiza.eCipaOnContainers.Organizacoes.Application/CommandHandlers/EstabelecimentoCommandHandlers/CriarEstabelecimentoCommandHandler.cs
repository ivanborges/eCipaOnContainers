using Furiza.Audit.Abstractions;
using Furiza.Base.Core.Identity.Abstractions;
using MediatR;
using Furiza.eCipaOnContainers.Organizacoes.Application.Commands;
using Furiza.eCipaOnContainers.Organizacoes.Application.Commands.EstabelecimentoCommands;
using Furiza.eCipaOnContainers.Organizacoes.Domain.Exceptions;
using Furiza.eCipaOnContainers.Organizacoes.Domain.Models.EstabelecimentoAggregate;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.Organizacoes.Application.CommandHandlers.EstabelecimentoCommandHandlers
{
    internal class CriarEstabelecimentoCommandHandler : IRequestHandler<CriarEstabelecimentoCommand, CriarCommandResult>
    {
        private readonly IUserPrincipalBuilder userPrincipalBuilder;
        private readonly IEstabelecimentoReadOnlyRepository estabelecimentoReadOnlyRepository;
        private readonly IEstabelecimentoWriteOnlyRepository estabelecimentoWriteOnlyRepository;
        private readonly IAuditTrailProvider auditTrailProvider;

        public CriarEstabelecimentoCommandHandler(IUserPrincipalBuilder userPrincipalBuilder,
            IEstabelecimentoReadOnlyRepository estabelecimentoReadOnlyRepository,
            IEstabelecimentoWriteOnlyRepository estabelecimentoWriteOnlyRepository,
            IAuditTrailProvider auditTrailProvider)
        {
            this.userPrincipalBuilder = userPrincipalBuilder ?? throw new ArgumentNullException(nameof(userPrincipalBuilder));
            this.estabelecimentoReadOnlyRepository = estabelecimentoReadOnlyRepository ?? throw new ArgumentNullException(nameof(estabelecimentoReadOnlyRepository));
            this.estabelecimentoWriteOnlyRepository = estabelecimentoWriteOnlyRepository ?? throw new ArgumentNullException(nameof(estabelecimentoWriteOnlyRepository));
            this.auditTrailProvider = auditTrailProvider ?? throw new ArgumentNullException(nameof(auditTrailProvider));
        }

        public async Task<CriarCommandResult> Handle(CriarEstabelecimentoCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (await estabelecimentoReadOnlyRepository.GetByCodigoAsync(request.Codigo) != null)
                throw new CodigoDeEstabelecimentoEmUsoException();

            var estabelecimento = new Estabelecimento(request.Codigo, request.Nome)
            {
                CreationUser = userPrincipalBuilder.UserPrincipal.UserName
            };

            estabelecimentoWriteOnlyRepository.Insert(estabelecimento);

            await estabelecimentoWriteOnlyRepository.UnitOfWork.SaveEntitiesAsync();

            await auditTrailProvider.AddTrailsAsync(AuditOperation.Create, userPrincipalBuilder.UserPrincipal.UserName, new AuditableObjects<Estabelecimento>(estabelecimento.Id.ToString(), estabelecimento));

            return new CriarCommandResult(estabelecimento.Id, estabelecimento.Codigo);
        }
    }
}