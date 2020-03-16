using Furiza.eCipaOnContainers.Organizacoes.WebApi.Queries;
using MediatR;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddOrganizacoesQueries(this IServiceCollection services, OrganizacoesSqlConfiguration coreBusinessSqlConfiguration)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddSingleton(coreBusinessSqlConfiguration ?? throw new ArgumentNullException(nameof(coreBusinessSqlConfiguration)));
            services.AddTransient<OrganizacoesQueryContext>();

            services.AddMediatR(typeof(OrganizacoesQueryContext).Assembly);

            return services;
        }
    }
}