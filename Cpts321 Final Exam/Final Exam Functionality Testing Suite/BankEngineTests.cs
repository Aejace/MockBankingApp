// <copyright file="BankEngineTests.cs" company="Arlo Jones">
// Copyright (c) { Aejace studios }. All rights reserved.
// </copyright>

namespace Final_Exam_Functionality_Testing_Suite
{
    using Bank_Engine;
    using NUnit.Framework;

    /// <summary>
    /// .
    /// </summary>
    public class BankEngineTests
    {
        [SetUp]
        public void Setup()
        {
            // Declare Local variables
            var bankEngine = new BankEngine();

            // Initialize some history for the bank engine
            bankEngine.AddUser("GiovanniMedici", "Administrator"); // Add an administrator

            bankEngine.AddUser("NotARobot", "Client"); // Add a client
            bankEngine.AddAccount("NotARobot", "Checking"); // Add a checking account
            bankEngine.AccountTransaction("C00", "Deposit", 15000.00); // Initialize account with a deposit
            bankEngine.AddAccount("NotARobot", "Saving"); // Add a savings account
            bankEngine.AccountTransaction("S10", "Deposit", 15000.00); // Initialize account with a deposit
            bankEngine.AddAccount("NotARobot", "Loan"); // Add a loan account
            bankEngine.AccountTransaction("L20", "Withdraw", 50000.00); // Set Loan balance to the amount of the loan.

            bankEngine.AddUser("StrugglingArtist", "Client"); // Add a client
            bankEngine.AddAccount("StrugglingArtist", "Checking"); // Add a checking account
            bankEngine.AccountTransaction("C31", "Deposit", 100.00);
            bankEngine.AddAccount("StrugglingArtist", "Saving"); // Add a savings account
            bankEngine.AccountTransaction("S41", "Deposit", 1000.00);
            bankEngine.AddAccount("StrugglingArtist", "Loan"); // Add a loan account
            bankEngine.AccountTransaction("L51", "Withdraw", 100000.00); // Set Loan balance to the amount of the loan.
            bankEngine.AddAccount("StrugglingArtist", "Loan"); // Add a loan account
            bankEngine.AccountTransaction("L52", "Withdraw", 50000.00); // Set Loan balance to the amount of the loan.

            // Add transactions
            bankEngine.AccountTransaction("C00", "L20", 5000.00); // NotARobot puts money towards loan
            bankEngine.AccountTransaction("C00", "C31", 20.00); // NotARobot pays some money to struggling artist for a commissioned piece.
            bankEngine.AccountTransaction("C31", "L51", 20.00); // StrugglingArtist puts money earned towards first loan.
            bankEngine.AccountTransaction("C00", "Deposit", 10000.00); // NotARobot makes money mining Doge-coin.
            bankEngine.AccountTransaction("C00", "Deposit", 10000.00); // NotARobot makes money mining Doge-coin.
            bankEngine.AccountTransaction("C00", "Deposit", 10000.00); // NotARobot makes money mining Doge-coin.
            bankEngine.AccountTransaction("C00", "Deposit", 10000.00); // NotARobot makes money mining Doge-coin.
            bankEngine.AccountTransaction("C00", "Deposit", 10000.00); // NotARobot makes money mining Doge-coin.
            bankEngine.AccountTransaction("C00", "Deposit", 10000.00); // NotARobot makes money mining Doge-coin.
            bankEngine.AccountTransaction("C00", "Deposit", 10000.00); // NotARobot makes money mining Doge-coin.
            bankEngine.AccountTransaction("C00", "Deposit", 10000.00); // NotARobot makes money mining Doge-coin.
            bankEngine.AccountTransaction("C00", "Deposit", 10000.00); // NotARobot makes money mining Doge-coin.
            bankEngine.AccountTransaction("C00", "L20", 45000.00); // NotARobot pays off loan
        }

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
        /// Tests to see if BankEngine can add an administrator.
        /// </summary>
        [Test]
        public void AddClients()
        {
            var bankEngine = new BankEngine();

            // If adding an administrator is successful
            if (bankEngine.AddUser("GiovanniMedici", "Administrator"))
            {
                Assert.Pass();
            }

            Assert.Fail();
        }

        [Test]
        public void AddClient()
        {
            var bankEngine = new BankEngine();
        }

        [Test]
        public void ChangeCurrentUser()
        {
            var bankEngine = new BankEngine();
            bankEngine.changeUser("GiovanniMedici", "MakeHasteSlowly"); // Login to user
        }
    }
}