using Furiza.eCipaOnContainers.RazorPages.RestClients.Cipas.Cipas;
using Furiza.AspNetCore.WebApp.Configuration;
using Furiza.AspNetCore.WebApp.Configuration.RestClients.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.RazorPages.Pages.Cipas
{
    [Authorize(Policy = FurizaPolicies.RequireEditorRights)]
    public class GerenciarMembrosModel : PageModel
    {
        private readonly IUsersClient usersClient;
        private readonly ICipasClient cipasClient;

        public UsersGetResult UsersGetResult { get; set; }

        [BindProperty]
        public Guid CipaId { get; set; }

        [BindProperty]
        public CipasMembrosPost CipasMembrosPost { get; set; }

        public GerenciarMembrosModel(IUsersClient usersClient,
            ICipasClient cipasClient)
        {
            this.usersClient = usersClient ?? throw new ArgumentNullException(nameof(usersClient));
            this.cipasClient = cipasClient ?? throw new ArgumentNullException(nameof(cipasClient));
        }

        public IActionResult OnGetLocalizarMembroPartial(Guid cipaId)
        {
            return new PartialViewResult()
            {
                ViewName = "_LocalizarMembroPartial",
                ViewData = new ViewDataDictionary<Guid>(ViewData, cipaId)
            };
        }

        public async Task OnGetAsync(Guid cipaId, string username, string email)
        {
            CipaId = cipaId;

            if (!string.IsNullOrWhiteSpace(username))
                UsersGetResult = await usersClient.GetAsync(username);

            if (UsersGetResult == null && !string.IsNullOrWhiteSpace(email))
                UsersGetResult = await usersClient.GetByEmailAsync(new UsersGetByEmail() { Email = email });
        }

        public async Task OnPostAsync()
        {
            await cipasClient.MembrosPostAsync(CipaId, CipasMembrosPost);
        }

        public async Task OnPostDeleteAsync(Guid cipaId, Guid membroId)
        {
            await cipasClient.MembrosDeleteAsync(cipaId, membroId);
        }
    }
}