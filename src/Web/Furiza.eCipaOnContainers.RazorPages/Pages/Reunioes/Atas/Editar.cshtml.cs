using Furiza.eCipaOnContainers.RazorPages.RestClients.Cipas.Reunioes;
using Furiza.AspNetCore.WebApp.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.RazorPages.Pages.Reunioes.Atas
{
    [Authorize(Policy = FurizaPolicies.RequireEditorRights)]
    public class EditarModel : PageModel
    {
        private readonly IReunioesClient reunioesClient;

        [BindProperty]
        public Guid ReuniaoId { get; set; }

        [BindProperty]
        public Guid AtaId { get; set; }

        [BindProperty]
        public ReunioesAtasPut ReunioesAtasPut { get; set; }

        [TempData]
        public string FeedbackSuccess { get; set; }

        public EditarModel(IReunioesClient reunioesClient)
        {
            this.reunioesClient = reunioesClient ?? throw new ArgumentNullException(nameof(reunioesClient));
        }

        public async Task OnGetAsync(Guid reuniaoId, Guid ataId)
        {
            var reunioesGetResult = await reunioesClient.GetAsync(reuniaoId);

            ReunioesAtasPut = new ReunioesAtasPut()
            {
                Local = reunioesGetResult.Ata?.Local,
                Data = reunioesGetResult.Ata?.Inicio?.Date,
                HorarioInicio = reunioesGetResult.Ata?.Inicio?.ToString("h:mm tt", CultureInfo.InvariantCulture),
                HorarioFim = reunioesGetResult.Ata?.Termino?.ToString("h:mm tt", CultureInfo.InvariantCulture)
            };

            ReuniaoId = reuniaoId;
            AtaId = ataId;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (DateTime.TryParseExact(ReunioesAtasPut.HorarioInicio, "h:mm tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out var horarioInformadoInicio) &&
                DateTime.TryParseExact(ReunioesAtasPut.HorarioFim, "h:mm tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out var horarioInformadoFim))
            {
                ReunioesAtasPut.Inicio = ReunioesAtasPut.Data.Value.Date + horarioInformadoInicio.TimeOfDay;
                ReunioesAtasPut.Termino = ReunioesAtasPut.Data.Value.Date + horarioInformadoFim.TimeOfDay;
            }
            else
            {
                ReunioesAtasPut.Inicio = ReunioesAtasPut.Data.Value.Date;
                ReunioesAtasPut.Termino = ReunioesAtasPut.Data.Value.Date;
            }

            await reunioesClient.AtasPutAsync(ReuniaoId, AtaId, ReunioesAtasPut);

            FeedbackSuccess = $"A ata de reunião foi atualizada com êxito.";

            return new JsonResult(
                new
                {
                    returnUrl = Url.Page("/Reunioes/Detalhar", new { id = ReuniaoId })
                });
        }
    }
}