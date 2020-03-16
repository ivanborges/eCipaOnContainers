using System.Collections.Generic;

namespace Furiza.eCipaOnContainers.RazorPages.RestClients.Organizacoes.Fornecedores
{
    public class FornecedoresGetManyResult
    {
        // TODO: estrutura temporária para fins de montagem da UI até a definição de como ficará organizado o serviços de empresas, fornecedores, órgãos, contratos (?), etc.

        public IEnumerable<FornecedoresGetManyResultInnerFornecedor> Fornecedores { get; set; }

        public class FornecedoresGetManyResultInnerFornecedor
        {
            public int? Codigo { get; set; }
            public string Nome { get; set; }
        }
    }
}