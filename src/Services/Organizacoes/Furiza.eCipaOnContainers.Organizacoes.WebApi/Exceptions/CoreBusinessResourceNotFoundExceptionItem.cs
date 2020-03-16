using Furiza.AspNetCore.ExceptionHandling;

namespace Furiza.eCipaOnContainers.Organizacoes.WebApi.Exceptions
{
    public class CoreBusinessResourceNotFoundExceptionItem : ResourceNotFoundExceptionItem
    {
        public static CoreBusinessResourceNotFoundExceptionItem Estabelecimento => new CoreBusinessResourceNotFoundExceptionItem("Estabelecimento", "Estabelecimento não encontrado.");

        private CoreBusinessResourceNotFoundExceptionItem(string key, string message) : base(key, message)
        {
        }
    }
}