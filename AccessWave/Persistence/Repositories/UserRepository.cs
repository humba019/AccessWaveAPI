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
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context) { }

        public async Task AddAsync(User user)
        {
            await _context.User.AddAsync(user);
        }

        public async Task<User> FindByIdAsync(string username)
        {
            return await _context.User.FindAsync(username);
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _context.User.ToListAsync();
        }

        public void Remove(User user)
        {
            _context.User.Remove(user);
        }

        public void Update(User user)
        {
            _context.User.Update(user);
        }
    }
}
