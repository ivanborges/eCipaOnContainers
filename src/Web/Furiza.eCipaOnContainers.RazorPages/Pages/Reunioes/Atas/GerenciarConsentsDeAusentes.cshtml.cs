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
    public class GerenciarConsentsDeAusentesModel : PageModel
    {
        private readonly IReunioesClient reunioesClient;

        [BindProperty]
        public Guid ReuniaoId { get; set; }

        [BindProperty]
        public Guid AtaId { get; set; }

        [BindProperty]
        public Guid AusenteId { get; set; }

        [BindProperty]
        public ReunioesAtasAusentesConsentsPost ReunioesAtasAusentesConsentsPost { get; set; }

        public GerenciarConsentsDeAusentesModel(IReunioesClient reunioesClient)
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
            await reunioesClient.AtasAusentesConsentsPostAsync(ReuniaoId, AtaId, AusenteId, ReunioesAtasAusentesConsentsPost);

            return new JsonResult(
                new
                {
                    returnUrl = Url.Page("/Reunioes/Detalhar", new { id = ReuniaoId })
                });
        }

        public async Task<IActionResult> OnGetConsentsPartialAsync(Guid reuniaoId, Guid ataId, Guid ausenteId)
        {
            var consents = await reunioesClient.GetAtasAusentesConsentsAsync(reuniaoId, ataId, ausenteId);

            return new PartialViewResult()
            {
                ViewName = "_ConsentsAusentesPartial",
                ViewData = new ViewDataDictionary<ReunioesGetAtasAusentesConsentsResult>(ViewData, consents)
            };
        }
    }
}