using Furiza.eCipaOnContainers.RazorPages.RestClients.Cipas.Reunioes;
using Furiza.AspNetCore.WebApp.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.RazorPages.Pages.Reunioes.Atas
{
    [Authorize(Policy = FurizaPolicies.RequireEditorRights)]
    public class GerenciarAssuntosModel : PageModel
    {
        private readonly IReunioesClient reunioesClient;

        [BindProperty]
        public Guid ReuniaoId { get; set; }

        [BindProperty]
        public Guid AtaId { get; set; }

        [BindProperty]
        public ReunioesAtasAssuntosPost ReunioesAtasAssuntosPost { get; set; }

        public GerenciarAssuntosModel(IReunioesClient reunioesClient)
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
            await reunioesClient.AtasAssuntosPostAsync(ReuniaoId, AtaId, ReunioesAtasAssuntosPost);

            return new JsonResult(
                new
                {
                    returnUrl = Url.Page("/Reunioes/Detalhar", new { id = ReuniaoId })
                });
        }

        public async Task OnPostDeleteAsync(Guid reuniaoId, Guid ataId, Guid assuntoId)
        {
            await reunioesClient.AtasAssuntosDeleteAsync(reuniaoId, ataId, assuntoId);
        }
        
        //TODO: arrumar esse método para tirar ele da política do atributo de autorizaçao!
        public async Task<IActionResult> OnGetAlteracoesPartialAsync(Guid reuniaoId, Guid ataId, Guid assuntoId)
        {
            var alteracoes = await reunioesClient.GetAtasAssuntosAlteracoesAsync(reuniaoId, ataId, assuntoId);

            return new PartialViewResult()
            {
                ViewName = "_AlteracoesAssuntosPartial",
                ViewData = new ViewDataDictionary<ReunioesGetAtasAssuntosAlteracoesResult>(ViewData, alteracoes)
            };
        }
    }
}