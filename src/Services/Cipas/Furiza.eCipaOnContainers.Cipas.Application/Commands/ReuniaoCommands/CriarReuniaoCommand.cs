using Furiza.eCipaOnContainers.Cipas.Domain.Models;
using MediatR;
using System;

namespace Furiza.eCipaOnContainers.Cipas.Application.Commands.ReuniaoCommands
{
    public class CriarReuniaoCommand : IRequest<CriarCommandResult>
    {
        public Guid CipaId { get; set; }
        public Mes MesDeReferencia { get; set; }
        public DateTime DataPrevista { get; set; }
        public string Local { get; set; }
        public bool Extraordinaria { get; set; }
    }
}