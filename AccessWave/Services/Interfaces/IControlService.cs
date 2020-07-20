﻿using AccessWave.Domain.Models;
using AccessWave.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessWave.Services.Interfaces
{
    public interface IControlService
    {
        Task<IEnumerable<Control>> ListAsync();
        Task<ControlResponse> SaveAsync(Control control);
        Task<ControlResponse> UpdateAsync(int code, Control control);
        Task<ControlResponse> DeleteAsync(int code);
    }
}
