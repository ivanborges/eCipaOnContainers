using Furiza.eCipaOnContainers.RazorPages.RestClients.Cipas.Cipas;
using Furiza.eCipaOnContainers.RazorPages.RestClients.Organizacoes.Estabelecimentos;
using Furiza.AspNetCore.WebApp.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.RazorPages.Pages.Cipas
{
    [Authorize(Policy = FurizaPolicies.RequireEditorRights)]
    public class GerenciarEstabelecimentosModel : PageModel
    {
        private readonly IEstabelecimentosClient estabelecimentosClient;
        private readonly ICipasClient cipasClient;

        public EstabelecimentosGetManyResult EstabelecimentosGetManyResult { get; set; }

        [BindProperty]
        public Guid CipaId { get; set; }

        [BindProperty]
        public CipasEstabelecimentosPost CipasEstabelecimentosPost { get; set; }

        public GerenciarEstabelecimentosModel(IEstabelecimentosClient estabelecimentosClient,
            ICipasClient cipasClient)
        {
            this.estabelecimentosClient = estabelecimentosClient ?? throw new ArgumentNullException(nameof(estabelecimentosClient));
            this.cipasClient = cipasClient ?? throw new ArgumentNullException(nameof(cipasClient));
        }

        public IActionResult OnGetLocalizarEstabelecimentoPartial(Guid cipaId)
        {
            return new PartialViewResult()
            {
                ViewName = "_LocalizarEstabelecimentoPartial",
                ViewData = new ViewDataDictionary<Guid>(ViewData, cipaId)
            };
        }

        public async Task OnGetAsync(Guid cipaId, string codigo, string nome)
        {
            CipaId = cipaId;

            EstabelecimentosGetManyResult = await estabelecimentosClient.GetAsync(new EstabelecimentosGetMany()
            {
                Codigo = codigo,
                Nome = nome
            });
        }

        public async Task OnPostAsync()
        {
            await cipasClient.EstabelecimentosPostAsync(CipaId, CipasEstabelecimentosPost);
        }

        public async Task OnPostDeleteAsync(Guid cipaId, Guid estabelecimentoId)
        {
            await cipasClient.EstabelecimentosDeleteAsync(cipaId, estabelecimentoId);
        }
    }
}