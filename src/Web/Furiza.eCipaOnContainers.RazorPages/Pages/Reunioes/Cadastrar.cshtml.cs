using Furiza.eCipaOnContainers.RazorPages.RestClients.Cipas.Cipas;
using Furiza.eCipaOnContainers.RazorPages.RestClients.Cipas.Reunioes;
using Furiza.AspNetCore.WebApp.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.RazorPages.Pages.Reunioes
{
    [Authorize(Policy = FurizaPolicies.RequireEditorRights)]
    public class CadastrarModel : PageModel
    {
        private readonly ICipasClient cipasClient;
        private readonly IReunioesClient reunioesClient;

        [BindProperty]
        public ReunioesPost ReunioesPost { get; set; }

        public Guid CipaId { get; set; }

        public CadastrarModel(ICipasClient cipasClient,
            IReunioesClient reunioesClient)
        {
            this.cipasClient = cipasClient ?? throw new ArgumentNullException(nameof(cipasClient));
            this.reunioesClient = reunioesClient ?? throw new ArgumentNullException(nameof(reunioesClient));
        }

        public void OnGet(Guid cipaId)
        {
            CipaId = cipaId;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (DateTime.TryParseExact(ReunioesPost.HorarioPrevisto, "h:mm tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out var horarioInformado))
                ReunioesPost.DataPrevista = ReunioesPost.DataPrevista.Value.Date + horarioInformado.TimeOfDay;

            var result = await reunioesClient.PostAsync(ReunioesPost);

            return new JsonResult(
                new
                {
                    returnUrl = Url.Page("/Cipas/Detalhar", new { id = ReunioesPost.CipaId })
                });
        }
    }
}