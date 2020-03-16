using System;
using System.Collections.Generic;

namespace Furiza.eCipaOnContainers.RazorPages.RestClients.Organizacoes.Estabelecimentos
{
    public class EstabelecimentosCipasGetResult
    {
        public IEnumerable<EstabelecimentosCipasGetResultInnerCipa> Cipas { get; set; }

        public class EstabelecimentosCipasGetResultInnerCipa
        {
            public Guid? Id { get; set; }
            public string Codigo { get; set; }
            public DateTime? CreationDate { get; set; }
            public StatusAtividade? Status { get; set; }
        }
    }
}