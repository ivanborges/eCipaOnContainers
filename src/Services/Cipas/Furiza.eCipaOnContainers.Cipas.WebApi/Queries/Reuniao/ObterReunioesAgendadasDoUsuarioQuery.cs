using MediatR;

namespace Furiza.eCipaOnContainers.Cipas.WebApi.Queries.Reuniao
{
    public class ObterReunioesAgendadasDoUsuarioQuery : IRequest<ObterReunioesAgendadasDoUsuarioQueryResult>
    {
        public string UserName { get; set; }
    }
}