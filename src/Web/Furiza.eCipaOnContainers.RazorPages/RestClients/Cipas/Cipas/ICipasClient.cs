using Refit;
using System;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.RazorPages.RestClients.Cipas.Cipas
{
    public interface ICipasClient
    {
        [Get("/api/v1/Cipas")]
        Task<CipasGetManyResult> GetAsync();

        [Get("/api/v1/Cipas")]
        Task<CipasGetManyResult> GetAsync(CipasGetMany cipasGetMany);

        [Get("/api/v1/Cipas/{id}")]
        Task<CipasGetResult> GetAsync(Guid id);

        [Get("/api/v1/Cipas/AtivasDoUsuarioLogado")]
        Task<CipasGetAtivasDoUsuarioLogadoResult> GetAtivasDoUsuarioLogadoAsync();

        [Post("/api/v1/Cipas")]
        Task<PostResult> PostAsync(CipasPost cipasPost);

        [Put("/api/v1/Cipas/{id}")]
        Task PutAsync(Guid id, CipasPut cipasPut);

        [Get("/api/v1/Cipas/{id}/Estabelecimentos")]
        Task<CipasEstabelecimentosGetResult> EstabelecimentosGetAsync(Guid id);

        [Post("/api/v1/Cipas/{id}/Estabelecimentos")]
        Task EstabelecimentosPostAsync(Guid id, CipasEstabelecimentosPost cipasEstabelecimentosPost);

        [Delete("/api/v1/Cipas/{id}/Estabelecimentos/{estabelecimentoId}")]
        Task EstabelecimentosDeleteAsync(Guid id, Guid estabelecimentoId);

        [Get("/api/v1/Cipas/{id}/Reunioes")]
        Task<CipasReunioesGetResult> ReunioesGetAsync(Guid id);

        [Post("/api/v1/Cipas/{id}/Membros")]
        Task MembrosPostAsync(Guid id, CipasMembrosPost cipasMembrosPost);

        [Delete("/api/v1/Cipas/{id}/Membros/{membroId}")]
        Task MembrosDeleteAsync(Guid id, Guid membroId);

        [Post("/api/v1/Cipas/{id}/AlternarStatusDeAtividade")]
        Task AlternarStatusDeAtividadePostAsync(Guid id);
    }
}