using AccessWave.Domain.Models;
using AccessWave.Persistence.Context;
using AccessWave.Persistence.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessWave.Persistence.Repositories
{
    public class RuleRepository :  BaseRepository, IRuleRepository
    {
        public RuleRepository(DatabaseContext context) : base(context) { }

        public async Task AddAsync(Rule rule)
        {
            await _context.Rule.AddAsync(rule);
        }

        public async Task<Rule> FindByIdAsync(int id)
        {
            return await _context.Rule.FindAsync(id);
        }

        public async Task<IEnumerable<Rule>> ListAsync()
        {
            return await _context.Rule.ToListAsync();
        }

        public void Remove(Rule rule)
        {
            _context.Rule.Remove(rule);
        }

        public void Update(Rule rule)
        {
            _context.Rule.Update(rule);
        }
    }
}
