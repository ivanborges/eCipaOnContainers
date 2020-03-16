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
    public class IndexModel : PageModel
    {
        private readonly IUsersClient usersClient;
        private readonly IRoleAssignmentsClient roleAssignmentsClient;

        public UsersGetManyResult UsersGetManyResult { get; set; }

        public IndexModel(IUsersClient usersClient,
            IRoleAssignmentsClient roleAssignmentsClient)
        {
            this.usersClient = usersClient ?? throw new ArgumentNullException(nameof(usersClient));
            this.roleAssignmentsClient = roleAssignmentsClient ?? throw new ArgumentNullException(nameof(roleAssignmentsClient));
        }

        public async Task OnGetAsync()
        {
            UsersGetManyResult = await usersClient.GetAsync();            
        }

        public async Task OnPostAlterarRoleAsync(string username, string currentRole, string newRole)
        {
            if (!string.IsNullOrWhiteSpace(currentRole))
            {
                var roleAssignmentsDelete = new RoleAssignmentsDelete()
                {
                    UserName = username,
                    RoleName = currentRole
                };

                await roleAssignmentsClient.DeleteAsync(roleAssignmentsDelete);
            }

            if (!string.IsNullOrWhiteSpace(newRole))
            {
                var roleAssignmentsPost = new RoleAssignmentsPost()
                {
                    UserName = username,
                    RoleName = newRole
                };
                await roleAssignmentsClient.PostAsync(roleAssignmentsPost);
            }
        }

        public async Task<IActionResult> OnPostResetarSenhaAsync(string username)
        {
            var usersResetPasswordPostResult = await usersClient.ResetPasswordPostAsync(username);

            return new JsonResult(usersResetPasswordPostResult);
        }

        public async Task OnPostConfirmEmailAsync(string username)
        {
            await usersClient.ConfirmEmailPostAsync(username);
        }

        public async Task OnPostLockAsync(string username)
        {
            await usersClient.LockPostAsync(username);
        }

        public async Task OnPostUnlockAsync(string username)
        {
            await usersClient.UnlockPostAsync(username);
        }

        public async Task OnPostDeleteAsync(string username)
        {
            await usersClient.DeleteAsync(username);
        }
    }
}