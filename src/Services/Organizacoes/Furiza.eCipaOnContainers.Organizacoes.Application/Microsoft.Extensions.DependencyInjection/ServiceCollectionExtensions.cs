using MediatR;
using Furiza.eCipaOnContainers.Organizacoes.Application.CommandHandlers.EstabelecimentoCommandHandlers;
using Furiza.eCipaOnContainers.Organizacoes.Application.Commands;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddOrganizacoesApplication(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddMediatR(typeof(CriarEstabelecimentoCommandHandler).Assembly, typeof(CriarCommandResult).Assembly);

            return services;
        }
    }
}