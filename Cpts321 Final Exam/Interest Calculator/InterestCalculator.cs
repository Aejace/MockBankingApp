// <copyright file="InterestCalculator.cs" company="Arlo Jones">
// Copyright (c) { Aejace studios }. All rights reserved.
// </copyright>

namespace Interest_Calculator
{
    using System;

    /// <summary>
    /// Calculates the interest amount.
    /// </summary>
    public class InterestCalculator
    {
        // Calculate function, takes in payment number and Interest rate, returns interest amount.

        /// <summary>
        /// Get interest gained for the month.
        /// </summary>
        /// <param name="balance"> Amount stored in account. </param>
        /// <param name="interestRate"> Interest rate for the account. </param>
        /// <returns> returns a double containing the interest earned for the month. </returns>
        public double GetInterest(double balance, double interestRate)
        {
            return balance * interestRate;
        }

        /// <summary>
        /// Calculates a payment Amount.
        /// </summary>
        /// <param name="paymentNumber"> Number of payments made towards loan so far. </param>
        /// <param name="interestRate"> Interest rate on the account. </param>
        /// <returns> Returns a paymentAmount. </returns>
        public double GetPaymentAmount(int paymentNumber, double interestRate)
        {
            // Implement Logic
            var paymentAmount = 33.25;
            return paymentAmount;
        }
    }
}
