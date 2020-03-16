using Furiza.eCipaOnContainers.RazorPages.RestClients.Organizacoes.Empresas;
using Furiza.eCipaOnContainers.RazorPages.RestClients.Organizacoes.Fornecedores;
using Furiza.eCipaOnContainers.RazorPages.RestClients.Organizacoes.Orgaos;
using Furiza.AspNetCore.WebApp.Configuration;
using Furiza.AspNetCore.WebApp.Configuration.RestClients.RoleAssignments;
using Furiza.AspNetCore.WebApp.Configuration.RestClients.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.RazorPages.Pages.Usuarios
{
    [Authorize(Policy = FurizaPolicies.RequireAdministratorRights)]
    public class CadastrarModel : PageModel
    {
        private readonly IUsersClient usersClient;
        private readonly IRoleAssignmentsClient roleAssignmentsClient;

        [BindProperty]
        public UsersPost UsersPost { get; set; }

        [BindProperty]
        public RoleAssignmentsPost RoleAssignmentsPost { get; set; }

        public EmpresasGetManyResult EmpresasGetManyResult { get; set; }
        public FornecedoresGetManyResult FornecedoresGetManyResult { get; set; }
        public OrgaosGetManyResult OrgaosGetManyResult { get; set; }

        [TempData]
        public string FeedbackSuccess { get; set; }

        public CadastrarModel(IUsersClient usersClient,
            IRoleAssignmentsClient roleAssignmentsClient)
        {
            this.usersClient = usersClient ?? throw new ArgumentNullException(nameof(usersClient));
            this.roleAssignmentsClient = roleAssignmentsClient ?? throw new ArgumentNullException(nameof(roleAssignmentsClient));
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
                Fornecedores = new FornecedoresGetManyResult.FornecedoresGetManyResultInnerFornecedor[] {}
            };

            OrgaosGetManyResult = new OrgaosGetManyResult()
            {
                Orgaos = new OrgaosGetManyResult.OrgaosGetManyResultInnerOrgao[] 
                {
                    new OrgaosGetManyResult.OrgaosGetManyResultInnerOrgao()
                    {
                        Codigo = 5,
                        Nome = "DPR"
                    }
                }
            };
        }

        public async Task<IActionResult> OnPostAsync()
        {
            UsersPost.GeneratePassword = true;
            var result = await usersClient.PostAsync(UsersPost);

            RoleAssignmentsPost.UserName = result.Code;
            if (string.IsNullOrWhiteSpace(RoleAssignmentsPost.RoleName))
                RoleAssignmentsPost.RoleName = Furiza.Base.Core.Identity.Abstractions.FurizaMasterRoles.Viewer;

            await roleAssignmentsClient.PostAsync(RoleAssignmentsPost);

            FeedbackSuccess = $"A conta de usuário com login <b>{result.Code}</b> foi cadastrada com êxito e uma senha foi gerada e enviada para o email informado. " +
                $"A role <b>{RoleAssignmentsPost.RoleName}</b> foi atribuída a esta conta. " +
                $"Para que esta conta de usuário consiga acessar a aplicação, é necessário que o respectivo proprietário confirme o endereço de email.";

            return new JsonResult(
                new
                {
                    returnUrl = Url.Page("/Usuarios/Cadastrar")
                });
        }
    }
}