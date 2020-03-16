using MediatR;
using Furiza.eCipaOnContainers.Organizacoes.Domain.Models.EstabelecimentoAggregate;

namespace Furiza.eCipaOnContainers.Organizacoes.Application.Commands.EstabelecimentoCommands
{
    public class AtualizarEstabelecimentoCommand : IRequest
    {
        public Estabelecimento Estabelecimento { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
    }
}