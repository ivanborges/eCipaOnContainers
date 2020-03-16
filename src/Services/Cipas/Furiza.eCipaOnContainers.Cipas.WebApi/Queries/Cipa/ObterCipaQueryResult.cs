using Furiza.eCipaOnContainers.Cipas.Domain.Models;
using Furiza.eCipaOnContainers.Cipas.Domain.Models.CipaAggregate;
using System;
using System.Collections.Generic;

namespace Furiza.eCipaOnContainers.Cipas.WebApi.Queries.Cipa
{
    public class ObterCipaQueryResult
    {
        public Guid? Id { get; set; }
        public DateTime? CreationDate { get; set; }
        public string CreationUser { get; set; }
        public string Codigo { get; set; }
        public int? CodigoEmpresa { get; set; }
        public DateTime? Mandato_Inicio { get; set; }
        public DateTime? Mandato_Termino { get; set; }
        public StatusAtividade? Status { get; set; }
        public IEnumerable<ObterCipaQueryResultInnerMembro> Membros { get; set; }

        public class ObterCipaQueryResultInnerMembro
        {
            public Guid? MembroId { get; set; }
            public string UserName { get; set; }
            public string NomeCompleto { get; set; }
            public FuncaoMembro? Funcao { get; set; }
        }
    }
}