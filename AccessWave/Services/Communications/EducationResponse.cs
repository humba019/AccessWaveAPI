using AccessWave.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessWave.Services.Communications
{
    public class EducationResponse : BaseResponse
    {
        public Education Education { get; private set; }
        public EducationResponse(bool success, string message, Education education) : base(success, message)
        {
            Education = education;
        }
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="education">Saved education.</param>
        /// <returns>Response.</returns>
        public EducationResponse(Education education) : this(true, string.Empty, education)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public EducationResponse(string message) : this(false, message, null)
        { }
    }
}
