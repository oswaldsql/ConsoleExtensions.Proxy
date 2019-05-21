// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WriteExtensions.cs" company="Lasse Sjørup">
//   Copyright (c) 2019 Lasse Sjørup
//   Licensed under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Demo
{
    using ConsoleExtensions.Proxy;

    /// <summary>
    ///     Class WriteExtensions.
    /// </summary>
    public static class WriteExtensions
    {
        /// <summary>
        ///     Writes a horizontal line in the console.
        /// </summary>
        /// <param name="console">The console.</param>
        /// <returns>The used Console Proxy.</returns>
        public static IConsoleProxy Hr(this IConsoleProxy console)
        {
            console.GetPosition(out var point);
            if (point.Left != 0)
            {
                console.WriteLine();
            }

            console.Write(new string('-', console.WindowWidth));
            return console;
        }
    }
}