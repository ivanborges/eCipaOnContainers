using System;
using System.Collections.Generic;

namespace Furiza.eCipaOnContainers.RazorPages.RestClients.PlanosDeAcao.PlanosDeAcao
{
    public class PlanosDeAcaoGetResult
    {
        public Guid? Id { get; set; }
        public DateTime? CreationDate { get; set; }
        public string CreationUser { get; set; }
        public string Codigo { get; set; }
        public string Ano { get; set; }
        public string Numero { get; set; }
        public IEnumerable<PlanosDeAcaoGetResultInnerItem> Itens { get; set; }

        public class PlanosDeAcaoGetResultInnerItem
        {
            public Guid? ItemId { get; set; }
            public string Codigo { get; set; }
            public string Descricao { get; set; }
            public string Acao { get; set; }
            public DateTime? Prazo { get; set; }
            public StatusAgendamento? Status { get; set; }
            public DateTime? DataRealizacao { get; set; }
            public ICollection<PlanosDeAcaoGetResultInnerResponsavel> Responsaveis { get; set; }
        }

        public class PlanosDeAcaoGetResultInnerResponsavel
        {
            public Guid? ResponsavelId { get; set; }
            public string NomeCompleto { get; set; }
            public string Email { get; set; }
        }
    }
}