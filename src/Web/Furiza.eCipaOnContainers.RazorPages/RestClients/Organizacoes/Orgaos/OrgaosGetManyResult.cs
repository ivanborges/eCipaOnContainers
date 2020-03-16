using System.Collections.Generic;

namespace Furiza.eCipaOnContainers.RazorPages.RestClients.Organizacoes.Orgaos
{
    public class OrgaosGetManyResult
    {
        // TODO: estrutura temporária para fins de montagem da UI até a definição de como ficará organizado o serviços de empresas, fornecedores, órgãos, contratos (?), etc.

        public IEnumerable<OrgaosGetManyResultInnerOrgao> Orgaos { get; set; }

        public class OrgaosGetManyResultInnerOrgao
        {
            public int? Codigo { get; set; }
            public string Nome { get; set; }
        }
    }
}