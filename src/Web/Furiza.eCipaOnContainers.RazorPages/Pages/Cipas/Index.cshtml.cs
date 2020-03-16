using Furiza.eCipaOnContainers.RazorPages.RestClients.Cipas.Cipas;
using Furiza.eCipaOnContainers.RazorPages.RestClients.Organizacoes.Empresas;
using Furiza.eCipaOnContainers.RazorPages.RestClients.Organizacoes.Fornecedores;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.RazorPages.Pages.Cipas
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ICipasClient cipasClient;

        [BindProperty]
        public CipasGetMany CipasGetMany { get; set; }

        public EmpresasGetManyResult EmpresasGetManyResult { get; set; }
        public FornecedoresGetManyResult FornecedoresGetManyResult { get; set; }

        public IndexModel(ICipasClient cipasClient)
        {
            this.cipasClient = cipasClient ?? throw new ArgumentNullException(nameof(cipasClient));
        }

        public void OnGet()
        {
            // TODO: situação temporária para efeito de montagem da UI.

            EmpresasGetManyResult = new EmpresasGetManyResult()
            {
                Empresas = new EmpresasGetManyResult.EmpresasGetManyResultInnerEmpresa[]
                {
                    new EmpresasGetManyResult.EmpresasGetManyResultInnerEmpresa()
                    {
                        Codigo = 500,
                        Nome = "CEMIG"
                    },
                    new EmpresasGetManyResult.EmpresasGetManyResultInnerEmpresa()
                    {
                        Codigo = 510,
                        Nome = "CEMIG GT"
                    },
                    new EmpresasGetManyResult.EmpresasGetManyResultInnerEmpresa()
                    {
                        Codigo = 530,
                        Nome = "CEMIG D"
                    }
                }
            };

            FornecedoresGetManyResult = new FornecedoresGetManyResult()
            {
                Fornecedores = new FornecedoresGetManyResult.FornecedoresGetManyResultInnerFornecedor[] { }
            };
        }

        public async Task<IActionResult> OnPostCipasPartialAsync()
        {
            var cipasGetManyResult = await cipasClient.GetAsync(CipasGetMany);

            return new PartialViewResult()
            {
                ViewName = "_CipasPartial",
                ViewData = new ViewDataDictionary<CipasGetManyResult>(ViewData, cipasGetManyResult)
            };
        }
    }
}