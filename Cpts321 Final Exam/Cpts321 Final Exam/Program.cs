// <copyright file="Program.cs" company="Arlo Jones">
// Copyright (c) { Aejace studios }. All rights reserved.
// </copyright>

using System.Collections.Generic;

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
            char mainMenuUserInput = '1';

            // Initialize some history for the bank engine
            bankEngine.AddUser("GiovanniMedici", "Administrator"); // Add an administrator

            bankEngine.AddUser("NotARobot", "Client"); // Add a client
            bankEngine.AddAccount("NotARobot", "Checking"); // Add a checking account
            bankEngine.AccountTransaction("C11", "Deposit", 15000.00); // Initialize account with a deposit
            bankEngine.AddAccount("NotARobot", "Saving"); // Add a savings account
            bankEngine.AccountTransaction("S21", "Deposit", 15000.00); // Initialize account with a deposit
            bankEngine.AddAccount("NotARobot", "Loan"); // Add a loan account
            bankEngine.AccountTransaction("L31", "Withdraw", 50000.00); // Set Loan balance to the amount of the loan.

            bankEngine.AddUser("StrugglingArtist", "Client"); // Add a client
            bankEngine.AddAccount("StrugglingArtist", "Checking"); // Add a checking account
            bankEngine.AccountTransaction("C42", "Deposit", 100.00);
            bankEngine.AddAccount("StrugglingArtist", "Saving"); // Add a savings account
            bankEngine.AccountTransaction("S52", "Deposit", 1000.00);
            bankEngine.AddAccount("StrugglingArtist", "Loan"); // Add a loan account
            bankEngine.AccountTransaction("L62", "Withdraw", 100000.00); // Set Loan balance to the amount of the loan.
            bankEngine.AddAccount("StrugglingArtist", "Loan"); // Add a loan account
            bankEngine.AccountTransaction("L73", "Withdraw", 50000.00); // Set Loan balance to the amount of the loan.

            // Add transactions
            bankEngine.AccountTransaction("C11", "L31", 5000.00); // NotARobot puts money towards loan
            bankEngine.AccountTransaction("C11", "C42", 20.00); // NotARobot pays some money to struggling artist for a commissioned piece.
            bankEngine.AccountTransaction("C42", "L62", 20.00); // StrugglingArtist puts money earned towards first loan.
            bankEngine.AccountTransaction("C11", "Deposit", 10000.00); // NotARobot makes money mining Doge-coin.
            bankEngine.AccountTransaction("C11", "Deposit", 10000.00); // NotARobot makes money mining Doge-coin.
            bankEngine.AccountTransaction("C11", "Deposit", 10000.00); // NotARobot makes money mining Doge-coin.
            bankEngine.AccountTransaction("C11", "Deposit", 10000.00); // NotARobot makes money mining Doge-coin.
            bankEngine.AccountTransaction("C11", "Deposit", 10000.00); // NotARobot makes money mining Doge-coin.
            bankEngine.AccountTransaction("C11", "Deposit", 10000.00); // NotARobot makes money mining Doge-coin.
            bankEngine.AccountTransaction("C11", "Deposit", 10000.00); // NotARobot makes money mining Doge-coin.
            bankEngine.AccountTransaction("C11", "Deposit", 10000.00); // NotARobot makes money mining Doge-coin.
            bankEngine.AccountTransaction("C11", "Deposit", 10000.00); // NotARobot makes money mining Doge-coin.
            bankEngine.AccountTransaction("C11", "L31", 45000.00); // NotARobot pays off loan

            // Struggling artist cries

            // Home menu
            while (mainMenuUserInput != '0')
            {
                switch (mainMenuUserInput)
                {
                    case '0':
                        break;

                    case '1':
                        var userName = "Name";
                        var password = "Password";
                        while (bankEngine.ChangeUser(userName, password) != true)
                        {
                            Console.WriteLine("Please enter user name: ");
                            userName = Console.ReadLine();
                            Console.WriteLine("Please enter Password: ");
                            password = Console.ReadLine();
                        }

                        Console.WriteLine("\n Welcome, " + userName + "\n");
                        break;

                    case '2':
                        DisplayAccounts();
                        break;

                    case '3':
                        DisplayTransactionDialouge();
                        break;

                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }

                DisplayMainMenu();
                mainMenuUserInput = Console.ReadLine()[0];
            }

            void DisplayMainMenu()
            {
                Console.WriteLine("Please Select an option: ");
                Console.WriteLine("[0] Quit");
                Console.WriteLine("[1] Change User");
                Console.WriteLine("[2] Check Status of Accounts");
            }

            void DisplayAccounts()
            {
                Console.WriteLine("\n");
                var accountIDs = bankEngine.GetAccountIDsAvailableToUser();
                for (var i = 0; i < accountIDs.Count; i++)
                {
                    Console.WriteLine("[" + i + "]" + bankEngine.PrintAccountByID(accountIDs[i]) + "\n");
                }
            }

            void DisplayTransactionDialouge()
            {

            }
        }
    }
}
