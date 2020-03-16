using Furiza.AspNetCore.ExceptionHandling;

namespace Furiza.eCipaOnContainers.Cipas.WebApi.Exceptions
{
    public class CipasResourceNotFoundExceptionItem : ResourceNotFoundExceptionItem
    {
        public static CipasResourceNotFoundExceptionItem Cipa => new CipasResourceNotFoundExceptionItem("Cipa", "Cipa não encontrada.");
        public static CipasResourceNotFoundExceptionItem Reuniao => new CipasResourceNotFoundExceptionItem("Reuniao", "Reunião não encontrada.");

        private CipasResourceNotFoundExceptionItem(string key, string message) : base(key, message)
        {
        }
    }
}