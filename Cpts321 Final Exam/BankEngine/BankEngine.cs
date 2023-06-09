﻿// <copyright file="BankEngine.cs" company="Arlo Jones">
// Copyright (c) { Aejace studios }. All rights reserved.
// </copyright>

namespace Bank_Engine
{
    using System.Collections.Generic;
    using System.Linq;
    using Authenticator;
    using Interest_Calculator;

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
        private readonly Dictionary<string, Administrator> administrators = new Dictionary<string, Administrator>();

        /// <summary>
        /// A dictionary of all clients, accessible by name.
        /// </summary>
        private readonly Dictionary<string, Client> clients = new Dictionary<string, Client>();

        /// <summary>
        /// Dictionary of all accounts by accountID.
        /// </summary>
        private readonly Dictionary<string, Account> accounts = new Dictionary<string, Account>();

        /// <summary>
        /// List of all accountIDs.
        /// </summary>
        private readonly List<string> allAccounts = new List<string>();

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
            if (!this.currentUserIsAdmin)
            {
                return false;
            }

            // and user name is not already taken
            if (this.administrators.Any(admin => admin.Key == userName))
            {
                return false;
            }

            if (this.clients.Any(client => client.Key == userName))
            {
                return false;
            }

            // Create user of specified type, either Admin or Client and add it to their respective lists.
            switch (userType)
            {
                case "Administrator":
                    {
                        var newAdmin = new Administrator(userName, this.allAccounts);
                        this.administrators.Add(userName, newAdmin);
                        return true;
                    }

                case "Client":
                    {
                        var newClient = new Client(userName);
                        this.clients.Add(userName, newClient);
                        return true;
                    }
            }

