using Furiza.eCipaOnContainers.Cipas.Domain.Models.ReuniaoAggregate;
using MediatR;
using System;

namespace Furiza.eCipaOnContainers.Cipas.Application.Commands.ReuniaoCommands
{
    public class GerarAtaDeReuniaoCommand : IRequest<CriarCommandResult>
    {
        public Reuniao Reuniao { get; set; }
        public string Local { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Termino { get; set; }
    }
}