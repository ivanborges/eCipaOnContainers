using Furiza.eCipaOnContainers.RazorPages.RestClients.Cipas.Cipas;
using Furiza.eCipaOnContainers.RazorPages.RestClients.Cipas.Reunioes;
using Furiza.AspNetCore.WebApp.Configuration;
using Furiza.AspNetCore.WebApp.Configuration.RestClients.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Furiza.eCipaOnContainers.RazorPages.Pages.Reunioes.Atas
{
    [Authorize(Policy = FurizaPolicies.RequireEditorRights)]
    public class GerenciarAusentesModel : PageModel
    {
        private readonly ICipasClient cipasClient;
        private readonly IReunioesClient reunioesClient;
        private readonly IUsersClient usersClient;

        public IEnumerable<CipasGetResult.CipasGetResultInnerMembro> Membros { get; set; }

        [BindProperty]
        public Guid ReuniaoId { get; set; }

        [BindProperty]
        public Guid AtaId { get; set; }

        [Required]
        [BindProperty]
        public string UserName { get; set; }

        [Required]
        [BindProperty]
        public JustificativaAusencia? Justificativa { get; set; }

        public GerenciarAusentesModel(ICipasClient cipasClient,
            IReunioesClient reunioesClient,
            IUsersClient usersClient)
        {
            this.cipasClient = cipasClient ?? throw new ArgumentNullException(nameof(cipasClient));
            this.reunioesClient = reunioesClient ?? throw new ArgumentNullException(nameof(reunioesClient));
            this.usersClient = usersClient ?? throw new ArgumentNullException(nameof(usersClient));
        }

        public async Task OnGetAsync(Guid cipaId, Guid reuniaoId, Guid ataId)
        {
            var todosMembros = (await cipasClient.GetAsync(cipaId))?.Membros;

            var reuniao = await reunioesClient.GetAsync(reuniaoId);

            Membros = todosMembros.Where(m => !reuniao.Ata.Participantes.Any(p => p.ParticipanteNomeCompleto == m.NomeCompleto) &&
                !reuniao.Ata.Ausentes.Any(a => a.AusenteNomeCompleto == m.NomeCompleto));

            ReuniaoId = reuniaoId;
            AtaId = ataId;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await usersClient.GetAsync(UserName);

            if (!string.IsNullOrWhiteSpace(user?.FullName) && !string.IsNullOrWhiteSpace(user.Email))
                await reunioesClient.AtasAusentesPostAsync(ReuniaoId, AtaId, new ReunioesAtasAusentesPost()
                {
                    NomeCompleto = user.FullName,
                    Email = user.Email,
                    Justificativa = Justificativa
                });

            return new JsonResult(
                new
                {
                    returnUrl = Url.Page("/Reunioes/Detalhar", new { id = ReuniaoId })
                });
        }

        public async Task OnPostDeleteAsync(Guid reuniaoId, Guid ataId, Guid ausenteId)
        {
            await reunioesClient.AtasAusentesDeleteAsync(reuniaoId, ataId, ausenteId);
        }
    }
}