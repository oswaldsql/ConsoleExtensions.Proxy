// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StyleName.cs" company="Lasse Sjørup">
//   Copyright (c) 2019 Lasse Sjørup
//   Licensed under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoleExtensions.Proxy
{
    /// <summary>
    ///     Enum StyleName
    /// </summary>
    public enum StyleName
    {
        /// <summary>
        ///     The default style used by the console.
        /// </summary>
        Default,

        /// <summary>
        ///     Style used for displaying errors.
        /// </summary>
        Error,

        /// <summary>
        ///     Style used for displaying informational content.
        /// </summary>
        Info,

        /// <summary>
        ///     Style used for displaying OK information.
        /// </summary>
        Ok,

        /// <summary>
        ///     Style used for warnings.
        /// </summary>
        Warning
    }
}