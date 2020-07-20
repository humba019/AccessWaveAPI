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
    public class StudentRepository : BaseRepository, IStudentRepository
    {
        public StudentRepository(DatabaseContext context) :  base(context) { }

        public async Task AddAsync(Student student)
        {
            await _context.Student.AddAsync(student);
        }

        public async Task<Student> FindByIdAsync(int id)
        {
            return await _context.Student.FindAsync(id);
        }

        public async Task<IEnumerable<Student>> ListAsync()
        {
            return await _context.Student.ToListAsync();
        }

        public void Remove(Student student)
        {
            _context.Student.Remove(student);
        }

        public void Update(Student student)
        {
            _context.Student.Update(student);
        }
    }
}
