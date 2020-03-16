using Furiza.Base.Core.SeedWork;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.Cipas.Domain.Models.CipaAggregate
{
    public interface ICipaReadOnlyRepository : IAggregateReadOnlyRepository<Cipa>
    {
        Task<Cipa> GetByCodigoAsync(string codigo);
        Task<int> GetNumeroDaUltimaCipaAsync(int codigoEmpresa, int anoInicioMandato, int anoTerminoMandato);
    }
}