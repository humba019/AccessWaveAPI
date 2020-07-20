using AccessWave.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessWave.Services.Communications
{
    public class ControlResponse : BaseResponse
    {
        public Control Control { get; private set; }
        public ControlResponse(bool success, string message, Control control) : base(success, message)
        {
            Control = control;
        }
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="control">Saved control.</param>
        /// <returns>Response.</returns>
        public ControlResponse(Control control) : this(true, string.Empty, control)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public ControlResponse(string message) : this(false, message, null)
        { }
    }
}
