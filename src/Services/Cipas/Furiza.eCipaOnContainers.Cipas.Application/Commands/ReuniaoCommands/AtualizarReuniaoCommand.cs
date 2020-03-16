using Furiza.eCipaOnContainers.Cipas.Domain.Models;
using Furiza.eCipaOnContainers.Cipas.Domain.Models.ReuniaoAggregate;
using MediatR;
using System;

namespace Furiza.eCipaOnContainers.Cipas.Application.Commands.ReuniaoCommands
{
    public class AtualizarReuniaoCommand : IRequest
    {
        public Reuniao Reuniao { get; set; }
        public Mes MesDeReferencia { get; set; }
        public DateTime DataPrevista { get; set; }
        public string Local { get; set; }
    }
}