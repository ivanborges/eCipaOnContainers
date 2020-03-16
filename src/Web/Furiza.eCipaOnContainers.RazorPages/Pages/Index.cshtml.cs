using Furiza.eCipaOnContainers.RazorPages.RestClients.Cipas.Cipas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.RazorPages.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ICipasClient cipasClient;

        [BindProperty]
        public CipasGetAtivasDoUsuarioLogadoResult CipasGetAtivasDoUsuarioLogadoResult { get; set; }

        public IndexModel(ICipasClient cipasClient)
        {
            this.cipasClient = cipasClient ?? throw new ArgumentNullException(nameof(cipasClient));
        }

        public async Task OnGetAsync()
        {
            CipasGetAtivasDoUsuarioLogadoResult = await cipasClient.GetAtivasDoUsuarioLogadoAsync();
        }
    }
}