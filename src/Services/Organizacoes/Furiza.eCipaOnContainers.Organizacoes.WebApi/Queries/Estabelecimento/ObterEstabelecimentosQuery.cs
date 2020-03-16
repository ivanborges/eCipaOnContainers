using MediatR;
using Furiza.eCipaOnContainers.Organizacoes.Domain.Models;

namespace Furiza.eCipaOnContainers.Organizacoes.WebApi.Queries.Estabelecimento
{
    public class ObterEstabelecimentosQuery : IRequest<ObterEstabelecimentosQueryResult>
    {
        public StatusAtividade Status { get; set; } = StatusAtividade.Ativo;
        public int Quantidade { get; set; } = 100;
        public string Codigo { get; set; }
        public string Nome { get; set; }
    }
}