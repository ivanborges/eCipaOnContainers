using Furiza.eCipaOnContainers.Cipas.Domain.Models.ReuniaoAggregate;
using Furiza.Base.Core.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.Cipas.Infrastructure.EntityFrameworkCore.Repositories
{
    internal class ReuniaoRepository : IReuniaoReadOnlyRepository, IReuniaoWriteOnlyRepository
    {
        private readonly CipasContext cipasContext;

        public IUnitOfWork UnitOfWork => cipasContext;

        public ReuniaoRepository(CipasContext cipasContext)
        {
            this.cipasContext = cipasContext ?? throw new ArgumentNullException(nameof(cipasContext));
        }

        public Reuniao GetById(Guid id)
        {
            var reuniao = cipasContext.Set<Reuniao>()
                .Include(r => r.Ata)
                    .ThenInclude(a => a.Finalizacao)
                .Include(r => r.Ata)
                    .ThenInclude(a => a.Aprovacao)
                .Include(r => r.Ata)
                    .ThenInclude(a => a.Participantes)
                        .ThenInclude(p => p.Consents)
                .Include(r => r.Ata)
                    .ThenInclude(a => a.Ausentes)
                        .ThenInclude(au => au.Consents)
                .Include(r => r.Ata)
                    .ThenInclude(a => a.Assuntos)
                        .ThenInclude(ass => ass.Alteracoes)
                .SingleOrDefault(p => p.Id == id);

            return reuniao;
        }

        public async Task<Reuniao> GetByIdAsync(Guid id)
        {
            var reuniao = await cipasContext.Set<Reuniao>()
                .Include(r => r.Ata)
                    .ThenInclude(a => a.Finalizacao)
                .Include(r => r.Ata)
                    .ThenInclude(a => a.Aprovacao)
                .Include(r => r.Ata)
                    .ThenInclude(a => a.Participantes)
                        .ThenInclude(p => p.Consents)
                .Include(r => r.Ata)
                    .ThenInclude(a => a.Ausentes)
                        .ThenInclude(au => au.Consents)
                .Include(r => r.Ata)
                    .ThenInclude(a => a.Assuntos)
                        .ThenInclude(ass => ass.Alteracoes)
                .SingleOrDefaultAsync(p => p.Id == id);

            return reuniao;
        }

        public async Task<int> GetNumeroDaUltimaAtaAsync(string codigoCipa)
        {
            var ata = await cipasContext.Set<Ata>()
                .AsNoTracking()
                .Where(p => p.CodigoCipa == codigoCipa)
                .OrderByDescending(p => p.Numero)
                .FirstOrDefaultAsync();

            return ata?.Numero ?? 0;
        }

        public void BatchInsert(IEnumerable<Reuniao> aggregates)
        {
            cipasContext.Set<Reuniao>().AddRange(aggregates);
        }

        public void BatchUpdate(IEnumerable<Reuniao> aggregates)
        {
            cipasContext.Set<Reuniao>().UpdateRange(aggregates);
        }

        public void Insert(Reuniao aggregate)
        {
            cipasContext.Set<Reuniao>().Add(aggregate);
        }

        public void Update(Reuniao aggregate)
        {
            cipasContext.Set<Reuniao>().Update(aggregate);
        }
    }
}