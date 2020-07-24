using AccessWave.Domain.Models;
using AccessWave.Persistence.Context;
using AccessWave.Persistence.Repositories.Interface;
using AutoMapper;
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

        public async Task<Access> AuthByDeviceAsync(int codeDevice)
        {
            Access access = new Access();
            foreach (Access accessObj in await _context.Access.ToListAsync())
            {
                if (accessObj.CodeDevice != codeDevice)
                {
                    Device deviceObj = await _context.Device.FindAsync(codeDevice);
                    if (deviceObj != null)
                    {
                        access.CodeDevice = deviceObj.Code;
                        access.Device = deviceObj;
                        access.Device.User = await _context.User.FindAsync(deviceObj.UserName);
                        access.Device.User.Rule = await _context.Rule.FindAsync(deviceObj.User.CodeRule);
                        foreach (Student student in await _context.Student.ToListAsync())
                        {
                            if (student.UserName.Equals(access.Device.UserName))
                            {
                                access.CodeStudent = student.Code;
                            }
                        }

                        access.Entry = DateTime.Now.ToString();
                        access.Exit = "Waiting";
                        access.CodeControl = 1;
                        access.Control = await _context.Control.FindAsync(1);

                        await _context.Access.AddAsync(access);
                    }
                }
                else
                {
                    access = await _context.Access.FindAsync(accessObj.Code);
                    access.Exit = DateTime.Now.ToString();
                    this.Update(access);
                }
            }
            return access;
        }

        public async Task<Access> FindByIdAsync(int code)
        {
            Access access = await _context.Access.FindAsync(code);
            if (access != null)
            {
                if (access.CodeDevice != 0)
                {
                    access.Device = await _context.Device.FindAsync(access.CodeDevice);
                    access.Device.User = await _context.User.FindAsync(access.Device.UserName);
                    access.Device.User.Rule = await _context.Rule.FindAsync(access.Device.User.CodeRule);
                    foreach (Student student in await _context.Student.ToListAsync())
                    {
                        if (student.UserName.Equals(access.Device.UserName))
                        {
                            access.CodeStudent = student.Code;
                        }
                    }
                }
                if (access.CodeControl != 0)
                {
                    access.Control = await _context.Control.FindAsync(access.CodeControl);
                }
            }

            return access;
        }

        public async Task<List<Access>> ListAsync()
        {
            List<Access> list =  new List<Access>();
            foreach (Access access in await _context.Access.ToListAsync()) 
            {

                if (access.CodeDevice != 0)
                {
                    access.Device = await _context.Device.FindAsync(access.CodeDevice);
                    access.Device.User = await _context.User.FindAsync(access.Device.UserName);
                    access.Device.User.Rule = await _context.Rule.FindAsync(access.Device.User.CodeRule);
                    foreach (Student student in await _context.Student.ToListAsync())
                    {
                        if (student.UserName.Equals(access.Device.UserName))
                        {
                            access.CodeStudent = student.Code;
                        }
                    }
                }
                if (access.CodeControl != 0)
                {
                    access.Control = await _context.Control.FindAsync(access.CodeControl);
                }

                list.Add(access);
            }

            return list;
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
