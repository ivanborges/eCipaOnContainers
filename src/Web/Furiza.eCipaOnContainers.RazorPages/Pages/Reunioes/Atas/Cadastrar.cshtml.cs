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
    public class CadastrarModel : PageModel
    {
        private readonly IReunioesClient reunioesClient;

        public ReunioesGetResult ReunioesGetResult { get; set; }

        [BindProperty]
        public Guid ReuniaoId { get; set; }

        [BindProperty]
        public ReunioesAtasPost ReunioesAtasPost { get; set; }

        [TempData]
        public string FeedbackSuccess { get; set; }

        public CadastrarModel(IReunioesClient reunioesClient)
        {
            this.reunioesClient = reunioesClient ?? throw new ArgumentNullException(nameof(reunioesClient));
        }

        public async Task OnGetAsync(Guid reuniaoId)
        {
            ReunioesGetResult = await reunioesClient.GetAsync(reuniaoId);
            ReuniaoId = reuniaoId;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (DateTime.TryParseExact(ReunioesAtasPost.HorarioInicio, "h:mm tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out var horarioInformadoInicio) &&
                DateTime.TryParseExact(ReunioesAtasPost.HorarioFim, "h:mm tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out var horarioInformadoFim))
            {
                ReunioesAtasPost.Inicio = ReunioesAtasPost.Data.Value.Date + horarioInformadoInicio.TimeOfDay;
                ReunioesAtasPost.Termino = ReunioesAtasPost.Data.Value.Date + horarioInformadoFim.TimeOfDay;
            }
            else
            {
                ReunioesAtasPost.Inicio = ReunioesAtasPost.Data.Value.Date;
                ReunioesAtasPost.Termino = ReunioesAtasPost.Data.Value.Date;
            }

            var result = await reunioesClient.AtasPostAsync(ReuniaoId, ReunioesAtasPost);

            FeedbackSuccess = $"A ata de reunião <b>{result.Codigo}</b> foi gerada com êxito.";

            return new JsonResult(
                new
                {
                    returnUrl = Url.Page("/Reunioes/Detalhar", new { id = ReuniaoId })
                });
        }
    }
}