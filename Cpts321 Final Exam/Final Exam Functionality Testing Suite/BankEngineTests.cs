// <copyright file="BankEngineTests.cs" company="Arlo Jones">
// Copyright (c) { Aejace studios }. All rights reserved.
// </copyright>

namespace Final_Exam_Functionality_Testing_Suite
{
    using System.Collections.Generic;
    using Bank_Engine;
    using NUnit.Framework;

    /// <summary>
    /// Tests all major BankEngine functions and features.
    /// </summary>
    public class BankEngineTests
    {
        /// <summary>
        /// Tests to see if BankEngine can add an administrator.
        /// </summary>
        [Test]
        public void AddAdministrator()
        {
            var bankEngine = new BankEngine();

            // If adding an administrator is successful
            if (bankEngine.AddUser("GiovanniMedici", "Administrator"))
            {
                Assert.Pass();
            }

            Assert.Fail();
        }

        /// <summary>
        /// Tests to see if BankEngine can add a client.
        /// </summary>
        [Test]
        public void AddClients()
        {
            var bankEngine = new BankEngine();

            // If adding an client is successful
            if (bankEngine.AddUser("NotARobot", "Client"))
            {
                Assert.Pass();
            }

            Assert.Fail();
        }

        /// <summary>
        /// Tests to see if BankEngine fails correctly when trying to add a user using a user name that's already been taken.
        /// </summary>
        [Test]
        public void AddTakenUserName()
        {
            var bankEngine = new BankEngine();

            // Add Initial user
            bankEngine.AddUser("GiovanniMedici", "Administrator");

            // If adding user with same user name fails
            if (!bankEngine.AddUser("GiovanniMedici", "Client"))
            {
                Assert.Pass();
            }

            Assert.Fail();
        }

        /// <summary>
        /// Checks that AddUser fails correctly when given a type of user that doesn't exist.
        /// </summary>
        [Test]
        public void AddUserOfBadType()
        {
            var bankEngine = new BankEngine();

            // If adding user with a bad type name fails
            if (!bankEngine.AddUser("GiovanniMedici", "BadTypeName"))
            {
                Assert.Pass();
            }

            Assert.Fail();
        }

        /// <summary>
        /// Check to see that logging into a user updates the current user's text appropriately.
        /// </summary>
        [Test]
        public void ChangeCurrentUser()
        {
            var bankEngine = new BankEngine();
            bankEngine.ChangeUser("GiovanniMedici", "MakeHasteSlowly"); // Login to user

            Assert.AreEqual("GiovanniMedici", bankEngine.CurrentUser);
        }

        /// <summary>
        /// Tests to see if bankEngine adds checking accounts correctly.
        /// </summary>
        [Test]
        public void AddCheckingAccount()
        {
            var bankEngine = new BankEngine();
            bankEngine.AddUser("NotARobot", "Client"); // Add a Client

            // Add checking account to user and see if the ID generated is what is expected.
            Assert.AreEqual("C11", bankEngine.AddAccount("NotARobot", "Checking"));
        }

        /// <summary>
        /// Tests to see if bankEngine adds savings accounts correctly.
        /// </summary>
        [Test]
        public void AddSavingsAccount()
        {
            var bankEngine = new BankEngine();
            bankEngine.AddUser("NotARobot", "Client"); // Add a Client

            // Add checking account to user and see if the ID generated is what is expected.
            Assert.AreEqual("S11", bankEngine.AddAccount("NotARobot", "Saving"));
        }

        /// <summary>
        /// Tests to see if bankEngine adds Loan accounts correctly.
        /// </summary>
        [Test]
        public void AddLoanAccount()
        {
            var bankEngine = new BankEngine();
            bankEngine.AddUser("NotARobot", "Client"); // Add a Client

            // Add checking account to user and see if the ID generated is what is expected.
            Assert.AreEqual("L11", bankEngine.AddAccount("NotARobot", "Loan"));
        }
    }
}