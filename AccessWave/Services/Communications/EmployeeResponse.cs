using AccessWave.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessWave.Services.Communications
{
    public class EmployeeResponse : BaseResponse
    {
        public Employee Employee { get; private set; }
        public EmployeeResponse(bool success, string message, Employee employee) : base(success, message)
        {
            Employee = employee;
        }
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="employee">Saved employee.</param>
        /// <returns>Response.</returns>
        public EmployeeResponse(Employee employee) : this(true, string.Empty, employee)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public EmployeeResponse(string message) : this(false, message, null)
        { }
    }
}
