using Furiza.eCipaOnContainers.SecurityProvider.Core.Services;
using Furiza.AspNetCore.Identity.EntityFrameworkCore;
using Furiza.AspNetCore.WebApi.Configuration.SecurityProvider.Services;
using Furiza.Base.Core.Identity.Abstractions;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.SecurityProvider.WebApi.Services
{
    internal class SignInManager : ISignInManager
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ICemigIdentityService cemigIdentityService;

        public SignInManager(SignInManager<ApplicationUser> signInManager,
            ICemigIdentityService cemigIdentityService)
        {
            this.signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            this.cemigIdentityService = cemigIdentityService ?? throw new ArgumentNullException(nameof(cemigIdentityService));
        }

        public async Task<bool> CheckPasswordSignInAsync<TUserPrincipal>(TUserPrincipal userPrincipal, string password) where TUserPrincipal : IUserPrincipal
        {
            if (await cemigIdentityService.VerificarSeEUmaMatriculaValidaAsync(userPrincipal.UserName))
                return await cemigIdentityService.VerificarCredenciaisAsync(userPrincipal.UserName, password);
            else
                return (await signInManager.CheckPasswordSignInAsync(userPrincipal as ApplicationUser, password, false)).Succeeded;
        }
    }
}