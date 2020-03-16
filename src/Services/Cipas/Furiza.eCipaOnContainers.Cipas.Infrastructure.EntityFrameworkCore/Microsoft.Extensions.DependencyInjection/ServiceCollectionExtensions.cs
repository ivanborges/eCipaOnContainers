using Microsoft.EntityFrameworkCore;
using Furiza.eCipaOnContainers.Cipas.Domain.Models.CipaAggregate;
using Furiza.eCipaOnContainers.Cipas.Domain.Models.ReuniaoAggregate;
using Furiza.eCipaOnContainers.Cipas.Infrastructure.EntityFrameworkCore;
using Furiza.eCipaOnContainers.Cipas.Infrastructure.EntityFrameworkCore.Repositories;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCipasEntityFramework(this IServiceCollection services, CipasSqlConfiguration cipasSqlConfiguration)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddSingleton(cipasSqlConfiguration ?? throw new ArgumentNullException(nameof(cipasSqlConfiguration)));

            services.AddDbContext<CipasContext>(options => options.UseSqlServer(cipasSqlConfiguration.ConnectionString));

            services.AddScoped<ICipaReadOnlyRepository, CipaRepository>();
            services.AddScoped<ICipaWriteOnlyRepository, CipaRepository>();
            services.AddScoped<IReuniaoReadOnlyRepository, ReuniaoRepository>();
            services.AddScoped<IReuniaoWriteOnlyRepository, ReuniaoRepository>();

            return services;
        }
    }
}