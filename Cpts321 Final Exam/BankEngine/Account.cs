// <copyright file="Account.cs" company="Arlo Jones">
// Copyright (c) { Aejace studios }. All rights reserved.
// </copyright>

namespace Bank_Engine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// A clients bank account. May be a checking, savings, or loan account.
    /// Keeps track of transactions and totals.
    /// </summary>
    internal abstract class Account
    {
        /// <summary>
        /// An ongoing count of the total number of accounts that have been instantiated.
        /// </summary>
        internal static int numberOfAccountsCreated;

        /// <summary>
        /// Contains a record of transactions on the account. retains up to 10 transactions.
        /// </summary>
        internal readonly Queue<Transaction> transactionHistory = new Queue<Transaction>();

        /// <summary>
        /// Username of client who owns the account.
        /// </summary>
        public string associatedClientUserName;

        /// <summary>
        /// Unique account Identifier.
        /// </summary>
        public string accountID;

        /// <summary>
        /// Amount of money contained in the account.
        /// </summary>
        internal double balance = 0.00;

        /// <summary>
        /// Withdraws specified amount of money from the account.
        /// </summary>
        /// <param name="amount"> The amount of money to be withdrawn from the account. </param>
        /// <returns> A bool indicating whether or not the withdraw was successful. </returns>
        public bool Withdraw(double amount)
        {
            if (!(this.balance >= amount))
            {
                return false;
            }

            // Check size of Queue
            if (this.transactionHistory.Count == 10)
            {
                this.transactionHistory.Dequeue();
            }

            this.transactionHistory.Enqueue(new Transaction(amount, "Withdraw")); // Create transaction and add to history
            this.balance -= amount; // Update balance.
            return true;
        }

        /// <summary>
        /// Deposits specified amount of money into the account.
        /// </summary>
        /// <param name="amount"> The amount of money to be deposited into the account. </param>
        /// <returns> A bool indicating whether or not the deposit was successful. </returns>
        public bool Deposit(double amount)
        {
            // Check size of Queue
            if (this.transactionHistory.Count == 10)
            {
                this.transactionHistory.Dequeue();
            }

            this.transactionHistory.Enqueue(new Transaction(amount, "Deposit")); // Create transaction and add to history
            this.balance += amount; // Update balance.
            return true;
        }

        // Function to print history
        // Iterate through list of transactions, call print on each one.

        /// <summary>
        /// Prints the transaction history of the account.
        /// </summary>
        /// <returns> Returns a list of strings, where each string indicates the kind of transaction that took place, and the amount involved. </returns>
        public List<string> PrintHistory()
        {
            return this.transactionHistory.Select(transaction => transaction.PrintTransaction()).ToList();
        }

        /// <summary>
        /// Object that encapsulates the information of a transaction, used to record history of transactions.
        /// </summary>
        internal class Transaction
        {
            /// <summary>
            /// The amount of money involved in a transaction.
            /// </summary>
            private readonly double amount;

            /// <summary>
            /// The transaction type, either withdraw or deposit.
            /// </summary>
            private readonly string transactionType;

            /// <summary>
            /// Initializes a new instance of the <see cref="Transaction"/> class.
            /// </summary>
            /// <param name="amount"> The amount of money involved in the transaction.</param>
            /// <param name="transactionType"> The kind of transaction, Withdraw or deposit. </param>
            internal Transaction(double amount, string transactionType)
            {
                this.amount = amount;
                this.transactionType = transactionType;
            }

            /// <summary>
            /// Prints info contained in the transaction object.
            /// </summary>
            /// <returns> Returns a string containing the transaction type and amount. </returns>
            internal string PrintTransaction()
            {
                return this.transactionType + " " + this.amount;
            }
        }
    }
}
