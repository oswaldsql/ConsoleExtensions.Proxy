// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NoMoreKeysInKeyQueue.cs" company="Lasse Sj�rup">
//   Copyright (c) 2019 Lasse Sj�rup
//   Licensed under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoleExtensions.Proxy.TestHelpers
{
    using System;

    /// <summary>
    ///     Class NoMoreKeysInKeyQueue. Thrown when the console key queue is empty. Implements the
    ///     <see cref="System.Exception" />
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class NoMoreKeysInKeyQueue : Exception
    {
    }
}