using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Furiza.eCipaOnContainers.Organizacoes.Infrastructure.EFCore;
using System;

namespace Microsoft.AspNetCore.Builder
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder RunOrganizacoesMigrations(this IApplicationBuilder applicationBuilder)
        {
            if (applicationBuilder == null)
                throw new ArgumentNullException(nameof(applicationBuilder));

            using (var serviceScope = applicationBuilder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var logger = serviceScope.ServiceProvider.GetService<ILoggerFactory>().CreateLogger<OrganizacoesContext>();

                var sqlConfiguration = serviceScope.ServiceProvider.GetService<OrganizacoesSqlConfiguration>();
                if (sqlConfiguration.EnableMigrations)
                {
                    logger.LogInformation("Applying migrations for Gestor Organizacoes...");

                    using (var context = serviceScope.ServiceProvider.GetService<OrganizacoesContext>())
                        context.Database.Migrate();

                    logger.LogInformation("Gestor Organizacoes migrations applied.");
                }
                else
                    logger.LogInformation("Gestor Organizacoes migrations disabled.");
            }

            return applicationBuilder;
        }
    }
}