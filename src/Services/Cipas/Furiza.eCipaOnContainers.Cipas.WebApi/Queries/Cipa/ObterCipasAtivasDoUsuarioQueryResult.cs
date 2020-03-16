using System;
using System.Collections.Generic;

namespace Furiza.eCipaOnContainers.Cipas.WebApi.Queries.Cipa
{
    public class ObterCipasAtivasDoUsuarioQueryResult
    {
        public IEnumerable<ObterCipasAtivasDoUsuarioQueryResultInnerCipa> Cipas { get; set; }

        public class ObterCipasAtivasDoUsuarioQueryResultInnerCipa
        {
            public Guid? Id { get; set; }
            public string Codigo { get; set; }
            public int? CodigoEmpresa { get; set; }
            public DateTime? Mandato_Inicio { get; set; }
            public DateTime? Mandato_Termino { get; set; }
        }
    }
}