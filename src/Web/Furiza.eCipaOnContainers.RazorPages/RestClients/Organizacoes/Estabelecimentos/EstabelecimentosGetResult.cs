using System;

namespace Furiza.eCipaOnContainers.RazorPages.RestClients.Organizacoes.Estabelecimentos
{
    public class EstabelecimentosGetResult
    {
        public Guid? Id { get; set; }
        public DateTime? CreationDate { get; set; }
        public string CreationUser { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public StatusAtividade? Status { get; set; }
    }
}