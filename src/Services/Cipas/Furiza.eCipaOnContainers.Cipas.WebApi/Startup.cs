using Furiza.AspNetCore.WebApi.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Furiza.eCipaOnContainers.Cipas.WebApi
{
    public class Startup : RootStartup
    {
        protected override ApiProfile ApiProfile => new ApiProfile()
        {
            Name = "GestorCipasApi",
            Description = "SESMTTech Gestor Cipas Web Api",
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
            services.AddCipasApplication();
            services.AddCipasEntityFramework(Configuration.TryGet<Infrastructure.EntityFrameworkCore.CipasSqlConfiguration>());
            services.AddCipasQueries(Configuration.TryGet<Queries.CipasSqlConfiguration>());
        }

        protected override void AddCustomMiddlewaresToTheBeginningOfThePipeline(IApplicationBuilder app)
        {
        }

        protected override void AddCustomMiddlewaresToTheEndOfThePipeline(IApplicationBuilder app)
        {
            app.RunCipasMigrations();
        }
    }
}
