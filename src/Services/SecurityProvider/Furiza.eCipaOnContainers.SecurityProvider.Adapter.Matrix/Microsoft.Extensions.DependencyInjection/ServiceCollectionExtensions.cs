using Furiza.eCipaOnContainers.SecurityProvider.Adapter.Matrix;
using Furiza.eCipaOnContainers.SecurityProvider.Core.Services;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMatrixAdapter(this IServiceCollection services, MatrixConfiguration matrixConfiguration)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddSingleton(matrixConfiguration ?? throw new ArgumentNullException(nameof(matrixConfiguration)));

            services.AddScoped<ICemigIdentityService, CemigIdentityService>();

            return services;
        }
    }
}