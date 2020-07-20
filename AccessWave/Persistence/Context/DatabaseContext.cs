using AccessWave.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessWave.Persistence.Context
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Rule> Rule { get; set; }
        public DbSet<Period> Period { get; set; }
        public DbSet<Education> Education { get; set; }
        public DbSet<Control> Control { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Access> Access { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Rule>().ToTable("RULE");
            builder.Entity<Rule>().HasKey(r => r.Code);
            builder.Entity<Rule>().Property(r => r.Code).IsRequired().ValueGeneratedOnAdd(); 
            builder.Entity<Rule>().Property(r => r.Type).IsRequired();
            builder.Entity<Rule>().Property(r => r.Description).IsRequired();

            builder.Entity<Rule>().HasData(
                new Rule { Code =  1, Type = "STUDENT", Description = "Limited actions/views for Students." }
            );

            builder.Entity<Period>().ToTable("PERIOD");
            builder.Entity<Period>().HasKey(p => p.Code);
            builder.Entity<Period>().Property(p => p.Code).IsRequired().ValueGeneratedOnAdd(); 
            builder.Entity<Period>().Property(p => p.Description).IsRequired();
            builder.Entity<Period>().Property(p => p.Start).IsRequired();
            builder.Entity<Period>().Property(p => p.End).IsRequired();

            builder.Entity<Period>().HasData(
                new Period { Code = 1, Description = "Limited actions/views for Students.", Start = DateTime.Now.ToString(), End = DateTime.Now.AddHours(8).ToString() }
            );

            builder.Entity<Education>().ToTable("EDUCATION");
            builder.Entity<Education>().HasKey(e => e.Code);
            builder.Entity<Education>().Property(e => e.Code).IsRequired().ValueGeneratedOnAdd(); 
            builder.Entity<Education>().Property(e => e.Level).IsRequired();
            builder.Entity<Education>().Property(e => e.Description).IsRequired();

            builder.Entity<Education>().HasData(
                new Education { Code = 1, Level = "Technical", Description = "Systems Development Technical Education" }
            );

            builder.Entity<Control>().ToTable("CONTROL");
            builder.Entity<Control>().HasKey(c => c.Code);
            builder.Entity<Control>().Property(c => c.Code).IsRequired().ValueGeneratedOnAdd(); 
            builder.Entity<Control>().Property(c => c.Description).IsRequired();
            builder.Entity<Control>().Property(c => c.Entry).IsRequired();
            builder.Entity<Control>().Property(c => c.Exit).IsRequired();

            builder.Entity<Control>().HasData(
                new Control { Code = 1, Description = "Diurnal Control", Entry = DateTime.Now.ToString(), Exit = DateTime.Now.AddHours(8).ToString() }
            );

            builder.Entity<User>().ToTable("USER");
            builder.Entity<User>().HasKey(u => u.UserName);
            builder.Entity<User>().Property(c => c.UserName).IsRequired();
            builder.Entity<User>().Property(c => c.UserPass).IsRequired();
            builder.Entity<User>().Property(c => c.FullName).IsRequired();
            builder.Entity<User>().Property(c => c.LastAccess).IsRequired();
            builder.Entity<User>().Property(c => c.CodeRule).IsRequired();

            builder.Entity<User>().HasData(
                new User { UserName = "humba", UserPass = "12345", FullName = "Humberto Barreto", LastAccess = DateTime.Now.ToString(), CodeRule = 1 }
            );

            builder.Entity<Employee>().ToTable("EMPLOYEE");
            builder.Entity<Employee>().HasKey(e => e.Code);
            builder.Entity<Employee>().Property(e => e.Code).IsRequired();
            builder.Entity<Employee>().Property(e => e.User).IsRequired();
            builder.Entity<Employee>().Property(e => e.Period).IsRequired();

            builder.Entity<Employee>().HasData(
                new Employee { Code = 1, UserName = "humba", CodePeriod = 1 }
            );

            builder.Entity<Student>().ToTable("STUDENT");
            builder.Entity<Student>().HasKey(s => s.Code);
            builder.Entity<Student>().Property(s => s.Code).IsRequired();
            builder.Entity<Student>().Property(s => s.UserName).IsRequired();
            builder.Entity<Student>().Property(s => s.CodePeriod).IsRequired();
            builder.Entity<Student>().Property(s => s.CodeEducation).IsRequired();

            builder.Entity<Student>().HasData(
                new Student { Code = 1, UserName = "humba", CodePeriod = 1, CodeEducation = 1 }
            );

            builder.Entity<Access>().ToTable("ACCESS");
            builder.Entity<Access>().HasKey(a => a.Code);
            builder.Entity<Access>().Property(a => a.Code).IsRequired();
            builder.Entity<Access>().Property(a => a.Entry).IsRequired();
            builder.Entity<Access>().Property(a => a.Exit).IsRequired();
            builder.Entity<Access>().Property(a => a.CodeEmployee).IsRequired();
            builder.Entity<Access>().Property(a => a.CodeStudent).IsRequired();
            builder.Entity<Access>().Property(a => a.CodeControl).IsRequired();

            builder.Entity<Access>().HasData(
                new Access { Code = 1, Entry = DateTime.Now.ToString(), Exit = DateTime.Now.AddHours(8).ToString(), CodeEmployee = 1, CodeStudent = 1, CodeControl = 1 }
            );

        }
    }
}
