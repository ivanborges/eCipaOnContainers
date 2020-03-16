using MediatR;
using Furiza.eCipaOnContainers.Cipas.Domain.Models.CipaAggregate;
using System;

namespace Furiza.eCipaOnContainers.Cipas.Application.Commands.CipaCommands
{
    public class AdicionarEstabelecimentoACipaCommand : IRequest
    {
        public Cipa Cipa { get; set; }
        public Guid EstabelecimentoId { get; set; }
        public TipoEstabelecimento Tipo { get; set; }
    }
}