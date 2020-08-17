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
    public class ControlRepository : BaseRepository, IControlRepository
    {
        public ControlRepository(DatabaseContext context) : base(context) { }

        public async Task AddAsync(Control control)
        {
            await _context.Control.AddAsync(control);
        }

        public async Task<Control> FindByIdAsync(int id)
        {
            return await _context.Control.FindAsync(id);
        }

        public async Task<List<Control>> ListAsync()
        {
            return await _context.Control.ToListAsync();
        }

        public void Remove(Control control)
        {
            _context.Control.Remove(control);
        }

        public void Update(Control control)
        {
            _context.Control.Update(control);
        }
    }
}
