using MediatR;
using System;

namespace Furiza.eCipaOnContainers.Cipas.Application.Commands.CipaCommands
{
    public class CriarCipaCommand : IRequest<CriarCommandResult>
    {
        public int CodigoEmpresa { get; set; }
        public DateTime InicioDoMandato { get; set; }
        public DateTime TerminoDoMandato { get; set; }
    }
}