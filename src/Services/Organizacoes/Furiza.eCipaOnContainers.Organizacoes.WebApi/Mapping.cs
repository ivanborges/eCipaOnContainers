using AutoMapper;
using Furiza.eCipaOnContainers.Organizacoes.Application.Commands.EstabelecimentoCommands;
using Furiza.eCipaOnContainers.Organizacoes.WebApi.Dtos.v1.Estabelecimentos;

namespace Furiza.eCipaOnContainers.Organizacoes.WebApi
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<EstabelecimentosPost, CriarEstabelecimentoCommand>();
            CreateMap<EstabelecimentosPut, AtualizarEstabelecimentoCommand>();
        }
    }
}