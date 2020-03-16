using System;
using System.Collections.Generic;

namespace Furiza.eCipaOnContainers.RazorPages.RestClients.Cipas.Cipas
{
    public class CipasEstabelecimentosGetResult
    {
        public IEnumerable<CipasEstabelecimentosGetResultInnerEstabelecimento> Estabelecimentos { get; set; }

        public class CipasEstabelecimentosGetResultInnerEstabelecimento
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