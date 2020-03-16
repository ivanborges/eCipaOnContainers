using System;

namespace Furiza.eCipaOnContainers.RazorPages.RestClients.Organizacoes.Estabelecimentos
{
    public class EstabelecimentosGetMany
    {
        public StatusAtividade? Status { get; set; }
        public Guid? CipaId { get; set; }
        public int? Quantidade { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
    }
}