using System;
using System.Collections.Generic;

namespace Furiza.eCipaOnContainers.RazorPages.RestClients.Cipas.Cipas
{
    public class CipasGetManyResult
    {
        public IEnumerable<CipasGetManyResultInnerCipa> Cipas { get; set; }

        public class CipasGetManyResultInnerCipa
        {
            public Guid? Id { get; set; }
            public DateTime? CreationDate { get; set; }
            public string CreationUser { get; set; }
            public string Codigo { get; set; }
            public int? CodigoEmpresa { get; set; }
            public DateTime? Mandato_Inicio { get; set; }
            public DateTime? Mandato_Termino { get; set; }
            public StatusAtividade? Status { get; set; }
        }
    }
}