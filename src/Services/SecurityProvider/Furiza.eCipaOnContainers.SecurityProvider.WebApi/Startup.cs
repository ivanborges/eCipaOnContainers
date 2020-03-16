using Furiza.eCipaOnContainers.SecurityProvider.Adapter.Matrix;
using Furiza.eCipaOnContainers.SecurityProvider.WebApi.Services;
using Furiza.AspNetCore.WebApi.Configuration;
using Furiza.AspNetCore.WebApi.Configuration.SecurityProvider;
using Furiza.AspNetCore.WebApi.Configuration.SecurityProvider.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Furiza.eCipaOnContainers.SecurityProvider.WebApi
{
    public class Startup : SecurityRootStartup
    {
        protected override ApiProfile ApiProfile => new ApiProfile()
        {
            Name = "SecurityProviderApi",
            Description = "Furiza.eCipaOnContainers Security Provider Web Api with Furiza Identity",
            DefaultVersion = "1.0",
            DefaultCultureInfo = "pt-BR"
        };

        public Startup(IConfiguration configuration) : base(configuration)
        {
        }

        protected override void AddCustomServicesAtTheEnd(IServiceCollection services)
        {
            services.AddTransient<IPasswordGenerator, PasswordGenerator>();
            services.AddTransient<ISignInManager, SignInManager>();
            services.AddTransient<IUserNotifier, UserNotifier>();

            services.AddMatrixAdapter(Configuration.TryGet<MatrixConfiguration>());
        }

        protected override void AddCustomMiddlewaresToTheBeginningOfThePipeline(IApplicationBuilder app)
        {            
        }
    }
}