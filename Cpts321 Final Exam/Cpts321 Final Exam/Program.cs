// <copyright file="Program.cs" company="Arlo Jones">
// Copyright (c) { Aejace studios }. All rights reserved.
// </copyright>

namespace Cpts321_Final_Exam
{
    using System;
    using Bank_Engine;

    /// <summary>
    /// Class to contain function "Main".
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Entry point of the program.
        /// </summary>
        /// <param name="args"> Arguments passed into main (if any). </param>
        private static void Main(string[] args)
        {
            // Declare Local variables
            var bankEngine = new BankEngine();

            // Initialize some history for the bank engine
            bankEngine.AddUser("Giovanni_Medici", "Administrator"); // Add an administrator

            bankEngine.AddUser("NotARobot", "Client"); // Add a client
            bankEngine.AddAccount("NotARobot", "Checking"); // Add a checking account
            bankEngine.AddAccount("NotARobot", "Saving"); // Add a savings account
            bankEngine.AddAccount("NotARobot", "Loan"); // Add a loan account

            bankEngine.AddUser("StrugglingArtist", "Client"); // Add a client
            bankEngine.AddAccount("StrugglingArtist", "Checking"); // Add a checking account
            bankEngine.AddAccount("StrugglingArtist", "Saving"); // Add a savings account
            bankEngine.AddAccount("StrugglingArtist", "Loan"); // Add a loan account
            bankEngine.AddAccount("StrugglingArtist", "Loan"); // Add a loan account

            // Add transactions
            bankEngine.AccountTransaction("", "Deposit", 15000.00);

            // Home menu

            // Console.WriteLine("Hello World!");
        }
    }
}
