using Furiza.eCipaOnContainers.RazorPages.RestClients.Cipas.Reunioes;
using Furiza.AspNetCore.WebApp.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.RazorPages.Pages.Reunioes.Atas
{
    [Authorize(Policy = FurizaPolicies.RequireEditorRights)]
    public class GerenciarParticipantesConvidadosModel : PageModel
    {
        private readonly IReunioesClient reunioesClient;

        [BindProperty]
        public Guid ReuniaoId { get; set; }

        [BindProperty]
        public Guid AtaId { get; set; }

        [BindProperty]
        public ReunioesAtasParticipantesConvidadosPost ReunioesAtasParticipantesConvidadosPost { get; set; }

        public GerenciarParticipantesConvidadosModel(IReunioesClient reunioesClient)
        {
            this.reunioesClient = reunioesClient ?? throw new ArgumentNullException(nameof(reunioesClient));
        }

        public void OnGet(Guid reuniaoId, Guid ataId)
        {
            ReuniaoId = reuniaoId;
            AtaId = ataId;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await reunioesClient.AtasParticipantesConvidadosPostAsync(ReuniaoId, AtaId, ReunioesAtasParticipantesConvidadosPost);

            return new JsonResult(
                new
                {
                    returnUrl = Url.Page("/Reunioes/Detalhar", new { id = ReuniaoId })
                });
        }
    }
}