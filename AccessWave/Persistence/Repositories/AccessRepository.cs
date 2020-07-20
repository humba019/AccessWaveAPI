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
    public class AccessRepository : BaseRepository, IAccessRepository
    {
        public AccessRepository(DatabaseContext context) : base (context) { }

        public async Task AddAsync(Access access)
        {
            await _context.Access.AddAsync(access);
        }

        public async Task<Access> FindByIdAsync(int id)
        {
            return await _context.Access.FindAsync(id);
        }

        public async Task<IEnumerable<Access>> ListAsync()
        {
            return await _context.Access.ToListAsync();
        }

        public void Remove(Access access)
        {
            _context.Access.Remove(access);
        }

        public void Update(Access access)
        {
            _context.Access.Update(access);
        }
    }
}
