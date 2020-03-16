using AutoMapper;
using Furiza.eCipaOnContainers.Cipas.Application.Commands.CipaCommands;
using Furiza.eCipaOnContainers.Cipas.Application.Commands.ReuniaoCommands;
using Furiza.eCipaOnContainers.Cipas.WebApi.Dtos.v1.Cipas;
using Furiza.eCipaOnContainers.Cipas.WebApi.Dtos.v1.Reunioes;

namespace Furiza.eCipaOnContainers.Cipas.WebApi
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<CipasPost, CriarCipaCommand>();
            CreateMap<CipasPut, AtualizarCipaCommand>();
            CreateMap<MembrosCipasPost, AdicionarMembroACipaCommand>();
            CreateMap<EstabelecimentosCipasPost, AdicionarEstabelecimentoACipaCommand>();

            CreateMap<ReunioesPost, CriarReuniaoCommand>();
            CreateMap<ReunioesPut, AtualizarReuniaoCommand>();
            CreateMap<AtasReunioesPost, GerarAtaDeReuniaoCommand>();
            CreateMap<AtasReunioesPut, AtualizarAtaDeReuniaoCommand>();
            CreateMap<ParticipantesAtasReunioesPost, AdicionarParticipanteAAtaDeReuniaoCommand>();
            CreateMap<ParticipantesConvidadosAtasReunioesPost, AdicionarParticipanteConvidadoAAtaDeReuniaoCommand>();
            CreateMap<ConsentsParticipantesAtasReunioesPost, DarConsentDoParticipanteDaAtaDeReuniaoCommand>();
            CreateMap<AusentesAtasReunioesPost, AdicionarAusenteAAtaDeReuniaoCommand>();
            CreateMap<AusentesAtasReunioesPut, AtualizarAusenteDaAtaDeReuniaoCommand>();
            CreateMap<ConsentsAusentesAtasReunioesPost, DarConsentDoAusenteDaAtaDeReuniaoCommand>();
            CreateMap<AssuntosAtasReunioesPost, AdicionarAssuntoAAtaDeReuniaoCommand>();
            CreateMap<AssuntosAtasReunioesPut, AtualizarAssuntoDaAtaDeReuniaoCommand>();
        }
    }
}