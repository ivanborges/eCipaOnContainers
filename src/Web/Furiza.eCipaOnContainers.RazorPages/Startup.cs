using Furiza.AspNetCore.WebApp.Configuration;
using Furiza.Networking.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using Furiza.eCipaOnContainers.RazorPages.RestClients.Cipas;
using Furiza.eCipaOnContainers.RazorPages.RestClients.Cipas.Cipas;
using Furiza.eCipaOnContainers.RazorPages.RestClients.Cipas.Reunioes;
using Furiza.eCipaOnContainers.RazorPages.RestClients.Organizacoes;
using Furiza.eCipaOnContainers.RazorPages.RestClients.Organizacoes.Estabelecimentos;
using Furiza.eCipaOnContainers.RazorPages.RestClients.PlanosDeAcao;
using Furiza.eCipaOnContainers.RazorPages.RestClients.PlanosDeAcao.PlanosDeAcao;

namespace Furiza.eCipaOnContainers.RazorPages
{
    public class Startup : RootStartup
    {
        protected override ApplicationProfile ApplicationProfile => Configuration.TryGet<ApplicationProfile>();

        public Startup(IConfiguration configuration) : base(configuration)
        {
        }

        #region [+] Overrides
        protected override void AddCustomServicesAtTheBeginning(IServiceCollection services)
        {
        }

        protected override void AddCustomServicesAtTheEnd(IServiceCollection services)
        {
            var organizacoesConfiguration = Configuration.TryGet<OrganizacoesConfiguration>();
            services.AddSingleton(organizacoesConfiguration);
            services.AddTransient(serviceProvider =>
            {
                var httpClientFactory = serviceProvider.GetService<IHttpClientFactory>();
                var httpClient = httpClientFactory.Create(organizacoesConfiguration.ApiUrl);

                return RestService.For<IEstabelecimentosClient>(httpClient);
            });

            var cipasConfiguration = Configuration.TryGet<CipasConfiguration>();
            services.AddSingleton(cipasConfiguration);
            services.AddTransient(serviceProvider =>
            {
                var httpClientFactory = serviceProvider.GetService<IHttpClientFactory>();
                var httpClient = httpClientFactory.Create(cipasConfiguration.ApiUrl);

                return RestService.For<ICipasClient>(httpClient);
            });
            services.AddTransient(serviceProvider =>
            {
                var httpClientFactory = serviceProvider.GetService<IHttpClientFactory>();
                var httpClient = httpClientFactory.Create(cipasConfiguration.ApiUrl);

                return RestService.For<IReunioesClient>(httpClient);
            });

            var planosDeAcaoConfiguration = Configuration.TryGet<PlanosDeAcaoConfiguration>();
            services.AddSingleton(planosDeAcaoConfiguration);
            services.AddTransient(serviceProvider =>
            {
                var httpClientFactory = serviceProvider.GetService<IHttpClientFactory>();
                var httpClient = httpClientFactory.Create(planosDeAcaoConfiguration.ApiUrl);

                return RestService.For<IPlanosDeAcaoClient>(httpClient);
            });
        }

        protected override void AddCustomMiddlewaresToTheBeginningOfThePipeline(IApplicationBuilder app)
        {
        }

        protected override void AddCustomMiddlewaresToTheEndOfThePipeline(IApplicationBuilder app)
        {
        } 
        #endregion
    }
}