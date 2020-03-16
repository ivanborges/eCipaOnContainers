﻿using Microsoft.EntityFrameworkCore;
using Furiza.eCipaOnContainers.PlanosDeAcao.Domain.Models.PlanoDeAcaoAggregate;
using Furiza.eCipaOnContainers.PlanosDeAcao.Infrastructure.EFCore;
using Furiza.eCipaOnContainers.PlanosDeAcao.Infrastructure.EFCore.Repositories;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPlanosDeAcaoEntityFramework(this IServiceCollection services, PlanosDeAcaoSqlConfiguration coreBusinessSqlConfiguration)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddSingleton(coreBusinessSqlConfiguration ?? throw new ArgumentNullException(nameof(coreBusinessSqlConfiguration)));

            services.AddDbContext<PlanosDeAcaoContext>(options => options.UseSqlServer(coreBusinessSqlConfiguration.ConnectionString));

            services.AddScoped<IPlanoDeAcaoReadOnlyRepository, PlanoDeAcaoRepository>();
            services.AddScoped<IPlanoDeAcaoWriteOnlyRepository, PlanoDeAcaoRepository>();

            return services;
        }
    }
}