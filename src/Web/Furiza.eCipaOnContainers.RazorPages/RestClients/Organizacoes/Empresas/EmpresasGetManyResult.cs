using System.Collections.Generic;

namespace Furiza.eCipaOnContainers.RazorPages.RestClients.Organizacoes.Empresas
{
    public class EmpresasGetManyResult
    {
        // TODO: estrutura temporária para fins de montagem da UI até a definição de como ficará organizado o serviços de empresas, fornecedores, órgãos, contratos (?), etc.

        public IEnumerable<EmpresasGetManyResultInnerEmpresa> Empresas { get; set; }

        public class EmpresasGetManyResultInnerEmpresa
        {
            public int? Codigo { get; set; }
            public string Nome { get; set; }
        }
    }
}