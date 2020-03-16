using Furiza.eCipaOnContainers.Cipas.Application.CommandHandlers.CipaCommandHandlers;
using Furiza.eCipaOnContainers.Cipas.Application.Commands;
using MediatR;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCipasApplication(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddMediatR(typeof(CriarCipaCommandHandler).Assembly, typeof(CriarCommandResult).Assembly);

            return services;
        }
    }
}