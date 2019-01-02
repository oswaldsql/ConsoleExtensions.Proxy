namespace ConsoleExtensions.Proxy
{
	using System;

	/// <summary>
	/// Class ConsoleProxy.
	/// </summary>
	/// <seealso cref="ConsoleExtensions.Proxy.IConsoleProxy" />
	public class ConsoleProxy : IConsoleProxy
	{
		/// <summary>
		/// Initializes static members of the <see cref="ConsoleProxy"/> class.
		/// </summary>
		static ConsoleProxy()
		{
			Instance = new ConsoleProxy();
		}

		/// <summary>
		/// Prevents a default instance of the <see cref="ConsoleProxy"/> class from being created from the outside.
		/// </summary>
		private ConsoleProxy()
		{
		}

		/// <inheritdoc />
		public int WindowWidth => Console.WindowWidth;

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>The instance.</value>
		private static IConsoleProxy Instance { get; }

		/// <summary>
		/// Gets the shared instance of the console proxy.
		/// </summary>
		/// <returns>
		/// Instance of the console proxy wrapping the static System.Console.
		/// </returns>
		public static IConsoleProxy Get()
		{
			return Instance;
		}

		/// <inheritdoc />
		public IConsoleProxy Beep()
		{
			Console.Beep();
			return this;
		}

		/// <inheritdoc />
		public IConsoleProxy Clear()
		{
			Console.Clear();
			return this;
		}

		/// <inheritdoc />
		public IConsoleProxy GetPosition(out CursorPoint point)
		{
			point = new CursorPoint(Console.CursorTop, Console.CursorLeft);
			return this;
		}

		/// <inheritdoc />
		public IConsoleProxy GetStyle(out ConsoleStyle style)
		{
			style = new ConsoleStyle("current", Console.ForegroundColor, Console.BackgroundColor);
			return this;
		}

		public IConsoleProxy GetTitle(out string title)
		{
			title = Console.Title;
			return this;
		}

		/// <inheritdoc />
		public IConsoleProxy HideCursor()
		{
			Console.CursorVisible = false;
			return this;
		}

		/// <inheritdoc />
		public IConsoleProxy ReadKey(bool intercept, out ConsoleKeyInfo key)
		{
			key = Console.ReadKey(intercept);
			return this;
		}

		/// <inheritdoc />
		public IConsoleProxy ReadLine(out string result)
		{
			result = Console.ReadLine();
			return this;
		}

		/// <inheritdoc />
		public IConsoleProxy ResetStyle()
		{
			Console.ResetColor();
			return this;
		}

		/// <inheritdoc />
		public IConsoleProxy SetPosition(CursorPoint point)
		{
			Console.CursorTop = point.Top;
			Console.CursorLeft = point.Left;
			return this;
		}

		/// <inheritdoc />
		public IConsoleProxy ShowCursor()
		{
			Console.CursorVisible = true;
			return this;
		}

		/// <inheritdoc />
		public IConsoleProxy Style(ConsoleColor? foreground, ConsoleColor? background)
		{
			if (foreground.HasValue)
			{
				Console.ForegroundColor = foreground.Value;
			}

			if (background.HasValue)
			{
				Console.BackgroundColor = background.Value;
			}

			return this;
		}

		/// <inheritdoc />
		public IConsoleProxy Style(ConsoleStyle style)
		{
			this.Style(style.Foreground, style.Background);
			return this;
		}

		/// <inheritdoc />
		public IConsoleProxy SetTitle(string title)
		{
			Console.Title = title;
			return this;
		}

		/// <inheritdoc />
		public IConsoleProxy Write(string value)
		{
			Console.Write(value);
			return this;
		}

		/// <inheritdoc />
		public IConsoleProxy WriteLine()
		{
			Console.WriteLine();
			return this;
		}
	}
}