// <copyright file="UserNameAndPasswordChecker.cs" company="Arlo Jones">
// Copyright (c) { Aejace studios }. All rights reserved.
// </copyright>

using System.Collections.Generic;

namespace Authenticator
{
    using System;

    /// <summary>
    /// Authenticates UserNames and password combinations.
    /// </summary>
    public class UserNameAndPasswordChecker
    {
        /// <summary>
        /// A dictionary containing valid username and password combinations.
        /// </summary>
        private Dictionary<string, string> validUsers;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserNameAndPasswordChecker"/> class.
        /// </summary>
        public UserNameAndPasswordChecker()
        {
            // Load user names and passwords from file, populate Dictionary
        }

        /// <summary>
        /// Checks the validity of a userName and password combination.
        /// </summary>
        /// <param name="userName"> The user name to be checked. </param>
        /// <param name="submittedPassword"> The password to be checked against. </param>
        /// <returns> A boolean representing whether or not the userName and password are a match against the records. </returns>
        public bool Authenticate(string userName, string submittedPassword)
        {
            var usersPassword = this.validUsers[userName];
            if (usersPassword == null)
            {
                return false;
            }

            return usersPassword == submittedPassword;
        }
    }
}
