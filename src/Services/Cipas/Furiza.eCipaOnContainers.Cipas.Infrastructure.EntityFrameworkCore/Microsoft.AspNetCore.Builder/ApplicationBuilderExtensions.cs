using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Furiza.eCipaOnContainers.Cipas.Infrastructure.EntityFrameworkCore;
using System;

namespace Microsoft.AspNetCore.Builder
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder RunCipasMigrations(this IApplicationBuilder applicationBuilder)
        {
            if (applicationBuilder == null)
                throw new ArgumentNullException(nameof(applicationBuilder));

            using (var serviceScope = applicationBuilder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var logger = serviceScope.ServiceProvider.GetService<ILoggerFactory>().CreateLogger<CipasContext>();

                var sqlConfiguration = serviceScope.ServiceProvider.GetService<CipasSqlConfiguration>();
                if (sqlConfiguration.EnableMigrations)
                {
                    logger.LogInformation("Applying migrations for Gestor Cipas...");

                    using (var context = serviceScope.ServiceProvider.GetService<CipasContext>())
                        context.Database.Migrate();

                    logger.LogInformation("Gestor Cipas migrations applied.");
                }
                else
                    logger.LogInformation("Gestor Cipas migrations disabled.");
            }

            return applicationBuilder;
        }
    }
}