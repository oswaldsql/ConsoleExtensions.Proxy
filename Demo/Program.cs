// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Lasse Sjørup">
//   Copyright (c) 2019 Lasse Sjørup
//   Licensed under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Demo
{
    using System;

    using ConsoleExtensions.Proxy;

    /// <summary>
    ///     Class Program.
    /// </summary>
    public class Program
    {
        /// <summary>
        ///     Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            var console = ConsoleProxy.Instance();

            console.SetTitle("Demo");

            Styling(console);

            Header(console);

            VanillaGreetAndAskForName();

            GreetAndAskForName(console);

            console.ReadLine(out _);
        }

        /// <summary>
        ///     Greets the use and  ask for a name.
        /// </summary>
        /// <param name="console">The console to interact with.</param>
        private static void GreetAndAskForName(IConsoleProxy console)
        {
            console.WriteLine("Welcome user.").Write("What is your name? ").ReadLine(out var name).WriteLine()
                .WriteLine($"Welcome {name}").ReadLine(out _);
        }

        /// <summary>
        ///     Writes the headers of the application.
        /// </summary>
        /// <param name="console">The console to interact with.</param>
        private static void Header(IConsoleProxy console)
        {
            console.Hr().WriteLine(" Fantastic 'ask your name' app").Hr();
        }

        /// <summary>
        ///     Demo the styling capability.
        /// </summary>
        /// <param name="console">The console to interact with.</param>
        private static void Styling(IConsoleProxy console)
        {
            console.Style(StyleName.Ok).WriteLine("Mostly things are ok")
	            .Style(StyleName.Info).WriteLine("But sometimes you need to be informed")
	            .Style(StyleName.Warning).WriteLine("Or warned")
                .Style(StyleName.Error).WriteLine("Or things can go really bad").ResetStyle()
                .WriteLine("But mostly everything is fine.");
        }

        /// <summary>
        ///     How to do the same thing without proxy extensions.
        /// </summary>
        private static void VanillaGreetAndAskForName()
        {
            Console.WriteLine("Welcome user.");
            Console.WriteLine();
            Console.Write("What is your name? ");
            var name = Console.ReadLine();
            Console.WriteLine($"Welcome {name}");
            Console.ReadLine();
        }
    }
}