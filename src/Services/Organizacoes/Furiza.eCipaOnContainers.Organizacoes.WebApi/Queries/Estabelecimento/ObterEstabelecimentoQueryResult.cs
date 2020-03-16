using Furiza.eCipaOnContainers.Organizacoes.Domain.Models;
using System;

namespace Furiza.eCipaOnContainers.Organizacoes.WebApi.Queries.Estabelecimento
{
    public class ObterEstabelecimentoQueryResult
    {
        public Guid? Id { get; set; }
        public DateTime? CreationDate { get; set; }
        public string CreationUser { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public StatusAtividade? Status { get; set; }
    }
}