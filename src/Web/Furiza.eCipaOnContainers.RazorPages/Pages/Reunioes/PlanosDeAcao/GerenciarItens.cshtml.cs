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

namespace Furiza.eCipaOnContainers.RazorPages.Pages.Reunioes.PlanosDeAcao
{
    [Authorize(Policy = FurizaPolicies.RequireEditorRights)]
    public class GerenciarItensModel : PageModel
    {
        private readonly ICipasClient cipasClient;
        private readonly IPlanosDeAcaoClient planosDeAcaoClient;
        private readonly IUsersClient usersClient;

        public IEnumerable<CipasGetResult.CipasGetResultInnerMembro> Membros { get; set; }

        [BindProperty]
        public Guid ReuniaoId { get; set; }

        [BindProperty]
        public Guid PlanoDeAcaoId { get; set; }

        [Required]
        [BindProperty]
        public DateTime? Prazo { get; set; }

        [Required]
        [BindProperty]
        public string UserName { get; set; }

        [BindProperty]
        public string Descricao { get; set; }

        [BindProperty]
        public string Acao { get; set; }

        public GerenciarItensModel(ICipasClient cipasClient,
            IPlanosDeAcaoClient planosDeAcaoClient,
            IUsersClient usersClient)
        {
            this.cipasClient = cipasClient ?? throw new ArgumentNullException(nameof(cipasClient));
            this.planosDeAcaoClient = planosDeAcaoClient ?? throw new ArgumentNullException(nameof(planosDeAcaoClient));
            this.usersClient = usersClient ?? throw new ArgumentNullException(nameof(usersClient));
        }

        public async Task OnGetAsync(Guid cipaId, Guid reuniaoId, Guid planoDeAcaoId)
        {
            Membros = (await cipasClient.GetAsync(cipaId))?.Membros;
            ReuniaoId = reuniaoId;
            PlanoDeAcaoId = planoDeAcaoId;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await usersClient.GetAsync(UserName);

            if (!string.IsNullOrWhiteSpace(user?.FullName) && !string.IsNullOrWhiteSpace(user.Email))
                await planosDeAcaoClient.ItensPostAsync(PlanoDeAcaoId, new PlanosDeAcaoItensPost()
                {
                    Prazo = Prazo,
                    NomeCompletoResponsavel = user.FullName,
                    EmailResponsavel = user.Email,
                    Descricao = Descricao,
                    Acao = Acao
                });

            return new JsonResult(
                new
                {
                    returnUrl = Url.Page("/Reunioes/Detalhar", new { id = ReuniaoId })
                });
        }

        public async Task OnPostDeleteItemAsync(Guid planoDeAcaoId, Guid itemId)
        {
            await planosDeAcaoClient.ItensDeleteAsync(planoDeAcaoId, itemId);
        }

        //public async Task OnPostConcluirItemAsync(Guid planoDeAcaoId, Guid itemId)
        //{
        //    await planosDeAcaoClient.ItensConcluirPostAsync(planoDeAcaoId, itemId);
        //}

        public async Task OnPostCancelarItemAsync(Guid planoDeAcaoId, Guid itemId)
        {
            await planosDeAcaoClient.ItensCancelarPostAsync(planoDeAcaoId, itemId);
        }

        public async Task OnPostRemoverResponsavelAsync(Guid planoDeAcaoId, Guid itemId, Guid responsavelId)
        {
            await planosDeAcaoClient.ItensResponsaveisDeleteAsync(planoDeAcaoId, itemId, responsavelId);
        }
    }
}