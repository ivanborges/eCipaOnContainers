﻿using MediatR;
using Furiza.eCipaOnContainers.PlanosDeAcao.Application.CommandHandlers.PlanoDeAcaoCommandHandlers;
using Furiza.eCipaOnContainers.PlanosDeAcao.Application.Commands;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPlanosDeAcaoApplication(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddMediatR(typeof(CriarPlanoDeAcaoCommandHandler).Assembly, typeof(CriarCommandResult).Assembly);

            return services;
        }
    }
}