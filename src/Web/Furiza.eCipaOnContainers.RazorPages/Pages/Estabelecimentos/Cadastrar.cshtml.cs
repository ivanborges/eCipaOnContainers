using Furiza.eCipaOnContainers.RazorPages.RestClients.Cipas.Cipas;
using Furiza.eCipaOnContainers.RazorPages.RestClients.Organizacoes.Estabelecimentos;
using Furiza.AspNetCore.WebApp.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.RazorPages.Pages.Estabelecimentos
{
    [Authorize(Policy = FurizaPolicies.RequireEditorRights)]
    public class CadastrarModel : PageModel
    {
        private readonly IEstabelecimentosClient estabelecimentosClient;
        private readonly ICipasClient cipasClient;

        [BindProperty]
        public EstabelecimentosPost EstabelecimentosPost { get; set; }

        public CipasGetManyResult CipasGetManyResult { get; set; }

        [TempData]
        public string FeedbackSuccess { get; set; }

        public CadastrarModel(IEstabelecimentosClient estabelecimentosClient,
            ICipasClient cipasClient)
        {
            this.estabelecimentosClient = estabelecimentosClient ?? throw new ArgumentNullException(nameof(estabelecimentosClient));
            this.cipasClient = cipasClient ?? throw new ArgumentNullException(nameof(cipasClient));
        }

        public async Task OnGetAsync()
        {
            CipasGetManyResult = await cipasClient.GetAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var result = await estabelecimentosClient.PostAsync(EstabelecimentosPost);

            FeedbackSuccess = $"O estabelecimento <b>{result.Codigo}</b> foi cadastrado com êxito. <a href='{Url.Page($"/Estabelecimentos/Detalhar", new { id = result.Id.Value })}'>Clique aqui</a> para acessar sua página de detalhes.";

            return new JsonResult(
                new
                {
                    returnUrl = Url.Page("/Estabelecimentos/Cadastrar")
                });
        }
    }
}