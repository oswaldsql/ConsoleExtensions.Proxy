// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DemoTest.cs" company="Lasse Sjørup">
//   Copyright (c) 2019 Lasse Sjørup
//   Licensed under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoleExtensions.Proxy.Tests
{
    using ConsoleExtensions.Proxy.TestHelpers;

    using Xunit;

    /// <summary>
    ///     Class DemoTest.
    /// </summary>
    public class DemoTest
    {
        /// <summary>
        ///     Given a call to greet
        ///     when user gives name
        ///     then the greeting should be rendered.
        /// </summary>
        [Fact]
        public void GivenACallToGreet_WhenUserGivesName_ThenTheGreetingShouldBeRendered()
        {
            // Arrange
            var testProxy = new TestProxy();
            testProxy.Keys.Add("Oswald\n\n");

            // Act
            GreetAndAskForName(testProxy);

            // Assert
            Assert.Equal("Welcome user.\nWhat is your name? \nWelcome Oswald\n", testProxy.ToString());
        }

        /// <summary>
        ///     Greets the user by name.
        /// </summary>
        /// <param name="console">The console.</param>
        private static void GreetAndAskForName(IConsoleProxy console)
        {
            console.WriteLine("Welcome user.").Write("What is your name? ").ReadLine(out var name).WriteLine()
                .WriteLine($"Welcome {name}").ReadLine(out _);
        }
    }
}