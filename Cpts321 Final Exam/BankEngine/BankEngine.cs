// <copyright file="BankEngine.cs" company="Arlo Jones">
// Copyright (c) { Aejace studios }. All rights reserved.
// </copyright>

using Authenticator;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;

namespace Bank_Engine
{
    /// <summary>
    /// Manages users, bank accounts, and transactions. Used to inform UI.
    /// </summary>
    public class BankEngine
    {
        /// <summary>
        /// The user currently logged in. May be a client or an administrator.
        /// </summary>
        public string CurrentUser;

        /// <summary>
        /// A dictionary containing all administrators, accessible by name.
        /// </summary>
        private Dictionary<string, Administrator> administrators = new Dictionary<string, Administrator>();

        /// <summary>
        /// A dictionary of all clients, accessible by name.
        /// </summary>
        private Dictionary<string, Client> clients = new Dictionary<string, Client>();

        /// <summary>
        /// Dictionary of all accounts by accountID.
        /// </summary>
        private Dictionary<string, Account> accounts = new Dictionary<string, Account>();

        /// <summary>
        /// Boolean reflecting whether or not the current user is an administrator.
        /// </summary>
        private bool currentUserIsAdmin = true;

        /// <summary>
        /// Changes out the current user to a new one.
        /// </summary>
        /// <param name="userName"> The userName of the new desired User. </param>
        /// <param name="password"> The password of that user. </param>
        /// <returns> A boolean representing whether or not the update was successful. </returns>
        public bool ChangeUser(string userName, string password)
        {
            var checker = new UserNameAndPasswordChecker();
            if (!checker.Authenticate(userName, password))
            {
                return false;
            }

            this.CurrentUser = userName;
            this.CheckAndUpdateCurrentUserAdminStatus(userName);
            return true;
        }

        /// <summary>
        /// Adds a user to the engine.
        /// </summary>
        /// <param name="userName"> The desired userName for the new user. </param>
        /// <param name="userType"> Indicates whether the user is an admin or a client. </param>
        /// <returns> A boolean indicating if the addition was successful. Will fail if username is already taken.</returns>
        public bool AddUser(string userName, string userType)
        {
            // If current user is an Admin and user name is not already taken,
            // Create user of specified type, either Admin or Client
            // Add to their respective lists.
            return true;
        }

        /// <summary>
        /// Adds an account to a user.
        /// </summary>
        /// <param name="userName"> The name of the user the account will belong to. </param>
        /// <param name="accountType"> The type of account to be created, either checking, savings, or loan. </param>
        /// <returns> The accountID of the account created. </returns>
        public string AddAccount(string userName, string accountType)
        {
            // Look through list of client names to find the one that matches
            // Get associated user
            // Create an account of type specified, either checking, savings, or loan
            // Add account ID to user's list of account ID's
            // Add account to bank engine's list of accounts
            string accountID = "";
            return accountID;
        }

        /// <summary>
        /// Gets account IDs the current user has access to.
        /// </summary>
        /// <returns> The account IDs associated with the current user. </returns>
        public List<string> GetAccountIDsAvailableToUser()
        {
            // If user is admin
            // return all accounts
            // If user is client
            // return client accounts
            var availableAccountIDs = new List<string>();
            return availableAccountIDs;
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

            // if account2 is a valid account ID (and not the same as account1)
            // subtract amount from account1, add amount to account2.
            return true;
        }

        /// <summary>
        /// Checks if the current user is an administrator, and toggle currentUserIsAdmin if that's the case.
        /// </summary>
        /// <param name="userName"> The user name of the current user. </param>
        private void CheckAndUpdateCurrentUserAdminStatus(string userName)
        {
            if (this.administrators.All(admin => admin.Key != userName))
            {
                this.currentUserIsAdmin = false;
                return;
            }

            this.currentUserIsAdmin = true;
        }

        /// <summary>
        /// Clients are customers of the bank. They can have bank accounts.
        /// </summary>
        private class Client : User
        {
            // Clients have access to their own accounts.
        }

        /// <summary>
        /// Administrators are employees of the bank. They can manage client accounts.
        /// </summary>
        private class Administrator : User
        {
            // Admin have access to all accounts
            // Admin can run add user and add account, But that wont be implemented because it's beyond the scope of the project in terms of UI.
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
