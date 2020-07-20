using AccessWave.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessWave.Services.Communications
{
    public class PeriodResponse : BaseResponse
    {
        public Period Period { get; private set; }
        public PeriodResponse(bool success, string message, Period period) : base(success, message)
        {
            Period = period;
        }
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="period">Saved period.</param>
        /// <returns>Response.</returns>
        public PeriodResponse(Period period) : this(true, string.Empty, period)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public PeriodResponse(string message) : this(false, message, null)
        { }
    }
}
