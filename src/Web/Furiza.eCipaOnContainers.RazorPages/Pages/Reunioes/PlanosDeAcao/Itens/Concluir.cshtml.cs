using Furiza.AspNetCore.WebApp.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Furiza.eCipaOnContainers.RazorPages.RestClients.PlanosDeAcao.PlanosDeAcao;
using System;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.RazorPages.Pages.Reunioes.PlanosDeAcao.Itens
{
    [Authorize(Policy = FurizaPolicies.RequireEditorRights)]
    public class ConcluirModel : PageModel
    {
        private readonly IPlanosDeAcaoClient planosDeAcaoClient;

        [BindProperty]
        public Guid ReuniaoId { get; set; }

        [BindProperty]
        public Guid PlanoDeAcaoId { get; set; }

        [BindProperty]
        public Guid ItemId { get; set; }

        [BindProperty]
        public PlanosDeAcaoItensConcluirPost PlanosDeAcaoItensConcluirPost { get; set; }

        public ConcluirModel(IPlanosDeAcaoClient planosDeAcaoClient)
        {
            this.planosDeAcaoClient = planosDeAcaoClient ?? throw new ArgumentNullException(nameof(planosDeAcaoClient));
        }

        public void OnGet(Guid reuniaoId, Guid planoDeAcaoId, Guid itemId)
        {
            ReuniaoId = reuniaoId;
            PlanoDeAcaoId = planoDeAcaoId;
            ItemId = itemId;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await planosDeAcaoClient.ItensConcluirPostAsync(PlanoDeAcaoId, ItemId, PlanosDeAcaoItensConcluirPost);

            return new JsonResult(
                new
                {
                    returnUrl = Url.Page("/Reunioes/Detalhar", new { id = ReuniaoId })
                });
        }
    }
}