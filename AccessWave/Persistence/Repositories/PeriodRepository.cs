using AccessWave.Domain.Models;
using AccessWave.Persistence.Context;
using AccessWave.Persistence.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessWave.Persistence.Repositories
{
    public class PeriodRepository : BaseRepository, IPeriodRepository
    {
        public PeriodRepository(DatabaseContext context) :  base(context) { }

        public async Task AddAsync(Period period)
        {
            await _context.Period.AddAsync(period);
        }

        public async Task<Period> FindByIdAsync(int id)
        {
            return await _context.Period.FindAsync(id);
        }

        public async Task<IEnumerable<Period>> ListAsync()
        {
            return await _context.Period.ToListAsync();
        }

        public void Remove(Period period)
        {
            _context.Period.Remove(period);
        }

        public void Update(Period period)
        {
            _context.Period.Update(period);
        }
    }
}
