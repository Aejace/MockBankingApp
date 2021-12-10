// <copyright file="UserNameAndPasswordChecker.cs" company="Arlo Jones">
// Copyright (c) { Aejace studios }. All rights reserved.
// </copyright>

namespace Authenticator
{
    using System;

    /// <summary>
    /// Authenticates UserNames and password combinations.
    /// </summary>
    public class UserNameAndPasswordChecker
    {
        // Dictionary of UserName Keys and password values
        // Constructor populates dictionary by reading in from a file
        // Authenticate function that checks and returns a boolean

        /// <summary>
        /// Checks the validity of a userName and password combination.
        /// </summary>
        /// <param name="userName"> The user name to be checked. </param>
        /// <param name="password"> The password to be checked against. </param>
        /// <returns> A boolean representing whether or not the userName and password are a match against the records. </returns>
        public bool Authenticate(string userName, string password)
        {
            return true;
        }
    }
}
