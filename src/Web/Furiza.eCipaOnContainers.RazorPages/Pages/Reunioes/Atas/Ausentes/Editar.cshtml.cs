using Furiza.eCipaOnContainers.RazorPages.RestClients.Cipas.Reunioes;
using Furiza.AspNetCore.WebApp.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.RazorPages.Pages.Reunioes.Atas.Ausentes
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
        public Guid AusenteId { get; set; }

        [BindProperty]
        public ReunioesAtasAusentesPut ReunioesAtasAusentesPut { get; set; }

        [TempData]
        public string FeedbackSuccess { get; set; }

        public EditarModel(IReunioesClient reunioesClient)
        {
            this.reunioesClient = reunioesClient ?? throw new ArgumentNullException(nameof(reunioesClient));
        }

        public void OnGet(Guid reuniaoId, Guid ataId, Guid ausenteId)
        {
            ReuniaoId = reuniaoId;
            AtaId = ataId;
            AusenteId = ausenteId;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await reunioesClient.AtasAusentesPutAsync(ReuniaoId, AtaId, AusenteId, ReunioesAtasAusentesPut);

            FeedbackSuccess = $"A justificativa de ausência na ata de reunião foi atualizada com êxito.";

            return new JsonResult(
                new
                {
                    returnUrl = Url.Page("/Reunioes/Detalhar", new { id = ReuniaoId })
                });
        }
    }
}