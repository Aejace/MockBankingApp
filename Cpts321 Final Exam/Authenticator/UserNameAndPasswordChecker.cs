// <copyright file="UserNameAndPasswordChecker.cs" company="Arlo Jones">
// Copyright (c) { Aejace studios }. All rights reserved.
// </copyright>

namespace Authenticator
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Authenticates UserNames and password combinations.
    /// </summary>
    public class UserNameAndPasswordChecker
    {
        /// <summary>
        /// A dictionary containing valid username and password combinations.
        /// </summary>
        private Dictionary<string, string> validUsers = new Dictionary<string, string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="UserNameAndPasswordChecker"/> class.
        /// </summary>
        public UserNameAndPasswordChecker()
        {
            // ToDo: Load user names and passwords from file, populate Dictionary with values
            // Temporary Hardcoded dictionary values:
            this.validUsers.Add("GiovanniMedici", "MakeHasteSlowly");
            this.validUsers.Add("NotARobot", "10101");
            this.validUsers.Add("StrugglingArtist", "IHateBanking");
        }

        /// <summary>
        /// Checks the validity of a userName and password combination.
        /// </summary>
        /// <param name="userName"> The user name to be checked. </param>
        /// <param name="submittedPassword"> The password to be checked against. </param>
        /// <returns> A boolean representing whether or not the userName and password are a match against the records. </returns>
        public bool Authenticate(string userName, string submittedPassword)
        {
            try
            {
                var usersPassword = this.validUsers[userName];
                return usersPassword == submittedPassword;
            }
            catch
            {
                return false;
            }
        }
    }
}
