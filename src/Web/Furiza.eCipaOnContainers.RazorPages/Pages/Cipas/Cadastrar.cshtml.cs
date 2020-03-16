using Furiza.eCipaOnContainers.RazorPages.RestClients.Cipas.Cipas;
using Furiza.eCipaOnContainers.RazorPages.RestClients.Organizacoes.Empresas;
using Furiza.eCipaOnContainers.RazorPages.RestClients.Organizacoes.Fornecedores;
using Furiza.AspNetCore.WebApp.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.RazorPages.Pages.Cipas
{
    [Authorize(Policy = FurizaPolicies.RequireEditorRights)]
    public class CadastrarModel : PageModel
    {
        private readonly ICipasClient cipasClient;

        [BindProperty]
        public CipasPost CipasPost { get; set; }

        public EmpresasGetManyResult EmpresasGetManyResult { get; set; }
        public FornecedoresGetManyResult FornecedoresGetManyResult { get; set; }

        [TempData]
        public string FeedbackSuccess { get; set; }

        public CadastrarModel(ICipasClient cipasClient)
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

        public async Task<IActionResult> OnPostAsync()
        {
            var result = await cipasClient.PostAsync(CipasPost);

            FeedbackSuccess = $"A cipa <b>{result.Codigo}</b> foi cadastrada com êxito. <a href='{Url.Page($"/Cipas/Detalhar", new { id = result.Id.Value })}'>Clique aqui</a> para acessar sua página de detalhes.";

            return new JsonResult(
                new
                {
                    returnUrl = Url.Page("/Cipas/Cadastrar")
                });
        }
    }
}