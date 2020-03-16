using Furiza.eCipaOnContainers.PlanosDeAcao.Domain.Models.PlanoDeAcaoAggregate;
using MediatR;
using System;

namespace Furiza.eCipaOnContainers.PlanosDeAcao.Application.Commands.PlanoDeAcaoCommands
{
    public class CancelarItemDoPlanoDeAcaoCommand : IRequest
    {
        public PlanoDeAcao PlanoDeAcao { get; set; }
        public Guid ItemId { get; set; }
    }
}