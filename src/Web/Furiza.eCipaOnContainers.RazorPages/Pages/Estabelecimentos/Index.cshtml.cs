using Furiza.eCipaOnContainers.RazorPages.RestClients.Organizacoes.Estabelecimentos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.RazorPages.Pages.Estabelecimentos
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IEstabelecimentosClient estabelecimentosClient;

        [BindProperty]
        public EstabelecimentosGetMany EstabelecimentosGetMany { get; set; }

        public IndexModel(IEstabelecimentosClient estabelecimentosClient)
        {
            this.estabelecimentosClient = estabelecimentosClient ?? throw new ArgumentNullException(nameof(estabelecimentosClient));
        }

        public void OnGet() { }

        public async Task<IActionResult> OnPostEstabelecimentosPartialAsync()
        {
            var estabelecimentosGetManyResult = await estabelecimentosClient.GetAsync(EstabelecimentosGetMany);

            return new PartialViewResult()
            {
                ViewName = "_EstabelecimentosPartial",
                ViewData = new ViewDataDictionary<EstabelecimentosGetManyResult>(ViewData, estabelecimentosGetManyResult)
            };

            //construção abaixo não funciona, simplesmente não consegue interpretar o tipo da variável 'estabelecimentosGetAllResult' e fica considerando que o Model da Partial é 'IndexModel'.
            //return Partial("_EstabelecimentosPartial", estabelecimentosGetAllResult);
        }
    }
}