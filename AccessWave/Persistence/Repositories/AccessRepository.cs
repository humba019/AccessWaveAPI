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
    public class AccessRepository : BaseRepository, IAccessRepository
    {
        public AccessRepository(DatabaseContext context) : base (context) { }

        public async Task AddAsync(Access access)
        {
            CultureInfo ci = new CultureInfo("en-US");
            TimeZoneInfo hrBrasilia = TZConvert.GetTimeZoneInfo("E. South America Standard Time");
            if (access.CodeDevice != 0)
            {
                access.Device = await _context.Device.FindAsync(access.CodeDevice);
                access.Device.User = await _context.User.FindAsync(access.Device.UserName);
                access.Device.User.Rule = await _context.Rule.FindAsync(access.Device.User.CodeRule);
            }
            if (access.CodeControl != 0)
            {
                access.Control = await _context.Control.FindAsync(access.CodeControl);
            }

            foreach(Access accessIn in await _context.Access.ToListAsync())
            {
                string firstKey = accessIn.Device.FirstBlock + "" + accessIn.Device.SecondBlock + "" + accessIn.Device.ThirdBlock + "" + accessIn.Device.FourthBlock;
                string secondKey = access.Device.FirstBlock + "" + access.Device.SecondBlock + "" + access.Device.ThirdBlock + "" + access.Device.FourthBlock;
                if (firstKey != secondKey)
                {
                    await _context.Access.AddAsync(access);
                    AccessLog accessLog = new AccessLog { CodeAccess = access.Code, CodeDevice = access.CodeDevice, LastAccess = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, hrBrasilia).ToString() };
                    await _context.AccessLog.AddAsync(accessLog);
                }
            }

        }

        public async Task<Access> AuthByDeviceAsync(int codeDevice)
        {
            CultureInfo ci = new CultureInfo("en-US");
            TimeZoneInfo hrBrasilia = TZConvert.GetTimeZoneInfo("E. South America Standard Time");

            Access access = new Access();
            foreach(Access accessIn in await _context.Access.ToListAsync()) 
            {
                if(accessIn.CodeDevice == codeDevice) 
                {
                    access = accessIn;
                }
            }
            Device deviceOut = await _context.Device.FindAsync(codeDevice);
            if (access == null)
            {
                access.CodeDevice = deviceOut.Code;
                access.Device = deviceOut;
                access.Device.User = await _context.User.FindAsync(deviceOut.UserName);
                access.Device.User.Rule = await _context.Rule.FindAsync(deviceOut.User.CodeRule);
                access.Entry = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, hrBrasilia).ToString();
                access.Exit = "Waiting";
                access.CodeControl = 1;
                access.Control = await _context.Control.FindAsync(1);

                if (codeDevice != access.Device.Code)
                {
                    await _context.Access.AddAsync(access);
                }
                AccessLog accessLog = new AccessLog { CodeAccess = access.Code, CodeDevice = access.CodeDevice, LastAccess = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, hrBrasilia).ToString() };
                await _context.AccessLog.AddAsync(accessLog);
            }
            else
            {
                DateTime now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, hrBrasilia);
                DateTime entry = DateTime.Parse(access.Entry, ci);
                DateTime expired = entry.AddMinutes(2);
                if (now >= expired) { 
                    access = await _context.Access.FindAsync(codeDevice);
                    access.Exit = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, hrBrasilia).ToString("", ci);
                    this.Update(access);
                }
                AccessLog accessLog = new AccessLog { CodeAccess = access.Code, CodeDevice = access.CodeDevice, LastAccess = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, hrBrasilia).ToString() };
                await _context.AccessLog.AddAsync(accessLog);
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
