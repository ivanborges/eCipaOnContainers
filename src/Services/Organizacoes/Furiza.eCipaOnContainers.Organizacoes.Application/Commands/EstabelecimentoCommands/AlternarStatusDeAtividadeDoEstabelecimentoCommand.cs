using Furiza.eCipaOnContainers.Organizacoes.Domain.Models.EstabelecimentoAggregate;
using MediatR;

namespace Furiza.eCipaOnContainers.Organizacoes.Application.Commands.EstabelecimentoCommands
{
    public class AlternarStatusDeAtividadeDoEstabelecimentoCommand : IRequest
    {
        public Estabelecimento Estabelecimento { get; set; }
    }
}