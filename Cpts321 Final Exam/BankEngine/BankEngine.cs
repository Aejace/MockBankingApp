// <copyright file="BankEngine.cs" company="Arlo Jones">
// Copyright (c) { Aejace studios }. All rights reserved.
// </copyright>

namespace Bank_Engine
{
    /// <summary>
    /// Manages users, bank accounts, and transactions. Used to inform UI.
    /// </summary>
    public class BankEngine
    {
        // Private variables to BankEngine
        // List of Admin
        // Dictionary of clients by Username.
        // List of all accounts by account name.

        /// <summary>
        /// Adds a user to the engine.
        /// </summary>
        /// <param name="userName"> The desired userName for the new user. </param>
        /// <param name="userType"> Indicates whether the user is an admin or a client. </param>
        public void AddUser(string userName, string userType)
        {
            // Check that user name is not already taken
            // Create user of specified type, either Admin or Client
            // Add to their respective lists.
        }

        /// <summary>
        /// Adds an account to a user.
        /// </summary>
        /// <param name="userName"> The name of the user the account will belong to. </param>
        /// <param name="accountType"> The type of account to be created, either checking, savings, or loan. </param>
        public void AddAccount(string userName, string accountType)
        {
            // Look through list of client names to find the one that matches
            // Get associated user
            // Create an account of type specified, either checking, savings, or loan
            // Add account ID to user's list of account ID's
            // Add account to bank engine's list of accounts
        }

        /// <summary>
        /// Executes a withdraw, deposit or transfer transaction.
        /// </summary>
        /// <param name="account1"> The account that money is being withdrawn from, deposited in, or transferred from. </param>
        /// <param name="account2"> The account that money is being transferred to. If not a transfer, this variable indicates the type of transaction. </param>
        /// <param name="amount"> The amount of money being adjusted on the accounts. </param>
        /// <returns> Whether or not the transaction was successful. It may fail if there were insufficient funds. </returns>
        public bool AccountTransaction(string account1, string account2, double amount)
        {
            // Get first account

            // If account2 is "Withdraw"
            // subtract amount from first account (using account.withdraw)

            // if account2 is "Deposit"
            // add amount to first account (using account.deposit)

            // if account2 is a valid account number (and not the same as account1)
            // subtract amount from account1, add amount to account2.
            return true;
        }

        /// <summary>
        /// Clients are customers of the bank. They can have bank accounts.
        /// </summary>
        private class Client : User
        {
        }

        /// <summary>
        /// Administrators are employees of the bank. They can manage client accounts.
        /// </summary>
        private class Administrator : User
        {
        }

        /// <summary>
        /// A checking bank account, used for the clients everyday transactions.
        /// </summary>
        private class Checking : Account
        {
            // Constructor
            // Sets Associated User
            // Generate and Sets account ID
        }

        /// <summary>
        /// A savings bank account. Has an interest rate that rewards the client for storing money in the account.
        /// </summary>
        private class Savings : Account
        {
            // Constructor
            // Sets associated User
            // Generate and Sets account ID
            // Sets interest rate
        }

        /// <summary>
        /// A bank account for a loan. Has an interest rate that rewards the bank for loaning the client money.
        /// </summary>
        private class Loan : Account
        {
            // static int number of Loan accounts created
            // int Number of payments made

            // Constructor
            // Sets associated User
            // Generate and Sets account ID
            // Set amount owed
            // Set interest rate
        }
    }
}
