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
    public class EmployeeRepository : BaseRepository, IEmployeeRepository
    {
        public EmployeeRepository(DatabaseContext context) :  base(context) { }

        public async Task AddAsync(Employee employee)
        {
            await _context.Employee.AddAsync(employee);
        }

        public async Task<Employee> FindByIdAsync(int id)
        {
            return await _context.Employee.FindAsync(id);
        }

        public async Task<IEnumerable<Employee>> ListAsync()
        {
            return await _context.Employee.ToListAsync();
        }

        public void Remove(Employee employee)
        {
            _context.Employee.Remove(employee);
        }

        public void Update(Employee employee)
        {
            _context.Employee.Update(employee);
        }
    }
}
