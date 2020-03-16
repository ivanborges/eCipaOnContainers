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
    public class EditarModel : PageModel
    {
        private readonly IReunioesClient reunioesClient;

        [BindProperty]
        public Guid ReuniaoId { get; set; }

        [BindProperty]
        public ReunioesPut ReunioesPut { get; set; }

        [TempData]
        public string FeedbackSuccess { get; set; }

        public EditarModel(IReunioesClient reunioesClient)
        {
            this.reunioesClient = reunioesClient ?? throw new ArgumentNullException(nameof(reunioesClient));
        }

        public async Task OnGetAsync(Guid id)
        {
            var reunioesGetResult = await reunioesClient.GetAsync(id);
            ReunioesPut = new ReunioesPut()
            {
                MesDeReferencia = reunioesGetResult.MesDeReferencia,
                DataPrevista = reunioesGetResult.DataPrevista?.Date,
                HorarioPrevisto = reunioesGetResult.DataPrevista?.ToString("h:mm tt", CultureInfo.InvariantCulture),
                Local = reunioesGetResult.Local
            };
            ReuniaoId = id;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (DateTime.TryParseExact(ReunioesPut.HorarioPrevisto, "h:mm tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out var horarioInformado))
                ReunioesPut.DataPrevista = ReunioesPut.DataPrevista.Value.Date + horarioInformado.TimeOfDay;

            await reunioesClient.PutAsync(ReuniaoId, ReunioesPut);

            FeedbackSuccess = $"A reunião foi atualizada com êxito.";

            return new JsonResult(
                new
                {
                    returnUrl = Url.Page("/Reunioes/Detalhar", new { id = ReuniaoId })
                });
        }
    }
}