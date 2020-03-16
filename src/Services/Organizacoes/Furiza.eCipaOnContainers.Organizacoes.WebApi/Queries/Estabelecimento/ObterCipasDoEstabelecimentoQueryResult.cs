using Furiza.eCipaOnContainers.Organizacoes.Domain.Models;
using System;
using System.Collections.Generic;

namespace Furiza.eCipaOnContainers.Organizacoes.WebApi.Queries.Estabelecimento
{
    public class ObterCipasDoEstabelecimentoQueryResult
    {
        public IEnumerable<ObterCipasDoEstabelecimentoQueryResultInnerCipa> Cipas { get; set; }

        public class ObterCipasDoEstabelecimentoQueryResultInnerCipa
        {
            public Guid? Id { get; set; }
            public string Codigo { get; set; }
            public DateTime? CreationDate { get; set; }
            public StatusAtividade? Status { get; set; }
        }        
    }
}