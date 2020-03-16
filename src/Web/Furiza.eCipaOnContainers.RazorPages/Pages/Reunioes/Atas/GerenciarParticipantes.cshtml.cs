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

namespace Furiza.eCipaOnContainers.RazorPages.Pages.Reunioes.Atas
{
    [Authorize(Policy = FurizaPolicies.RequireEditorRights)]
    public class GerenciarParticipantesModel : PageModel
    {
        private readonly ICipasClient cipasClient;
        private readonly IReunioesClient reunioesClient;
        private readonly IUsersClient usersClient;

        public IEnumerable<CipasGetResult.CipasGetResultInnerMembro> Membros  { get; set; }

        [BindProperty]
        public Guid ReuniaoId { get; set; }

        [BindProperty]
        public Guid AtaId { get; set; }

        [BindProperty]
        public IEnumerable<string> Usernames { get; set; }

        public GerenciarParticipantesModel(ICipasClient cipasClient,
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
            foreach (var username in Usernames)
            {
                var user = await usersClient.GetAsync(username);

                if (!string.IsNullOrWhiteSpace(user?.FullName) && !string.IsNullOrWhiteSpace(user.Email))
                    await reunioesClient.AtasParticipantesPostAsync(ReuniaoId, AtaId, new ReunioesAtasParticipantesPost()
                    {
                        NomeCompleto = user.FullName,
                        Email = user.Email
                    });
            }

            return new JsonResult(
                new
                {
                    returnUrl = Url.Page("/Reunioes/Detalhar", new { id = ReuniaoId })
                });
        }

        public async Task OnPostDeleteAsync(Guid reuniaoId, Guid ataId, Guid participanteId)
        {
            await reunioesClient.AtasParticipantesDeleteAsync(reuniaoId, ataId, participanteId);
        }
    }
}