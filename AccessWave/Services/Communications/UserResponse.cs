﻿using AccessWave.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessWave.Services.Communications
{
    public class UserResponse : BaseResponse
    {
        public User User { get; private set; }
        public UserResponse(bool success, string message, User user) : base(success, message)
        {
            User = user;
        }
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="user">Saved user.</param>
        /// <returns>Response.</returns>
        public UserResponse(User user) : this(true, string.Empty, user)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public UserResponse(string message) : this(false, message, null)
        { }
    }
}
