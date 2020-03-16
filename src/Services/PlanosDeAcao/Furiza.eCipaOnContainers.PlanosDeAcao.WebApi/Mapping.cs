using AutoMapper;
using Furiza.eCipaOnContainers.PlanosDeAcao.Application.Commands.PlanoDeAcaoCommands;
using Furiza.eCipaOnContainers.PlanosDeAcao.WebApi.Dtos.v1.PlanosDeAcao;

namespace Furiza.eCipaOnContainers.PlanosDeAcao.WebApi
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ItensPlanosDeAcaoPost, AdicionarItemAoPlanoDeAcaoCommand>();
            CreateMap<ConcluirItensPlanosDeAcaoPost, ConcluirItemDoPlanoDeAcaoCommand>();
            CreateMap<ItensPlanosDeAcaoPut, AtualizarItemDoPlanoDeAcaoCommand>();
            CreateMap<ResponsaveisItensPlanosDeAcaoPost, AdicionarResponsavelAoItemDoPlanoDeAcaoCommand>();
        }
    }
}