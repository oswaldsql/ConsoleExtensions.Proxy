// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProxyReadLineTests.cs" company="Lasse Sjørup">
//   Copyright (c) 2019 Lasse Sjørup
//   Licensed under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoleExtensions.Proxy.Tests
{
    using ConsoleExtensions.Proxy.TestHelpers;

    using Xunit;

    /// <summary>
    ///     Class ProxyReadLineTests.
    /// </summary>
    public class ProxyReadLineTests
    {
        /// <summary>
        ///     Given a test proxy with keys
        ///     when reaching a new line
        ///     then read line should return the expected result.
        /// </summary>
        [Fact]
        public void GivenATestProxyWithKeys_WhenReachingANewLine_ThenReadLineShouldReturnTheExpectedResult()
        {
            // Arrange
            var testProxy = new TestProxy();
            testProxy.Keys.Add("Read this\nBut not this");

            // Act
            testProxy.ReadLine(out var actual);

            // Assert
            Assert.Equal("Read this", actual);
        }

        /// <summary>
        ///     Given a test proxy with keys
        ///     when reaching end of keys
        ///     then read line should throw exceptions.
        /// </summary>
        [Fact]
        public void GivenATestProxyWithKeys_WhenReachingEndOfKeys_ThenReadLineShouldThrowExceptions()
        {
            // Arrange
            var testProxy = new TestProxy();
            testProxy.Keys.Add("Read this");

            // Act
            var exception = Record.Exception(() => testProxy.ReadLine(out _));

            // Assert
            Assert.IsType<NoMoreKeysInKeyQueue>(exception);
        }
    }
}