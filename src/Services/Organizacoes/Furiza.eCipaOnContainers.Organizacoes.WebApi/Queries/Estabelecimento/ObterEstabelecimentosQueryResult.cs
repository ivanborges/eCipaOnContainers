using Furiza.eCipaOnContainers.Organizacoes.Domain.Models;
using System;
using System.Collections.Generic;

namespace Furiza.eCipaOnContainers.Organizacoes.WebApi.Queries.Estabelecimento
{
    public class ObterEstabelecimentosQueryResult
    {
        public IEnumerable<ObterEstabelecimentosQueryResultInnerEstabelecimento> Estabelecimentos { get; set; }

        public class ObterEstabelecimentosQueryResultInnerEstabelecimento
        {
            public Guid? Id { get; set; }
            public DateTime? CreationDate { get; set; }
            public string CreationUser { get; set; }
            public string Codigo { get; set; }
            public string Nome { get; set; }
            public StatusAtividade? Status { get; set; }
        }
    }
}