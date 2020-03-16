using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Furiza.eCipaOnContainers.RazorPages.RestClients.Organizacoes.Estabelecimentos;
using System;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.RazorPages.Pages.Estabelecimentos
{
    [Authorize]
    public class DetalharModel : PageModel
    {
        private readonly IEstabelecimentosClient estabelecimentosClient;

        public EstabelecimentosGetResult EstabelecimentosGetResult { get; set; }

        public EstabelecimentosCipasGetResult EstabelecimentosCipasGetResult { get; set; }

        public DetalharModel(IEstabelecimentosClient estabelecimentosClient)
        {
            this.estabelecimentosClient = estabelecimentosClient ?? throw new ArgumentNullException(nameof(estabelecimentosClient));
        }

        public async Task OnGetAsync(Guid id)
        {
            EstabelecimentosGetResult = await estabelecimentosClient.GetAsync(id);
            EstabelecimentosCipasGetResult = await estabelecimentosClient.CipasGetAsync(id);
        }

        public async Task OnPostAlternarStatusDeAtividadeAsync(Guid estabelecimentoId)
        {
            await estabelecimentosClient.AlternarStatusDeAtividadePostAsync(estabelecimentoId);
        }
    }
}