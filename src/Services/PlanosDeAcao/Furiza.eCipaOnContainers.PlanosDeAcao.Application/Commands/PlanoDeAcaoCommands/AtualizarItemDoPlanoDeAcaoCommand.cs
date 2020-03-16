using Furiza.eCipaOnContainers.PlanosDeAcao.Domain.Models.PlanoDeAcaoAggregate;
using MediatR;
using System;

namespace Furiza.eCipaOnContainers.PlanosDeAcao.Application.Commands.PlanoDeAcaoCommands
{
    public class AtualizarItemDoPlanoDeAcaoCommand : IRequest
    {
        public PlanoDeAcao PlanoDeAcao { get; set; }
        public Guid ItemId { get; set; }
        public string Descricao { get; set; }
        public string Acao { get; set; }
        public DateTime Prazo { get; set; }
    }
}