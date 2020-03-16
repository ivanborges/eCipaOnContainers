using Refit;
using System;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.RazorPages.RestClients.Cipas.Reunioes
{
    public interface IReunioesClient
    {
        [Get("/api/v1/Reunioes/{id}")]
        Task<ReunioesGetResult> GetAsync(Guid id);

        [Get("/api/v1/Reunioes/AgendadasDoUsuarioLogado")]
        Task<ReunioesGetAgendadasDoUsuarioLogadoResult> GetAgendadasDoUsuarioLogadoAsync();

        [Post("/api/v1/Reunioes")]
        Task<PostResult> PostAsync(ReunioesPost reunioesPost);

        [Put("/api/v1/Reunioes/{id}")]
        Task PutAsync(Guid id, ReunioesPut reunioesPut);

        [Post("/api/v1/Reunioes/{id}/PlanosDeAcao")]
        Task PlanosDeAcaoPostAsync(Guid id, ReunioesPlanosDeAcaoPost reunioesPlanosDeAcaoPost);

        [Delete("/api/v1/Reunioes/{id}/PlanosDeAcao/{planoDeAcaoId}")]
        Task PlanosDeAcaoDeleteAsync(Guid id, Guid planoDeAcaoId);

        [Post("/api/v1/Reunioes/{id}/Cancelar")]
        Task CancelarPostAsync(Guid id);

        [Post("/api/v1/Reunioes/{id}/Atas")]
        Task<PostResult> AtasPostAsync(Guid id, ReunioesAtasPost reunioesAtasPost);

        [Put("/api/v1/Reunioes/{id}/Atas/{ataId}")]
        Task AtasPutAsync(Guid id, Guid ataId, ReunioesAtasPut reunioesAtasPut);

        [Post("/api/v1/Reunioes/{id}/Atas/{ataId}/Finalizar")]
        Task AtasFinalizarPostAsync(Guid id, Guid ataId);

        [Post("/api/v1/Reunioes/{id}/Atas/{ataId}/Reabrir")]
        Task AtasReabrirPostAsync(Guid id, Guid ataId);

        [Post("/api/v1/Reunioes/{id}/Atas/{ataId}/Aprovar")]
        Task AtasAprovarPostAsync(Guid id, Guid ataId);

        [Post("/api/v1/Reunioes/{id}/Atas/{ataId}/Participantes")]
        Task AtasParticipantesPostAsync(Guid id, Guid ataId, ReunioesAtasParticipantesPost reunioesAtasParticipantesPost);

        [Post("/api/v1/Reunioes/{id}/Atas/{ataId}/ParticipantesConvidados")]
        Task AtasParticipantesConvidadosPostAsync(Guid id, Guid ataId, ReunioesAtasParticipantesConvidadosPost reunioesAtasParticipantesConvidadosPost);

        [Delete("/api/v1/Reunioes/{id}/Atas/{ataId}/Participantes/{participanteId}")]
        Task AtasParticipantesDeleteAsync(Guid id, Guid ataId, Guid participanteId);

        [Post("/api/v1/Reunioes/{id}/Atas/{ataId}/Participantes/{participanteId}/Consents")]
        Task AtasParticipantesConsentsPostAsync(Guid id, Guid ataId, Guid participanteId, ReunioesAtasParticipantesConsentsPost reunioesAtasParticipantesConsentsPost);

        [Get("/api/v1/Reunioes/{id}/Atas/{ataId}/Participantes/{participanteId}/Consents")]
        Task<ReunioesGetAtasParticipantesConsentsResult> GetAtasParticipantesConsentsAsync(Guid id, Guid ataId, Guid participanteId);

        [Post("/api/v1/Reunioes/{id}/Atas/{ataId}/Ausentes")]
        Task AtasAusentesPostAsync(Guid id, Guid ataId, ReunioesAtasAusentesPost reunioesAtasAusentesPost);

        [Put("/api/v1/Reunioes/{id}/Atas/{ataId}/Ausentes/{ausenteId}")]
        Task AtasAusentesPutAsync(Guid id, Guid ataId, Guid ausenteId, ReunioesAtasAusentesPut reunioesAtasAusentesPut);

        [Delete("/api/v1/Reunioes/{id}/Atas/{ataId}/Ausentes/{ausenteId}")]
        Task AtasAusentesDeleteAsync(Guid id, Guid ataId, Guid ausenteId);

        [Post("/api/v1/Reunioes/{id}/Atas/{ataId}/Ausentes/{ausenteId}/Consents")]
        Task AtasAusentesConsentsPostAsync(Guid id, Guid ataId, Guid ausenteId, ReunioesAtasAusentesConsentsPost reunioesAtasAusentesConsentsPost);

        [Get("/api/v1/Reunioes/{id}/Atas/{ataId}/Ausentes/{ausenteId}/Consents")]
        Task<ReunioesGetAtasAusentesConsentsResult> GetAtasAusentesConsentsAsync(Guid id, Guid ataId, Guid ausenteId);

        [Post("/api/v1/Reunioes/{id}/Atas/{ataId}/Assuntos")]
        Task AtasAssuntosPostAsync(Guid id, Guid ataId, ReunioesAtasAssuntosPost reunioesAtasAssuntosPost);

        [Put("/api/v1/Reunioes/{id}/Atas/{ataId}/Assuntos/{assuntoId}")]
        Task AtasAssuntosPutAsync(Guid id, Guid ataId, Guid assuntoId, ReunioesAtasAssuntosPut reunioesAtasAssuntosPut);

        [Delete("/api/v1/Reunioes/{id}/Atas/{ataId}/Assuntos/{assuntoId}")]
        Task AtasAssuntosDeleteAsync(Guid id, Guid ataId, Guid assuntoId);

        [Get("/api/v1/Reunioes/{id}/Atas/{ataId}/Assuntos/{assuntoId}/Alteracoes")]
        Task<ReunioesGetAtasAssuntosAlteracoesResult> GetAtasAssuntosAlteracoesAsync(Guid id, Guid ataId, Guid assuntoId);
    }
}