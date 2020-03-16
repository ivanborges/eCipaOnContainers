using Furiza.eCipaOnContainers.Cipas.Domain.Models;
using Furiza.eCipaOnContainers.Cipas.Domain.Models.CipaAggregate;
using System;
using System.Collections.Generic;

namespace Furiza.eCipaOnContainers.Cipas.WebApi.Queries.Cipa
{
    public class ObterEstabelecimentosDaCipaQueryResult
    {
        public IEnumerable<ObterEstabelecimentosDaCipaQueryResultInnerEstabelecimento> Estabelecimentos { get; set; }

        public class ObterEstabelecimentosDaCipaQueryResultInnerEstabelecimento
        {
            public Guid? Id { get; set; }
            public Guid? RelId { get; set; }
            public string Codigo { get; set; }
            public string Nome { get; set; }
            public TipoEstabelecimento? Tipo { get; set; }
            public StatusAtividade? Status { get; set; }
        }
    }
}