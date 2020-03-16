using Furiza.eCipaOnContainers.Cipas.Domain.Models.CipaAggregate;
using MediatR;
using System;

namespace Furiza.eCipaOnContainers.Cipas.Application.Commands.CipaCommands
{
    public class RemoverMembroDaCipaCommand : IRequest
    {
        public Cipa Cipa { get; set; }
        public Guid MembroId { get; set; }
    }
}