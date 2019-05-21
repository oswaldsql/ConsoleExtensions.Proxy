// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProxyMinorMethodsTests.cs" company="Lasse Sjørup">
//   Copyright (c) 2019 Lasse Sjørup
//   Licensed under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoleExtensions.Proxy.Tests
{
    // ReSharper disable ExceptionNotDocumented
    // ReSharper disable ExceptionNotDocumentedOptional
    using ConsoleExtensions.Proxy.TestHelpers;

    using Xunit;

    /// <summary>
    ///     Class ProxyMinorMethodsTests.
    /// </summary>
    public class ProxyMinorMethodsTests
    {
        /// <summary>
        ///     Given a test proxy
        ///     when calling beep
        ///     then it should be rendered.
        /// </summary>
        [Fact]
        public void GivenATestProxy_WhenCallingBeep_ThenItShouldBeRendered()
        {
            // Arrange
            var proxy = new TestProxy();

            // Act
            proxy.Beep();

            // Assert
            Assert.Equal("[Beep]", proxy.ToString());
        }

        /// <summary>
        ///     Given a test proxy
        ///     when calling clear
        ///     then it should be rendered.
        /// </summary>
        [Fact]
        public void GivenATestProxy_WhenCallingClear_ThenItShouldBeRendered()
        {
            // Arrange
            var proxy = new TestProxy();

            // Act
            proxy.Clear();

            // Assert
            Assert.Equal("[Clear]", proxy.ToString());
        }

        /// <summary>
        ///     Given a test proxy
        ///     when calling show hide cursor
        ///     then it should be rendered.
        /// </summary>
        [Fact]
        public void GivenATestProxy_WhenCallingShowHideCursor_ThenItShouldBeRendered()
        {
            // Arrange
            var proxy = new TestProxy();

            // Act
            proxy.HideCursor().ShowCursor();

            // Assert
            Assert.Equal("[HideCursor][ShowCursor]", proxy.ToString());
        }

        /// <summary>
        ///     Given a test proxy
        ///     when setting and getting title
        ///     then it should be rendered.
        /// </summary>
        [Fact]
        public void GivenATestProxy_WhenSettingAndGettingTitle_ThenItShouldBeRendered()
        {
            // Arrange
            var proxy = new TestProxy();

            // Act
            proxy.SetTitle("Test").GetTitle(out var actual);

            // Assert
            Assert.Equal("[SetTitle:Test]", proxy.ToString());
            Assert.Equal("Test", actual);
        }
    }
}