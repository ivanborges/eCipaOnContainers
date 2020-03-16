using Furiza.AspNetCore.WebApi.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Furiza.eCipaOnContainers.PlanosDeAcao.WebApi
{
    public class Startup : RootStartup
    {
        protected override ApiProfile ApiProfile => new ApiProfile()
        {
            Name = "GestorPlanosDeAcaoApi",
            Description = "SESMTTech Gestor PlanosDeAcao Web Api",
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
            services.AddPlanosDeAcaoApplication();
            services.AddPlanosDeAcaoEntityFramework(Configuration.TryGet<Infrastructure.EFCore.PlanosDeAcaoSqlConfiguration>());
            services.AddPlanosDeAcaoQueries(Configuration.TryGet<Queries.PlanosDeAcaoSqlConfiguration>());
        }

        protected override void AddCustomMiddlewaresToTheBeginningOfThePipeline(IApplicationBuilder app)
        {
        }

        protected override void AddCustomMiddlewaresToTheEndOfThePipeline(IApplicationBuilder app)
        {
            app.RunPlanosDeAcaoMigrations();
        }
    }
}