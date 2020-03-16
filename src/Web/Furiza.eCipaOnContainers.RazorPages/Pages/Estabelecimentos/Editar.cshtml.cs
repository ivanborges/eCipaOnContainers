using Furiza.AspNetCore.WebApp.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Furiza.eCipaOnContainers.RazorPages.RestClients.Organizacoes.Estabelecimentos;
using System;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.RazorPages.Pages.Estabelecimentos
{
    [Authorize(Policy = FurizaPolicies.RequireEditorRights)]
    public class EditarModel : PageModel
    {
        private readonly IEstabelecimentosClient estabelecimentosClient;

        [BindProperty]
        public Guid EstabelecimentoId { get; set; }

        [BindProperty]
        public EstabelecimentosPut EstabelecimentosPut { get; set; }

        [TempData]
        public string FeedbackSuccess { get; set; }

        public EditarModel(IEstabelecimentosClient estabelecimentosClient)
        {
            this.estabelecimentosClient = estabelecimentosClient ?? throw new ArgumentNullException(nameof(estabelecimentosClient));
        }

        public async Task OnGetAsync(Guid id)
        {
            var estabelecimentosGetResult = await estabelecimentosClient.GetAsync(id);
            EstabelecimentosPut = new EstabelecimentosPut()
            {
                Codigo = estabelecimentosGetResult.Codigo,
                Nome = estabelecimentosGetResult.Nome
            };
            EstabelecimentoId = id;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await estabelecimentosClient.PutAsync(EstabelecimentoId, EstabelecimentosPut);

            FeedbackSuccess = $"O estabelecimento <b>{EstabelecimentosPut.Codigo}</b> foi atualizado com êxito.";

            return new JsonResult(
                new
                {
                    returnUrl = Url.Page("/Estabelecimentos/Detalhar", new { id = EstabelecimentoId })
                });
        }
    }
}