using MediatR;
using Furiza.eCipaOnContainers.PlanosDeAcao.Domain.Models.PlanoDeAcaoAggregate;
using System;

namespace Furiza.eCipaOnContainers.PlanosDeAcao.Application.Commands.PlanoDeAcaoCommands
{
    public class RemoverItemDoPlanoDeAcaoCommand : IRequest
    {
        public PlanoDeAcao PlanoDeAcao { get; set; }
        public Guid ItemId { get; set; }
    }
}