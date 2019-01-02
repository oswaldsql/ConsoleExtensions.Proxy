// ReSharper disable ExceptionNotDocumented
// ReSharper disable ExceptionNotDocumentedOptional

namespace ConsoleExtensions.Proxy.Tests
{
	using ConsoleExtensions.Proxy.TestHelpers;

	using Xunit;

	public class ProxyReadLineTests
	{
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

	public class DemoTest
	{
		private static void GreetAndAskForName(IConsoleProxy console)
		{
			console.WriteLine("Welcome user.")
				.Write("What is your name? ")
				.ReadLine(out var name)
				.WriteLine()
				.WriteLine($"Welcome {name}")
				.ReadLine(out _);
		}

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

	}
}