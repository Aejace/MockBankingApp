// <copyright file="User.cs" company="Arlo Jones">
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
    /// A client or employee of the bank.
    /// </summary>
    internal abstract class User
    {
        internal string userName;

        internal List<string> accessibleAccountIDs = new List<string>();
    }
}
