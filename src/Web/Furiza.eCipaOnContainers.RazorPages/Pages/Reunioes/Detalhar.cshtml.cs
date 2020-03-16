using Furiza.eCipaOnContainers.RazorPages.RestClients.Cipas.Reunioes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;
using Furiza.eCipaOnContainers.RazorPages.RestClients.PlanosDeAcao.PlanosDeAcao;

namespace Furiza.eCipaOnContainers.RazorPages.Pages.Reunioes
{
    [Authorize]
    public class DetalharModel : PageModel
    {
        private readonly IReunioesClient reunioesClient;
        private readonly IPlanosDeAcaoClient planosDeAcaoClient;

        public ReunioesGetResult ReunioesGetResult { get; set; }
        public PlanosDeAcaoGetResult PlanosDeAcaoGetResult { get; set; }

        public DetalharModel(IReunioesClient reunioesClient,
            IPlanosDeAcaoClient planosDeAcaoClient)
        {
            this.reunioesClient = reunioesClient ?? throw new ArgumentNullException(nameof(reunioesClient));
            this.planosDeAcaoClient = planosDeAcaoClient ?? throw new ArgumentNullException(nameof(planosDeAcaoClient));
        }

        public async Task OnGetAsync(Guid id)
        {
            ReunioesGetResult = await reunioesClient.GetAsync(id);
            if (ReunioesGetResult != null && ReunioesGetResult.PlanoDeAcaoId.HasValue)
                PlanosDeAcaoGetResult = await planosDeAcaoClient.GetAsync(ReunioesGetResult.PlanoDeAcaoId.Value);
        }

        public async Task OnPostCancelarAsync(Guid reuniaoId)
        {
            await reunioesClient.CancelarPostAsync(reuniaoId);
        }

        public async Task OnPostFinalizarAtaAsync(Guid reuniaoId, Guid ataId)
        {
            await reunioesClient.AtasFinalizarPostAsync(reuniaoId, ataId);
        }

        public async Task OnPostReabrirAtaAsync(Guid reuniaoId, Guid ataId)
        {
            await reunioesClient.AtasReabrirPostAsync(reuniaoId, ataId);
        }

        public async Task OnPostAprovarAtaAsync(Guid reuniaoId, Guid ataId)
        {
            await reunioesClient.AtasAprovarPostAsync(reuniaoId, ataId);
        }

        public async Task OnPostCriarPlanoDeAcaoAsync(Guid reuniaoId)
        {
            var postResult = await planosDeAcaoClient.PostAsync();

            await reunioesClient.PlanosDeAcaoPostAsync(reuniaoId, new ReunioesPlanosDeAcaoPost()
            {
                PlanoDeAcaoId = postResult.Id
            });
        }
    }
}