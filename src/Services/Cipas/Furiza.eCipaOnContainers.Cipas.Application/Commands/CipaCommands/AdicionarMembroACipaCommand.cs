using Furiza.eCipaOnContainers.Cipas.Domain.Models.CipaAggregate;
using MediatR;

namespace Furiza.eCipaOnContainers.Cipas.Application.Commands.CipaCommands
{
    public class AdicionarMembroACipaCommand : IRequest
    {
        public Cipa Cipa { get; set; }
        public string UserName { get; set; }
        public string NomeCompleto { get; set; }
        public FuncaoMembro Funcao { get; set; }
    }
}