using Furiza.eCipaOnContainers.RazorPages.RestClients.Cipas.Reunioes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.RazorPages.Pages.Reunioes.Atas
{
    [Authorize]
    public class GerenciarConsentsDeParticipantesModel : PageModel
    {
        private readonly IReunioesClient reunioesClient;

        [BindProperty]
        public Guid ReuniaoId { get; set; }

        [BindProperty]
        public Guid AtaId { get; set; }

        [BindProperty]
        public Guid ParticipanteId { get; set; }

        [BindProperty]
        public ReunioesAtasParticipantesConsentsPost ReunioesAtasParticipantesConsentsPost { get; set; }

        public GerenciarConsentsDeParticipantesModel(IReunioesClient reunioesClient)
        {
            this.reunioesClient = reunioesClient ?? throw new ArgumentNullException(nameof(reunioesClient));
        }

        public void OnGet(Guid reuniaoId, Guid ataId, Guid participanteId)
        {
            ReuniaoId = reuniaoId;
            AtaId = ataId;
            ParticipanteId = participanteId;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await reunioesClient.AtasParticipantesConsentsPostAsync(ReuniaoId, AtaId, ParticipanteId, ReunioesAtasParticipantesConsentsPost);

            return new JsonResult(
                new
                {
                    returnUrl = Url.Page("/Reunioes/Detalhar", new { id = ReuniaoId })
                });
        }

        public async Task<IActionResult> OnGetConsentsPartialAsync(Guid reuniaoId, Guid ataId, Guid participanteId)
        {
            var consents = await reunioesClient.GetAtasParticipantesConsentsAsync(reuniaoId, ataId, participanteId);

            return new PartialViewResult()
            {
                ViewName = "_ConsentsParticipantesPartial",
                ViewData = new ViewDataDictionary<ReunioesGetAtasParticipantesConsentsResult>(ViewData, consents)
            };
        }
    }
}