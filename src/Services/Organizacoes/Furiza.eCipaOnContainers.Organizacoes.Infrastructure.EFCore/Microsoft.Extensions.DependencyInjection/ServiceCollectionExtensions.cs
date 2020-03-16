using Microsoft.EntityFrameworkCore;
using Furiza.eCipaOnContainers.Organizacoes.Domain.Models.EstabelecimentoAggregate;
using Furiza.eCipaOnContainers.Organizacoes.Infrastructure.EFCore;
using Furiza.eCipaOnContainers.Organizacoes.Infrastructure.EFCore.Repositories;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddOrganizacoesEntityFramework(this IServiceCollection services, OrganizacoesSqlConfiguration coreBusinessSqlConfiguration)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddSingleton(coreBusinessSqlConfiguration ?? throw new ArgumentNullException(nameof(coreBusinessSqlConfiguration)));

            services.AddDbContext<OrganizacoesContext>(options => options.UseSqlServer(coreBusinessSqlConfiguration.ConnectionString));

            services.AddScoped<IEstabelecimentoReadOnlyRepository, EstabelecimentoRepository>();
            services.AddScoped<IEstabelecimentoWriteOnlyRepository, EstabelecimentoRepository>();

            return services;
        }
    }
}