using Furiza.eCipaOnContainers.RazorPages.RestClients.Cipas.Cipas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.RazorPages.Pages.Cipas
{
    [Authorize]
    public class DetalharModel : PageModel
    {
        private readonly ICipasClient cipasClient;

        public CipasGetResult CipasGetResult { get; set; }

        public CipasEstabelecimentosGetResult CipasEstabelecimentosGetResult { get; set; }

        public CipasReunioesGetResult CipasReunioesGetResult { get; set; }

        public DetalharModel(ICipasClient cipasClient)
        {
            this.cipasClient = cipasClient ?? throw new ArgumentNullException(nameof(cipasClient));
        }

        public async Task OnGetAsync(Guid id)
        {
            CipasGetResult = await cipasClient.GetAsync(id);
            CipasEstabelecimentosGetResult = await cipasClient.EstabelecimentosGetAsync(id);
            CipasReunioesGetResult = await cipasClient.ReunioesGetAsync(id);
        }

        public async Task OnPostAlternarStatusDeAtividadeAsync(Guid cipaId)
        {
            await cipasClient.AlternarStatusDeAtividadePostAsync(cipaId);
        }
    }
}