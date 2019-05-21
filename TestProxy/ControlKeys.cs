// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ControlKeys.cs" company="Lasse Sjørup">
//   Copyright (c) 2019 Lasse Sjørup
//   Licensed under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoleExtensions.Proxy.TestHelpers
{
    using System;

    /// <summary>
    ///     Enum ControlKeys
    /// </summary>
    [Flags]
    public enum ControlKeys
    {
        /// <summary>
        ///     No control keys.
        /// </summary>
        None = 0,

        /// <summary>
        ///     The shift key.
        /// </summary>
        Shift = 1,

        /// <summary>
        ///     The alt key.
        /// </summary>
        Alt = 2,

        /// <summary>
        ///     The control key-
        /// </summary>
        Control = 4
    }
}