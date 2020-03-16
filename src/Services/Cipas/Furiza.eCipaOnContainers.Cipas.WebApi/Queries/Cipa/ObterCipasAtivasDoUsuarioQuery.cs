using MediatR;

namespace Furiza.eCipaOnContainers.Cipas.WebApi.Queries.Cipa
{
    public class ObterCipasAtivasDoUsuarioQuery : IRequest<ObterCipasAtivasDoUsuarioQueryResult>
    {
        public string UserName { get; set; }
    }
}