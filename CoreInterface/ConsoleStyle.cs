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

		public static ConsoleStyle Default { get; } = new ConsoleStyle("Default", ConsoleColor.Gray);

		public static ConsoleStyle Error { get; } = new ConsoleStyle("Error", ConsoleColor.Red);

		public static ConsoleStyle Info { get; } = new ConsoleStyle("Info", ConsoleColor.Blue);

		public static ConsoleStyle Ok { get; } = new ConsoleStyle("Ok", ConsoleColor.Green);

		public static ConsoleStyle Warning { get; } = new ConsoleStyle("Warning", ConsoleColor.Yellow);

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