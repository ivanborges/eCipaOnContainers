using MediatR;

namespace Furiza.eCipaOnContainers.Organizacoes.Application.Commands.EstabelecimentoCommands
{
    public class CriarEstabelecimentoCommand : IRequest<CriarCommandResult>
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
    }
}