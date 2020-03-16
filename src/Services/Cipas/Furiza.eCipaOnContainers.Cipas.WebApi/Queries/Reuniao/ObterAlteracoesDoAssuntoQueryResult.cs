using System;
using System.Collections.Generic;

namespace Furiza.eCipaOnContainers.Cipas.WebApi.Queries.Reuniao
{
    public class ObterAlteracoesDoAssuntoQueryResult
    {
        public IEnumerable<ObterAlteracoesDoAssuntoQueryResultInnerAlteracao> Alteracoes { get; set; }

        public class ObterAlteracoesDoAssuntoQueryResultInnerAlteracao
        {
            public Guid? Id { get; set; }
            public DateTime? CreationDate { get; set; }
            public string CreationUser { get; set; }
            public string Descricao { get; set; }
            public int? Versao { get; set; }
        }
    }
}