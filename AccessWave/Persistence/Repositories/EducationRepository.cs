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
    public class EducationRepository : BaseRepository, IEducationRepository
    {
        public EducationRepository(DatabaseContext context) :  base(context){}

        public async Task AddAsync(Education education)
        {
            await _context.Education.AddAsync(education);
        }

        public async Task<Education> FindByIdAsync(int id)
        {
            return await _context.Education.FindAsync(id);
        }

        public async Task<IEnumerable<Education>> ListAsync()
        {
            return await _context.Education.ToListAsync();
        }

        public void Remove(Education education)
        {
            _context.Education.Remove(education);
        }

        public void Update(Education education)
        {
            _context.Education.Update(education);
        }
    }
}