            return false;
        }

        /// <summary>
        /// Adds an account to a user.
        /// </summary>
        /// <param name="userName"> The name of the user the account will belong to. </param>
        /// <param name="accountType"> The type of account to be created, either checking, savings, or loan. </param>
        /// <returns> The accountID of the account created. </returns>
        public string AddAccount(string userName, string accountType)
        {
            // If current user is an Admin
            if (!this.currentUserIsAdmin)
            {
                return "Unauthorized access";
            }

            var currentClient = this.clients[userName];
            if (currentClient == null)
            {
                return "Unrecognized User Name";
            }

            var newAccountID = "Error";

            switch (accountType)
            {
                case "Checking":
                {
                    var newChecking = new Checking(userName);
                    newAccountID = newChecking.accountID;
                    currentClient.accessibleAccountIDs.Add(newAccountID);
                    this.accounts.Add(newAccountID, newChecking);
                    this.allAccounts.Add(newAccountID);
                    break;
                }

                case "Saving":
                {
                    var newSaving = new Saving(userName, 0.005);
                    newAccountID = newSaving.accountID;
                    currentClient.accessibleAccountIDs.Add(newAccountID);
                    this.accounts.Add(newAccountID, newSaving);
                    this.allAccounts.Add(newAccountID);
                    break;
                }

                case "Loan":
                {
                    var newLoan = new Loan(userName, 0.005, 5000.00);
                    newAccountID = newLoan.accountID;
                    currentClient.accessibleAccountIDs.Add(newAccountID);
                    this.accounts.Add(newAccountID, newLoan);
                    this.allAccounts.Add(newAccountID);
                    break;
                }
            }

            return newAccountID;
        }

        /// <summary>
        /// Gets account IDs current user has access to.
        /// </summary>
        /// <returns> The account IDs associated with the current user. </returns>
        public List<string> GetAccountIDsAvailableToUser()
        {
            if (this.currentUserIsAdmin)
            {
                return this.allAccounts;
            }
            else
            {
                var client = this.clients[this.CurrentUser];
                return client.accessibleAccountIDs;
            }
        }

        public string PrintAccountByID(string accountID)
        {
            var currentAccount = this.accounts[accountID];
            return currentAccount.PrintAccount();
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
            var fromAccount = this.accounts[account1];

            switch (account2)
            {
                case "Withdraw":
                    return fromAccount.Withdraw(amount);

                case "Deposit":
                    return fromAccount.Deposit(amount);
            }

            if (!this.allAccounts.Contains(account2))
            {
                return false;
            }

            var toAccount = this.accounts[account2];
            if (!fromAccount.Withdraw(amount))
            {
                return false;
            }

            toAccount.Deposit(amount);
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
            /// <summary>
            /// Initializes a new instance of the <see cref="Client"/> class.
            /// </summary>
            /// <param name="userName"> The userName associated with the account. </param>
            internal Client(string userName)
            {
                this.userName = userName;
            }
        }

        /// <summary>
        /// Administrators are employees of the bank. They can manage client accounts.
        /// </summary>
        private class Administrator : User
        {
            // Admin have access to all accounts
            // Admin can run add user and add account, But that wont be implemented because it's beyond the scope of the project in terms of UI.

            /// <summary>
            /// Initializes a new instance of the <see cref="Administrator"/> class.
            /// </summary>
            /// <param name="userName"> The userName associated with the account. </param>
            /// <param name="allAccountIDs"> List of all accountIDs. </param>
            internal Administrator(string userName, List<string> allAccountIDs)
            {
                this.userName = userName;
                this.accessibleAccountIDs = allAccountIDs;
            }
        }

        /// <summary>
        /// A checking bank account, used for the clients everyday transactions.
        /// </summary>
        private class Checking : Account
        {
            /// <summary>
            /// Total number of checking accounts that have been created.
            /// </summary>
            private static int numberOfCheckingAccountsCreated = 0;

            /// <summary>
            /// Initializes a new instance of the <see cref="Checking"/> class.
            /// </summary>
            /// <param name="userName"> The name of the user associated with the account. </param>
            internal Checking(string userName)
            {
                this.associatedClientUserName = userName;
                ++numberOfAccountsCreated;
                ++numberOfCheckingAccountsCreated;
                this.accountID = "C" + numberOfAccountsCreated.ToString() + numberOfCheckingAccountsCreated.ToString();
            }

            /// <summary>
            /// Prints account information.
            /// </summary>
            /// <returns> Returns a string containing information about the account. </returns>
            public override string PrintAccount()
            {
                var toPrint = "Account ID: " + this.accountID + "\n Current Balance: " + this.balance + "\n Transaction History: ";
                var history = this.PrintHistory();
                return history.Aggregate(toPrint, (current, transaction) => current + transaction + "\n");
            }
        }

        /// <summary>
        /// A savings bank account. Has an interest rate that rewards the client for storing money in the account.
        /// </summary>
        private class Saving : Account
        {
            /// <summary>
            /// Total number of Saving accounts that have been created.
            /// </summary>
            private static int numberOfSavingAccountsCreated = 0;

            /// <summary>
            /// Interest rate for the account.
            /// </summary>
            private readonly double interestRate = 0.005;

            /// <summary>
            /// Total interest gained so far through the year.
            /// </summary>
            private double interestAccruedThisYear = 0.00;

            /// <summary>
            /// Initializes a new instance of the <see cref="Saving"/> class.
            /// </summary>
            /// <param name="userName"> The name of the user associated with the account. </param>
            /// <param name="interest"> Interest rate of the account. </param>
            internal Saving(string userName, double interest)
            {
                this.associatedClientUserName = userName;
                this.interestRate = interest;
                ++numberOfAccountsCreated;
                ++numberOfSavingAccountsCreated;
                this.accountID = "S" + numberOfAccountsCreated + numberOfSavingAccountsCreated;
            }

            public void AddInterestForMonthToAccount()
            {
                var calculator = new InterestCalculator();
                var interestEarned = calculator.GetInterest(this.balance, this.interestRate);
                this.Deposit(interestEarned);
                this.interestAccruedThisYear += interestEarned;
            }

            /// <summary>
            /// Prints account information.
            /// </summary>
            /// <returns> Returns a string containing information about the account. </returns>
            public override string PrintAccount()
            {
                var toPrint = "Account ID: " + this.accountID
                                             + "\n Current Balance: " + this.balance
                                             + "\n Interest Rate: " + this.interestRate
                                             + "\n Interest Accrued This Year: " + this.interestAccruedThisYear
                                             + "\n Transaction History: ";

                var history = this.PrintHistory();
                return history.Aggregate(toPrint, (current, transaction) => current + transaction + "\n");
            }
        }

        /// <summary>
        /// A bank account for a loan. Has an interest rate that rewards the bank for loaning the client money.
        /// </summary>
        private class Loan : Account
        {
            /// <summary>
            /// Total number of Loan accounts that have been created.
            /// </summary>
            private static int numberOfLoanAccountsCreated = 0;

            /// <summary>
            /// Interest rate for the account.
            /// </summary>
            private readonly double interestRate = 0.025;

            /// <summary>
            /// Total amount of the loan taken out.
            /// </summary>
            private readonly double totalAmount = 0.00;

            /// <summary>
            /// Interest owed each month.
            /// </summary>
            private double paymentAmount = 0.00;

            /// <summary>
            /// Initializes a new instance of the <see cref="Loan"/> class.
            /// </summary>
            /// <param name="userName"> The name of the user associated with the account. </param>
            /// <param name="interest"> Interest rate of the account. </param>
            /// <param name="amount"> Amount of money loaned to client by the bank. </param>
            internal Loan(string userName, double interest, double amount)
            {
                this.associatedClientUserName = userName;
                this.interestRate = interest;
                this.totalAmount = amount;
                ++numberOfAccountsCreated;
                ++numberOfLoanAccountsCreated;
                this.accountID = "L" + numberOfAccountsCreated + numberOfLoanAccountsCreated;
                this.GetMonthlyInterestPaymentAmount();
                this.Withdraw(amount);
            }

            /// <summary>
            /// Prints account information.
            /// </summary>
            /// <returns> Returns a string containing information about the account. </returns>
            public override string PrintAccount()
            {
                var toPrint = "Account ID: " + this.accountID
                                             + "\n Loan Amount : " + this.totalAmount
                                             + "\n Current Balance: " + this.balance
                                             + "\n Interest Rate: " + this.interestRate
                                             + "\n Transaction History: ";

                var history = new List<string>();
                foreach (var transaction in this.transactionHistory)
                {
                    var interestPaid = 0.00;
                    interestPaid = transaction.amount > this.paymentAmount ? this.paymentAmount : transaction.amount;

                    var transactionPrint = transaction.transactionType
                        + "\n Interest paid: " + interestPaid
                        + "\n Principal paid: " + (transaction.amount - interestPaid);
                    history.Add(transactionPrint);
                }

                return history.Aggregate(toPrint, (current, transaction) => current + transaction + "\n");
            }

            /// <summary>
            /// Calculates monthly payment amount.
            /// </summary>
            private void GetMonthlyInterestPaymentAmount()
            {
                var calculator = new InterestCalculator();
                this.paymentAmount = calculator.GetPaymentAmount(this.depositsMade, this.interestRate);
            }
        }
    }
}
