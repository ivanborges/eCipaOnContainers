using Furiza.AspNetCore.WebApi.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Furiza.eCipaOnContainers.Organizacoes.WebApi
{
    public class Startup : RootStartup
    {
        protected override ApiProfile ApiProfile => new ApiProfile()
        {
            Name = "GestorOrganizacoesApi",
            Description = "SESMTTech Gestor Organizacoes Web Api",
            DefaultVersion = "1.0",
            DefaultCultureInfo = "pt-BR"
        };

        public Startup(IConfiguration configuration) : base(configuration)
        {
            AutomapperAssemblies.Add(typeof(Startup).Assembly);
        }

        protected override void AddCustomServicesAtTheBeginning(IServiceCollection services)
        {
        }

        protected override void AddCustomServicesAtTheEnd(IServiceCollection services)
        {
            services.AddOrganizacoesApplication();
            services.AddOrganizacoesEntityFramework(Configuration.TryGet<Infrastructure.EFCore.OrganizacoesSqlConfiguration>());
            services.AddOrganizacoesQueries(Configuration.TryGet<Queries.OrganizacoesSqlConfiguration>());
        }

        protected override void AddCustomMiddlewaresToTheBeginningOfThePipeline(IApplicationBuilder app)
        {
        }

        protected override void AddCustomMiddlewaresToTheEndOfThePipeline(IApplicationBuilder app)
        {
            app.RunOrganizacoesMigrations();
        }
    }
}
