namespace Furiza.eCipaOnContainers.RazorPages.RestClients.Cipas.Cipas
{
    public class CipasGetMany
    {
        public StatusAtividade? Status { get; set; }
        public int? Quantidade { get; set; }
        public string Codigo { get; set; }
        public int? CodigoEmpresa { get; set; }
    }
}