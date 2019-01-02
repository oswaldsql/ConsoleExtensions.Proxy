namespace ConsoleExtensions.Proxy
{
	using System;

	/// <summary>
	/// Class ConsoleStyle.
	/// </summary>
	public class ConsoleStyle
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ConsoleStyle"/> class.
		/// </summary>
		/// <param name="name">The name of the style.</param>
		/// <param name="foreground">The foreground color of the console.</param>
		/// <param name="background">The background color of the console..</param>
		public ConsoleStyle(string name, ConsoleColor? foreground = null, ConsoleColor? background = null)
		{
			this.Name = name;
			this.Foreground = foreground;
			this.Background = background;
		}

		public static ConsoleStyle Get(StyleName name)
		{
				switch (name)
				{
					case StyleName.Default:
						return ConsoleStyle.Default;
					case StyleName.Error:
						return ConsoleStyle.Error;
					case StyleName.Info:
						return ConsoleStyle.Info;
					case StyleName.Ok:
						return ConsoleStyle.Ok;
					case StyleName.Warning:
						return ConsoleStyle.Warning;
					default:
						return ConsoleStyle.Default;
				}
		}

		public static ConsoleStyle Default { get; } = new ConsoleStyle("Default", ConsoleColor.Gray, ConsoleColor.Black);

		public static ConsoleStyle Error { get; } = new ConsoleStyle("Error", ConsoleColor.Red, ConsoleColor.Black);

		public static ConsoleStyle Info { get; } = new ConsoleStyle("Info", ConsoleColor.Blue, ConsoleColor.Gray);

		public static ConsoleStyle Ok { get; } = new ConsoleStyle("Ok", ConsoleColor.Green, ConsoleColor.Black);

		public static ConsoleStyle Warning { get; } = new ConsoleStyle("Warning", ConsoleColor.Yellow, ConsoleColor.Black);

		/// <summary>
		/// Gets the background color of the console.
		/// </summary>
		/// <value>The background.</value>
		public ConsoleColor? Background { get; }

		/// <summary>
		/// Gets the foreground color of the console.
		/// </summary>
		/// <value>The foreground.</value>
		public ConsoleColor? Foreground { get; }

		/// <summary>
		/// Gets the name of the style.
		/// </summary>
		/// <value>The name.</value>
		public string Name { get; }
	}
}