using System;
using System.Collections.Generic;

namespace Furiza.eCipaOnContainers.RazorPages.RestClients.Cipas.Cipas
{
    public class CipasGetAtivasDoUsuarioLogadoResult
    {
        public IEnumerable<CipasGetAtivasDoUsuarioLogadoResultInnerCipa> Cipas { get; set; }

        public class CipasGetAtivasDoUsuarioLogadoResultInnerCipa
        {
            public Guid? Id { get; set; }
            public string Codigo { get; set; }
            public string Nome { get; set; }
            public string Descricao { get; set; }
            public int? CodigoEmpresa { get; set; }
            public DateTime? Mandato_Inicio { get; set; }
            public DateTime? Mandato_Termino { get; set; }
        }
    }
}