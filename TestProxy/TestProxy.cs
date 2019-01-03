namespace ConsoleExtensions.Proxy.TestHelpers
{
	using System;
	using System.Collections.Generic;
	using System.Runtime.CompilerServices;
	using System.Text;

	/// <summary>
	/// Class TestProxy.
	/// </summary>
	/// <seealso cref="ConsoleExtensions.Proxy.IConsoleProxy" />
	public class TestProxy : IConsoleProxy
	{
		/// <summary>
		/// The keys used for simulating the keys pressed by the user.
		/// </summary>
		public readonly Queue<ConsoleKeyInfo> Keys = new Queue<ConsoleKeyInfo>();

		/// <summary>
		/// The resulting output.
		/// </summary>
		private readonly StringBuilder result = new StringBuilder();

		/// <summary>
		/// Container for the console title.
		/// </summary>
		private string innerTitle;

		/// <summary>
		/// The position of the cursor.
		/// </summary>
		private CursorPoint position;

		/// <summary>
		/// Gets the width of the console window.
		/// </summary>
		/// <value>The width of the window.</value>
		public int WindowWidth => 80;

		/// <summary>
		/// Gets or sets the background.
		/// </summary>
		/// <value>The background.</value>
		private ConsoleColor Background { get; set; }

		/// <summary>
		/// Gets or sets the foreground.
		/// </summary>
		/// <value>The foreground.</value>
		private ConsoleColor Foreground { get; set; }

		/// <inheritdoc />
		public IConsoleProxy Beep()
		{
			this.Append();
			return this;
		}

		/// <inheritdoc />
		public IConsoleProxy Clear()
		{
			this.Append();
			return this;
		}

		/// <inheritdoc />
		public IConsoleProxy GetPosition(out CursorPoint point)
		{
			point = this.position;
			return this;
		}

		/// <inheritdoc />
		public IConsoleProxy GetStyle(out ConsoleStyle style)
		{
			style = new ConsoleStyle("current", this.Foreground, this.Background);
			return this;
		}

		public IConsoleProxy GetTitle(out string title)
		{
			title = this.innerTitle;
			return this;
		}

		/// <inheritdoc />
		public IConsoleProxy HideCursor()
		{
			this.Append();
			return this;
		}

		/// <inheritdoc />
		/// <exception cref="NoMoreKeysInKeyQueue">Thrown when no more keys exists in the queue.</exception>
		public IConsoleProxy ReadKey(out ConsoleKeyInfo key, bool intercept)
		{
			key = this.ReadKey(intercept);
			return this;
		}

		/// <inheritdoc />
		/// <exception cref="NoMoreKeysInKeyQueue">Thrown when no more keys exists in the key queue.</exception>
		public IConsoleProxy ReadLine(out string value)
		{
			var chars = new List<char>();
			while (true)
			{
				var next = this.Keys.Dequeue();
				if (next.KeyChar == '\n')
				{
					break;
				}

				if (this.Keys.Count == 0)
				{
					throw new NoMoreKeysInKeyQueue();
				}

				chars.Add(next.KeyChar);
			}

			value = new string(chars.ToArray());
			return this;
		}

		/// <inheritdoc />
		public IConsoleProxy ResetStyle()
		{
			this.Append();
			return this;
		}

		/// <inheritdoc />
		public IConsoleProxy SetPosition(CursorPoint point)
		{
			this.Write($"[{point.Left},{point.Top}]");
			return this;
		}

		/// <inheritdoc />
		public IConsoleProxy SetTitle(string title)
		{
			this.Append(config: title);
			this.innerTitle = title;
			return this;
		}

		/// <inheritdoc />
		public IConsoleProxy ShowCursor()
		{
			this.Append();
			return this;
		}

		/// <inheritdoc />
		public IConsoleProxy SetColor(ConsoleColor? foreground = null, ConsoleColor? background = null)
		{
			var config = string.Empty;
			if (foreground.HasValue && foreground != this.Foreground)
			{
				config += "F=" + foreground;
				this.Foreground = foreground.Value;
			}

			if (background.HasValue && background != this.Background)
			{
				config += "|B=" + background;
				this.Background = background.Value;
			}

			this.Append(config: config);

			return this;
		}

		/// <inheritdoc />
		public IConsoleProxy Style(ConsoleStyle style)
		{
			this.SetColor(style.Foreground, style.Background);
			return this;
		}

		public IConsoleProxy Style(StyleName name)
		{
			this.Style(ConsoleStyle.Get(name));
			return this;
		}

		/// <summary>
		/// Returns a <see cref="System.String" /> that represents this instance.
		/// </summary>
		/// <returns>A <see cref="System.String" /> that represents this instance.</returns>
		public override string ToString()
		{
			return this.result.ToString();
		}

		/// <inheritdoc />
		public IConsoleProxy Write(string value)
		{
			this.result.Append(value);
			this.position = this.position.MoveLeft(value.Length);
			if (this.position.Left > this.WindowWidth)
			{
				var lines = this.position.Left % this.WindowWidth;
				var left = this.position.Left / this.WindowWidth;

				this.position = new CursorPoint(this.position.Top + lines, left);
			}

			return this;
		}

		/// <inheritdoc />
		public IConsoleProxy WriteLine(string value)
		{
			this.Write(value);
			this.result.Append("\n");
			this.position = new CursorPoint(this.position.Top + 1, 0);
			return this;
		}

		/// <summary>
		/// Appends the specified name.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="config">The configuration.</param>
		protected void Append([CallerMemberName] string name = null, string config = null)
		{
			this.result.Append(string.IsNullOrEmpty(config) ? $"[{name}]" : $"[{name}:{config}]");
		}

		/// <summary>
		/// Reads a key from the keys queue.
		/// </summary>
		/// <param name="intercept">If true the key is intercepted.</param>
		/// <returns>the console key next in the queue.</returns>
		/// <exception cref="NoMoreKeysInKeyQueue">Thrown when no more keys exists in the queue.</exception>
		private ConsoleKeyInfo ReadKey(bool intercept)
		{
			if (this.Keys.Count == 0)
			{
				throw new NoMoreKeysInKeyQueue();
			}

			var info = this.Keys.Dequeue();
			if (info.Key == ConsoleKey.Separator)
			{
				this.Write($"[key:'{info.KeyChar}']");
			}
			else
			{
				this.Write($"[key:{info.Key}]");
			}

			return info;
		}
	}
}