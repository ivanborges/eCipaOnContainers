using Refit;
using System;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.RazorPages.RestClients.PlanosDeAcao.PlanosDeAcao
{
    public interface IPlanosDeAcaoClient
    {
        [Get("/api/v1/PlanosDeAcao/{id}")]
        Task<PlanosDeAcaoGetResult> GetAsync(Guid id);

        [Get("/api/v1/PlanosDeAcao/Itens/PendentesAtribuidosAoUsuarioLogado")]
        Task<PlanosDeAcaoGetItensPendentesAtribuidosAoUsuarioLogadoResult> GetItensPendentesAtribuidosAoUsuarioLogadoAsync();

        [Post("/api/v1/PlanosDeAcao")]
        Task<PostResult> PostAsync();

        [Post("/api/v1/PlanosDeAcao/{id}/Itens")]
        Task ItensPostAsync(Guid id, PlanosDeAcaoItensPost planosDeAcaoItensPost);

        [Post("/api/v1/PlanosDeAcao/{id}/Itens/Concluir")]
        Task ItensConcluirPostAsync(Guid id);

        [Post("/api/v1/PlanosDeAcao/{id}/Itens/{itemId}/Concluir")]
        Task ItensConcluirPostAsync(Guid id, Guid itemId, PlanosDeAcaoItensConcluirPost planosDeAcaoItensConcluirPost);

        [Post("/api/v1/PlanosDeAcao/{id}/Itens/{itemId}/Cancelar")]
        Task ItensCancelarPostAsync(Guid id, Guid itemId);

        [Put("/api/v1/PlanosDeAcao/{id}/Itens/{itemId}")]
        Task ItensPutAsync(Guid id, Guid itemId, PlanosDeAcaoItensPut planosDeAcaoItensPut);

        [Delete("/api/v1/PlanosDeAcao/{id}/Itens/{itemId}")]
        Task ItensDeleteAsync(Guid id, Guid itemId);

        [Post("/api/v1/PlanosDeAcao/{id}/Itens/{itemId}/Responsaveis")]
        Task ItensResponsaveisPostAsync(Guid id, Guid itemId, PlanosDeAcaoItensResponsaveisPost planosDeAcaoItensResponsaveisPost);

        [Delete("/api/v1/PlanosDeAcao/{id}/Itens/{itemId}/Responsaveis/{responsavelId}")]
        Task ItensResponsaveisDeleteAsync(Guid id, Guid itemId, Guid responsavelId);
    }
}