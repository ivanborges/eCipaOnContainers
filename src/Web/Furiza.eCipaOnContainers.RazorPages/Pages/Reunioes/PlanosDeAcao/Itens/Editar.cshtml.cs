using Furiza.AspNetCore.WebApp.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Furiza.eCipaOnContainers.RazorPages.RestClients.PlanosDeAcao.PlanosDeAcao;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.RazorPages.Pages.Reunioes.PlanosDeAcao.Itens
{
    [Authorize(Policy = FurizaPolicies.RequireEditorRights)]
    public class EditarModel : PageModel
    {
        private readonly IPlanosDeAcaoClient planosDeAcaoClient;

        [BindProperty]
        public Guid ReuniaoId { get; set; }

        [BindProperty]
        public Guid PlanoDeAcaoId { get; set; }

        [BindProperty]
        public Guid ItemId { get; set; }

        [BindProperty]
        public PlanosDeAcaoItensPut PlanosDeAcaoItensPut { get; set; }

        [TempData]
        public string FeedbackSuccess { get; set; }

        public EditarModel(IPlanosDeAcaoClient planosDeAcaoClient)
        {
            this.planosDeAcaoClient = planosDeAcaoClient ?? throw new ArgumentNullException(nameof(planosDeAcaoClient));
        }

        public async Task OnGetAsync(Guid reuniaoId, Guid planoDeAcaoId, Guid itemId)
        {
            var planosDeAcaoGetResult = await planosDeAcaoClient.GetAsync(planoDeAcaoId);
            var item = planosDeAcaoGetResult.Itens?.FirstOrDefault(i => i.ItemId == itemId);

            PlanosDeAcaoItensPut = new PlanosDeAcaoItensPut()
            {
                Prazo = item?.Prazo,
                Acao = item?.Acao
            };

            ReuniaoId = reuniaoId;
            PlanoDeAcaoId = planoDeAcaoId;
            ItemId = itemId;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await planosDeAcaoClient.ItensPutAsync(PlanoDeAcaoId, ItemId, PlanosDeAcaoItensPut);

            FeedbackSuccess = $"O item do plano de ação da reunião foi atualizado com êxito.";

            return new JsonResult(
                new
                {
                    returnUrl = Url.Page("/Reunioes/Detalhar", new { id = ReuniaoId })
                });
        }
    }
}