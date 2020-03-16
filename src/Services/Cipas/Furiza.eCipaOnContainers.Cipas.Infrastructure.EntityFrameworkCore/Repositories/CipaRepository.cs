using Furiza.Base.Core.SeedWork;
using Microsoft.EntityFrameworkCore;
using Furiza.eCipaOnContainers.Cipas.Domain.Models.CipaAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.Cipas.Infrastructure.EntityFrameworkCore.Repositories
{
    internal class CipaRepository : ICipaReadOnlyRepository, ICipaWriteOnlyRepository
    {
        private readonly CipasContext cipasContext;

        public IUnitOfWork UnitOfWork => cipasContext;

        public CipaRepository(CipasContext cipasContext)
        {
            this.cipasContext = cipasContext ?? throw new ArgumentNullException(nameof(cipasContext));
        }

        public Cipa GetById(Guid id)
        {
            var cipa = cipasContext.Find<Cipa>(id);
            if (cipa != null)
            {
                cipasContext.Entry(cipa).Collection(i => i.Membros).Load();
                cipasContext.Entry(cipa).Collection(i => i.Estabelecimentos).Load();
                cipasContext.Entry(cipa).Reference(i => i.Mandato).Load();
            }

            return cipa;
        }

        public async Task<Cipa> GetByIdAsync(Guid id)
        {
            var cipa = await cipasContext.FindAsync<Cipa>(id);
            if (cipa != null)
            {
                await cipasContext.Entry(cipa).Collection(i => i.Membros).LoadAsync();
                await cipasContext.Entry(cipa).Collection(i => i.Estabelecimentos).LoadAsync();
                await cipasContext.Entry(cipa).Reference(i => i.Mandato).LoadAsync();
            }

            return cipa;
        }

        public async Task<Cipa> GetByCodigoAsync(string codigo)
        {
            var cipa = await cipasContext.Set<Cipa>().FirstOrDefaultAsync(e => e.Codigo == codigo);
            if (cipa != null)
            {
                await cipasContext.Entry(cipa).Collection(i => i.Membros).LoadAsync();
                await cipasContext.Entry(cipa).Collection(i => i.Estabelecimentos).LoadAsync();
                await cipasContext.Entry(cipa).Reference(i => i.Mandato).LoadAsync();
            }

            return cipa;
        }

        public async Task<int> GetNumeroDaUltimaCipaAsync(int codigoEmpresa, int anoInicioMandato, int anoTerminoMandato)
        {
            var cipa = await cipasContext.Set<Cipa>()
                .AsNoTracking()
                .Where(p => p.CodigoEmpresa == codigoEmpresa && p.Mandato.Inicio.Value.Year == anoInicioMandato && p.Mandato.Termino.Value.Year == anoTerminoMandato)
                .OrderByDescending(p => p.Numero)
                .FirstOrDefaultAsync();

            return cipa?.Numero ?? 0;
        }

        public void BatchInsert(IEnumerable<Cipa> aggregates)
        {
            cipasContext.Set<Cipa>().AddRange(aggregates);
        }

        public void BatchUpdate(IEnumerable<Cipa> aggregates)
        {
            cipasContext.Set<Cipa>().UpdateRange(aggregates);
        }

        public void Insert(Cipa aggregate)
        {
            cipasContext.Set<Cipa>().Add(aggregate);
        }

        public void Update(Cipa aggregate)
        {
            cipasContext.Set<Cipa>().Update(aggregate);
        }
    }
}