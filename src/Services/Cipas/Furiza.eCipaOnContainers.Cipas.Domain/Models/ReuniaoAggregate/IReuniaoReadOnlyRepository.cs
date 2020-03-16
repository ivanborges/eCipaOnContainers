using Furiza.Base.Core.SeedWork;
using System;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.Cipas.Domain.Models.ReuniaoAggregate
{
    public interface IReuniaoReadOnlyRepository : IAggregateReadOnlyRepository<Reuniao>
    {
        Task<int> GetNumeroDaUltimaAtaAsync(string codigoCipa);
    }
}