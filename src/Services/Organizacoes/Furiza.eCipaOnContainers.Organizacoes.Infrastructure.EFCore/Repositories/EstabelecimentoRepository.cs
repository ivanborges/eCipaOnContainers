using Furiza.eCipaOnContainers.Organizacoes.Domain.Models.EstabelecimentoAggregate;
using Furiza.Base.Core.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.Organizacoes.Infrastructure.EFCore.Repositories
{
    internal class EstabelecimentoRepository : IEstabelecimentoReadOnlyRepository, IEstabelecimentoWriteOnlyRepository
    {
        private readonly OrganizacoesContext coreBusinessContext;

        public IUnitOfWork UnitOfWork => coreBusinessContext;

        public EstabelecimentoRepository(OrganizacoesContext coreBusinessContext)
        {
            this.coreBusinessContext = coreBusinessContext ?? throw new ArgumentNullException(nameof(coreBusinessContext));
        }

        public Estabelecimento GetById(Guid id)
        {
            var estabelecimento = coreBusinessContext.Find<Estabelecimento>(id);
            if (estabelecimento != null)
            {
            }

            return estabelecimento;
        }

        public async Task<Estabelecimento> GetByIdAsync(Guid id)
        {
            var estabelecimento = await coreBusinessContext.FindAsync<Estabelecimento>(id);
            if (estabelecimento != null)
            {
            }

            return estabelecimento;
        }

        public async Task<Estabelecimento> GetByCodigoAsync(string codigo)
        {
            var estabelecimento = await coreBusinessContext.Set<Estabelecimento>().FirstOrDefaultAsync(e => e.Codigo == codigo);
            if (estabelecimento != null)
            {
            }

            return estabelecimento;
        }

        public void BatchInsert(IEnumerable<Estabelecimento> aggregates)
        {
            coreBusinessContext.Set<Estabelecimento>().AddRange(aggregates);
        }

        public void BatchUpdate(IEnumerable<Estabelecimento> aggregates)
        {
            coreBusinessContext.Set<Estabelecimento>().UpdateRange(aggregates);
        }

        public void Insert(Estabelecimento aggregate)
        {
            coreBusinessContext.Set<Estabelecimento>().Add(aggregate);
        }

        public void Update(Estabelecimento aggregate)
        {
            coreBusinessContext.Set<Estabelecimento>().Update(aggregate);
        }
    }
}