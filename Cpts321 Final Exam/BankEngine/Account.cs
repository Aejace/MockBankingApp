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
        // Variables
        // string AssociatedClientUserName
        // double balance
        // LinkedList of transactions indicating history

        // Withdraw function, Takes in an amount.
        // If funds are sufficient, create withdraw transaction, add it to list, update balance
        // else, return a bool indicating failure

        // Deposit function
        // create deposit transaction, add it to list, update balance

        // Function to print history
        // Iterate through list of transactions, call print on each one.

        /// <summary>
        /// Object that encapsulates the information of a transaction, used to record history of transactions.
        /// </summary>
        private class Transaction
        {
            // Amount
            // associated accounts in the case of a transfer?
            // Function to print transaction
        }
    }
}
