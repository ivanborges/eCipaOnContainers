using MediatR;

namespace Furiza.eCipaOnContainers.PlanosDeAcao.WebApi.Queries.PlanoDeAcao
{
    public class ObterItensDePlanoDeAcaoPendentesAtribuidosAoUsuarioQuery : IRequest<ObterItensDePlanoDeAcaoPendentesAtribuidosAoUsuarioQueryResult>
    {
        public string Email { get; set; }
    }
}