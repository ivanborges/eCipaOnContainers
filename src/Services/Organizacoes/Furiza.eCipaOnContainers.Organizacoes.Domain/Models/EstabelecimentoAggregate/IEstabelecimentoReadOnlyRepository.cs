using Furiza.Base.Core.SeedWork;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.Organizacoes.Domain.Models.EstabelecimentoAggregate
{
    public interface IEstabelecimentoReadOnlyRepository : IAggregateReadOnlyRepository<Estabelecimento>
    {
        Task<Estabelecimento> GetByCodigoAsync(string codigo);
    }
}