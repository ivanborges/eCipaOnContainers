using System;
using System.Collections.Generic;

namespace Furiza.eCipaOnContainers.RazorPages.RestClients.Organizacoes.Estabelecimentos
{
    public class EstabelecimentosGetManyResult
    {
        public IEnumerable<EstabelecimentosGetManyResultInnerEstabelecimento> Estabelecimentos { get; set; }

        public class EstabelecimentosGetManyResultInnerEstabelecimento
        {
            public Guid? Id { get; set; }
            public DateTime? CreationDate { get; set; }
            public string CreationUser { get; set; }
            public string Codigo { get; set; }
            public string Nome { get; set; }
            public StatusAtividade Status { get; set; }
        }
    }
}