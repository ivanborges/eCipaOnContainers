using MediatR;
using System;

namespace Furiza.eCipaOnContainers.Cipas.WebApi.Queries.Reuniao
{
    public class ObterAlteracoesDoAssuntoQuery : IRequest<ObterAlteracoesDoAssuntoQueryResult>
    {
        public Guid ReuniaoId { get; set; }
        public Guid AtaId { get; set; }
        public Guid AssuntoId { get; set; }
    }
}
