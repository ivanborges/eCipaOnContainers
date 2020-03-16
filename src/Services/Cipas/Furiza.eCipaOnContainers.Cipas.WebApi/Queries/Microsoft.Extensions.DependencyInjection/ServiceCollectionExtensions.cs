using Furiza.eCipaOnContainers.Cipas.WebApi.Queries;
using MediatR;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCipasQueries(this IServiceCollection services, CipasSqlConfiguration cipasSqlConfiguration)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddSingleton(cipasSqlConfiguration ?? throw new ArgumentNullException(nameof(cipasSqlConfiguration)));
            services.AddTransient<CipasQueryContext>();

            services.AddMediatR(typeof(CipasQueryContext).Assembly);

            return services;
        }
    }
}