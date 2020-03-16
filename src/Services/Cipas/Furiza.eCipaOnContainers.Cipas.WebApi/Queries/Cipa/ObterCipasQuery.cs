using Furiza.eCipaOnContainers.Cipas.Domain.Models;
using MediatR;

namespace Furiza.eCipaOnContainers.Cipas.WebApi.Queries.Cipa
{
    public class ObterCipasQuery : IRequest<ObterCipasQueryResult>
    {
        public StatusAtividade Status { get; set; } = StatusAtividade.Ativo;
        public int Quantidade { get; set; } = 100;
        public string Codigo { get; set; }
        public int? CodigoEmpresa { get; set; }
    }
}