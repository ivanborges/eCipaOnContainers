using System;
using System.Collections.Generic;

namespace Furiza.eCipaOnContainers.RazorPages.RestClients.PlanosDeAcao.PlanosDeAcao
{
    public class PlanosDeAcaoGetItensPendentesAtribuidosAoUsuarioLogadoResult
    {
        public IEnumerable<PlanosDeAcaoGetItensPendentesAtribuidosAoUsuarioLogadoResultInnerItem> Itens { get; set; }

        public class PlanosDeAcaoGetItensPendentesAtribuidosAoUsuarioLogadoResultInnerItem
        {
            public Guid? Id { get; set; }
            public string Codigo { get; set; }
            public string Descricao { get; set; }
            public string Acao { get; set; }
            public DateTime? Prazo { get; set; }
            public StatusAgendamento? Status { get; set; }
            public Guid? PlanoDeAcaoId { get; set; }
        }
    }
}