using Furiza.AspNetCore.WebApp.Configuration;
using Furiza.AspNetCore.WebApp.Configuration.RestClients.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Furiza.eCipaOnContainers.RazorPages.RestClients.Cipas.Cipas;
using Furiza.eCipaOnContainers.RazorPages.RestClients.PlanosDeAcao.PlanosDeAcao;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.RazorPages.Pages.Reunioes.PlanosDeAcao.Itens
{
    [Authorize(Policy = FurizaPolicies.RequireEditorRights)]
    public class AdicionarResponsavelModel : PageModel
    {
        private readonly ICipasClient cipasClient;
        private readonly IPlanosDeAcaoClient planosDeAcaoClient;
        private readonly IUsersClient usersClient;

        public IEnumerable<CipasGetResult.CipasGetResultInnerMembro> Membros { get; set; }

        [BindProperty]
        public Guid ReuniaoId { get; set; }

        [BindProperty]
        public Guid PlanoDeAcaoId { get; set; }

        [BindProperty]
        public Guid ItemId { get; set; }

        [Required]
        [BindProperty]
        public string UserName { get; set; }

        public AdicionarResponsavelModel(ICipasClient cipasClient, 
            IPlanosDeAcaoClient planosDeAcaoClient,
            IUsersClient usersClient)
        {
            this.cipasClient = cipasClient ?? throw new ArgumentNullException(nameof(cipasClient));
            this.planosDeAcaoClient = planosDeAcaoClient ?? throw new ArgumentNullException(nameof(planosDeAcaoClient));
            this.usersClient = usersClient ?? throw new ArgumentNullException(nameof(usersClient));
        }

        public async Task OnGetAsync(Guid cipaId, Guid reuniaoId, Guid planoDeAcaoId, Guid itemId)
        {
            Membros = (await cipasClient.GetAsync(cipaId))?.Membros;
            ReuniaoId = reuniaoId;
            PlanoDeAcaoId = planoDeAcaoId;
            ItemId = itemId;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await usersClient.GetAsync(UserName);

            if (!string.IsNullOrWhiteSpace(user?.FullName) && !string.IsNullOrWhiteSpace(user.Email))
                await planosDeAcaoClient.ItensResponsaveisPostAsync(PlanoDeAcaoId, ItemId, new PlanosDeAcaoItensResponsaveisPost()
                {
                    NomeCompleto = user.FullName,
                    Email = user.Email
                });

            return new JsonResult(
                new
                {
                    returnUrl = Url.Page("/Reunioes/Detalhar", new { id = ReuniaoId })
                });
        }
    }
}