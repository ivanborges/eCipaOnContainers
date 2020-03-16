using Furiza.eCipaOnContainers.Cipas.Domain.Models.CipaAggregate;
using MediatR;
using System;

namespace Furiza.eCipaOnContainers.Cipas.Application.Commands.CipaCommands
{
    public class AtualizarCipaCommand : IRequest
    {
        public Cipa Cipa { get; set; }
        public DateTime InicioDoMandato { get; set; }
        public DateTime TerminoDoMandato { get; set; }
    }
}