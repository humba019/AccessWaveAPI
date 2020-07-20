using AccessWave.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessWave.Services.Communications
{
    public class RuleResponse : BaseResponse
    {
        public Rule Rule { get; private set; }
        public RuleResponse(bool success, string message, Rule rule) : base(success, message)
        {
            Rule = rule;
        }
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="control">Saved rule.</param>
        /// <returns>Response.</returns>
        public RuleResponse(Rule rule) : this(true, string.Empty, rule)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public RuleResponse(string message) : this(false, message, null)
        { }
    }
}
