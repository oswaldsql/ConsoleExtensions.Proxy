﻿namespace ConsoleExtensions.Proxy.Tests
{
	using ConsoleExtensions.Proxy.TestHelpers;

	using Xunit;

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