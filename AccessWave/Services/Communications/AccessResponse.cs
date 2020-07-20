using AccessWave.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessWave.Services.Communications
{
    public class AccessResponse : BaseResponse
    {
        public Access Access { get; private set; }
        public AccessResponse(bool success, string message, Access access) : base(success, message)
        {
            Access = access;
        }
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="access">Saved access.</param>
        /// <returns>Response.</returns>
        public AccessResponse(Access access) : this(true, string.Empty, access)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public AccessResponse(string message) : this(false, message, null)
        { }
    }
}
