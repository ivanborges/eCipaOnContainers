using Refit;
using System;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.RazorPages.RestClients.Organizacoes.Estabelecimentos
{
    public interface IEstabelecimentosClient
    {
        [Get("/api/v1/Estabelecimentos")]
        Task<EstabelecimentosGetManyResult> GetAsync();

        [Get("/api/v1/Estabelecimentos")]
        Task<EstabelecimentosGetManyResult> GetAsync(EstabelecimentosGetMany estabelecimentosGetMany);

        [Get("/api/v1/Estabelecimentos/{id}")]
        Task<EstabelecimentosGetResult> GetAsync(Guid id);

        [Post("/api/v1/Estabelecimentos")]
        Task<PostResult> PostAsync(EstabelecimentosPost estabelecimentosPost);

        [Put("/api/v1/Estabelecimentos/{id}")]
        Task PutAsync(Guid id, EstabelecimentosPut estabelecimentosPut);

        [Post("/api/v1/Estabelecimentos/{id}/AlternarStatusDeAtividade")]
        Task AlternarStatusDeAtividadePostAsync(Guid id);

        [Get("/api/v1/Estabelecimentos/{id}/Cipas")]
        Task<EstabelecimentosCipasGetResult> CipasGetAsync(Guid id);
    }
}