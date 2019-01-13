namespace Demo
{
	using System;

	using ConsoleExtensions.Proxy;

	public class Program
	{
		public static void Header(IConsoleProxy console)
		{
			console.HR().WriteLine(" Fantastic 'ask your name' app").HR();
		}

		public static void Main(string[] args)
		{
			var console = ConsoleProxy.Instance();

			console.SetTitle("Demo");

			Styling(console);

			Header(console);

			VanilaGreetAndAskForName();

			GreetAndAskForName(console);
			
			console.ReadLine(out _);
		}

		public static void Styling(IConsoleProxy console)
		{
			console
				.Style(StyleName.Ok)
				.WriteLine("Mostly things are ok")
				.Style(StyleName.Info)
				.WriteLine("But sometimes you need to be informed")
				.Style(StyleName.Warning)
				.WriteLine("Or warned")
				.Style(StyleName.Error)
				.WriteLine("Or things can go really bad")
				.ResetStyle()
				.WriteLine("But mostly everything is fine.");
		}

		private static void GreetAndAskForName(IConsoleProxy console)
		{
			console.WriteLine("Welcome user.")
				.Write("What is your name? ")
				.ReadLine(out var name)
				.WriteLine()
				.WriteLine($"Welcome {name}")
				.ReadLine(out _);
		}

		private static void VanilaGreetAndAskForName()
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