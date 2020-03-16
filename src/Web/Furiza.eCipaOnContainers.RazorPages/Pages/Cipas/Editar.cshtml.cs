using Furiza.eCipaOnContainers.RazorPages.RestClients.Cipas.Cipas;
using Furiza.AspNetCore.WebApp.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.RazorPages.Pages.Cipas
{
    [Authorize(Policy = FurizaPolicies.RequireEditorRights)]
    public class EditarModel : PageModel
    {
        private readonly ICipasClient cipasClient;

        [BindProperty]
        public Guid CipaId { get; set; }

        [BindProperty]
        public CipasPut CipasPut { get; set; }

        [TempData]
        public string FeedbackSuccess { get; set; }

        public EditarModel(ICipasClient cipasClient)
        {
            this.cipasClient = cipasClient ?? throw new ArgumentNullException(nameof(cipasClient));
        }

        public async Task OnGetAsync(Guid id)
        {
            var cipasGetResult = await cipasClient.GetAsync(id);
            CipasPut = new CipasPut()
            {
                InicioDoMandato = cipasGetResult.Mandato_Inicio,
                TerminoDoMandato = cipasGetResult.Mandato_Termino
            };
            CipaId = id;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await cipasClient.PutAsync(CipaId, CipasPut);

            FeedbackSuccess = $"A cipa foi atualizada com êxito.";

            return new JsonResult(
                new
                {
                    returnUrl = Url.Page("/Cipas/Detalhar", new { id = CipaId })
                });
        }
    }
}