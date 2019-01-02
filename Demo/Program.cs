using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
	using ConsoleExtensions.Proxy;

	class Program
	{
		static void Main(string[] args)
		{
			var console = ConsoleProxy.Instance();

			console.SetTitle("Demo");

			Styling(console);

			console.ReadLine(out var t);

			Header(console);

			VanilaGreetAndAskForName();

			GreetAndAskForName(console);
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

		public static void Header(IConsoleProxy console)
		{
			console.HR().WriteLine(" Fantastic 'ask your name' app").HR();
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
	}

	public static class WriteExtensions
	{
		public static IConsoleProxy HR(this IConsoleProxy console)
		{
			console.Write(new string('-', console.WindowWidth));
			return console;
		}
	}
}
