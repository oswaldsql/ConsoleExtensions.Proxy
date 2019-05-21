// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProxyStyleTests.cs" company="Lasse Sjørup">
//   Copyright (c) 2019 Lasse Sjørup
//   Licensed under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoleExtensions.Proxy.Tests
{
    using System;

    using ConsoleExtensions.Proxy.TestHelpers;

    using Xunit;

    /// <summary>
    ///     Tests for the Proxy Style.
    /// </summary>
    public class ProxyStyleTests
    {
        /// <summary>
        ///     Given a basic proxy
        ///     when settings a style
        ///     then the colors of the console should change.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="foreground">The foreground.</param>
        /// <param name="background">The background.</param>
        [Theory]
        [InlineData(StyleName.Default, ConsoleColor.Gray, ConsoleColor.Black)]
        [InlineData(StyleName.Error, ConsoleColor.Red, ConsoleColor.Black)]
        [InlineData(StyleName.Info, ConsoleColor.Blue, ConsoleColor.Gray)]
        [InlineData(StyleName.Ok, ConsoleColor.Green, ConsoleColor.Black)]
        [InlineData(StyleName.Warning, ConsoleColor.Yellow, ConsoleColor.Black)]
        public void GivenABasicProxy_WhenSettingsAStyle_ThenTheColorsOfTheConsoleShouldChange(
            StyleName name,
            ConsoleColor foreground,
            ConsoleColor background)
        {
            // Arrange
            var testProxy = new TestProxy();

            // Act
            testProxy.Style(name);
            testProxy.GetStyle(out var actual);

            // Assert
            Assert.Equal("current", actual.Name);
            Assert.Equal(foreground, actual.Foreground);
            Assert.Equal(background, actual.Background);
        }
    }
}