using Furiza.eCipaOnContainers.RazorPages.RestClients.Cipas.Reunioes;
using Furiza.AspNetCore.WebApp.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.RazorPages.Pages.Reunioes.Atas.Assuntos
{
    [Authorize(Policy = FurizaPolicies.RequireEditorRights)]
    public class EditarModel : PageModel
    {
        private readonly IReunioesClient reunioesClient;

        [BindProperty]
        public Guid ReuniaoId { get; set; }

        [BindProperty]
        public Guid AtaId { get; set; }

        [BindProperty]
        public Guid AssuntoId { get; set; }

        [BindProperty]
        public ReunioesAtasAssuntosPut ReunioesAtasAssuntosPut { get; set; }

        [TempData]
        public string FeedbackSuccess { get; set; }

        public EditarModel(IReunioesClient reunioesClient)
        {
            this.reunioesClient = reunioesClient ?? throw new ArgumentNullException(nameof(reunioesClient));
        }

        public async Task OnGetAsync(Guid reuniaoId, Guid ataId, Guid assuntoId)
        {
            var reunioesGetResult = await reunioesClient.GetAsync(reuniaoId);
            var assunto = reunioesGetResult?.Ata?.Assuntos?.FirstOrDefault(a => a.AssuntoId == assuntoId);

            ReunioesAtasAssuntosPut = new ReunioesAtasAssuntosPut()
            {
                ClassificacaoDaInformacao = assunto?.ClassificacaoDaInformacao,
                Tipo = assunto?.Tipo,
                Descricao = assunto?.Descricao,
                Keywords = assunto?.Keywords
            };

            ReuniaoId = reuniaoId;
            AtaId = ataId;
            AssuntoId = assuntoId;
        }

        public async Task<IActionResult> OnPostAsync()
        {            
            await reunioesClient.AtasAssuntosPutAsync(ReuniaoId, AtaId, AssuntoId, ReunioesAtasAssuntosPut);

            FeedbackSuccess = $"O assunto da ata de reunião foi atualizado com êxito.";

            return new JsonResult(
                new
                {
                    returnUrl = Url.Page("/Reunioes/Detalhar", new { id = ReuniaoId })
                });
        }
    }
}