
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using DotNETTask.Domains.Models;
using DotNETTask.Persistence.Context;
using DotNETTask.Persistence.Interfaces.Repositories;

namespace DotNETTask.Persistence.Repositories
{
    public class ProviderRepository : IProviderRepository
    {
        private readonly AppDbContext _context;

        public ProviderRepository(AppDbContext context) => _context = context;

        public async Task<ProgramEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var keyValues = new object[] { id };
            var data =  await this._context.Set<ProgramEntity>().FindAsync(keyValues, cancellationToken);
            return data;
        }
        public async Task<ProgramEntity> AddAsync(ProgramEntity entity, CancellationToken cancellationToken = default)
        {
            await this._context.AddAsync(entity);
            await this._context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task DeleteAsync(ProgramEntity entity, CancellationToken cancellationToken = default)
        {
            this._context.Remove(entity);
            await this._context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(ProgramEntity entity, CancellationToken cancellationToken = default)
        {
            this._context.Update(entity);
            await this._context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<ProgramEntity>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            Stopwatch stopwatch = new();
            stopwatch.Start();

            var data = await this._context.ProgramEntities.ToListAsync();

            stopwatch.Stop();

            TimeSpan ts = stopwatch.Elapsed;

            return data;
        }
    }
}
