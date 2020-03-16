using System;
using System.Collections.Generic;

namespace Furiza.eCipaOnContainers.RazorPages.RestClients.Cipas.Reunioes
{
    public class ReunioesGetAtasAssuntosAlteracoesResult
    {
        public IEnumerable<ReunioesGetAtasAssuntosAlteracoesResultInnerAlteracao> Alteracoes { get; set; }

        public class ReunioesGetAtasAssuntosAlteracoesResultInnerAlteracao
        {
            public Guid? Id { get; set; }
            public DateTime? CreationDate { get; set; }
            public string CreationUser { get; set; }
            public string Descricao { get; set; }
            public int? Versao { get; set; }
        }
    }
}