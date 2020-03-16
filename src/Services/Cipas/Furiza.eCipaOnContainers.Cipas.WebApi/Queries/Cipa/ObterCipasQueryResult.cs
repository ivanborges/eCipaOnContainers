using Furiza.eCipaOnContainers.Cipas.Domain.Models;
using System;
using System.Collections.Generic;

namespace Furiza.eCipaOnContainers.Cipas.WebApi.Queries.Cipa
{
    public class ObterCipasQueryResult
    {
        public IEnumerable<ObterCipasQueryResultInnerCipa> Cipas { get; set; }

        public class ObterCipasQueryResultInnerCipa
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