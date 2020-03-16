using Furiza.eCipaOnContainers.Cipas.Domain.Exceptions;
using Furiza.Base.Core.SeedWork;
using System;

namespace Furiza.eCipaOnContainers.Cipas.Domain.Models.CipaAggregate
{
    public interface ICipaWriteOnlyRepository : IAggregateWriteOnlyRepository<Cipa>
    {
    }
}