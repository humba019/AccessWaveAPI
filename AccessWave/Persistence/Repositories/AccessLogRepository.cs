using AccessWave.Domain.Models;
using AccessWave.Extensions;
using AccessWave.Persistence.Context;
using AccessWave.Persistence.Repositories.Interface;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using TimeZoneConverter;

namespace AccessWave.Persistence.Repositories
{
    public class AccessLogRepository : BaseRepository, IAccessLogRepository
    {
        public AccessLogRepository(DatabaseContext context) : base (context) { }

        public async Task AddAsync(AccessLog accessLog)
        {
            var device = await _context.Device.FindAsync(accessLog.CodeDevice);
            var access = await _context.Access.FindAsync(accessLog.CodeAccess);
            if (device != null)
            {
                if (access != null)
                {
                    await _context.AccessLog.AddAsync(accessLog);
                }
            }                
        }

        public async Task<AccessLog> FindByIdAsync(int code)
        {
            return await _context.AccessLog.FindAsync(code);
        }

        public async Task<List<AccessLog>> ListAsync()
        {
            return await _context.AccessLog.ToListAsync();
        }

        public async Task<List<AccessLog>> ListByAccessCodeAsync(int code)
        {
            List<AccessLog> list = new List<AccessLog>();
            foreach (AccessLog accessLog in await _context.AccessLog.ToListAsync()) 
            {
                if (accessLog.CodeAccess.Equals(code))
                {
                    list.Add(accessLog);
                }
            }
            return list;
        }

        public void Remove(AccessLog accessLog)
        {
            _context.AccessLog.Remove(accessLog);
        }

        public void Update(AccessLog accessLog)
        {
            _context.AccessLog.Update(accessLog);
        }
    }
}
