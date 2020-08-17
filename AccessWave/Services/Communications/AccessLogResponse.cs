using AccessWave.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessWave.Services.Communications
{
    public class AccessLogResponse : BaseResponse
    {
        public AccessLog Access { get; private set; }
        public AccessLogResponse(bool success, string message, AccessLog access) : base(success, message)
        {
            Access = access;
        }
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="access">Saved access.</param>
        /// <returns>Response.</returns>
        public AccessLogResponse(AccessLog access) : this(true, string.Empty, access)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public AccessLogResponse(string message) : this(false, message, null)
        { }
    }
}
