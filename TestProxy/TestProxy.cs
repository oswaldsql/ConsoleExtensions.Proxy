// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestProxy.cs" company="Lasse Sjørup">
//   Copyright (c) 2019 Lasse Sjørup
//   Licensed under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoleExtensions.Proxy.TestHelpers
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Text;

    /// <summary>
    ///     Class TestProxy.
    /// </summary>
    /// <seealso cref="ConsoleExtensions.Proxy.IConsoleProxy" />
    public class TestProxy : IConsoleProxy
    {
        /// <summary>
        ///     The keys used for simulating the keys pressed by the user.
        /// </summary>
        public readonly Queue<ConsoleKeyInfo> Keys = new Queue<ConsoleKeyInfo>();

        /// <summary>
        ///     The resulting output.
        /// </summary>
        private readonly StringBuilder result = new StringBuilder();

        /// <summary>
        ///     Container for the console title.
        /// </summary>
        private string innerTitle;

        /// <summary>
        ///     The position of the cursor.
        /// </summary>
        private CursorPoint position;

        /// <summary>
        ///     Gets the width of the console window.
        /// </summary>
        public int WindowWidth => 80;

        /// <summary>
        ///     Gets or sets the background.
        /// </summary>
        private ConsoleColor Background { get; set; }

        /// <summary>
        ///     Gets or sets the foreground.
        /// </summary>
        private ConsoleColor Foreground { get; set; }

        /// <summary>
        ///     Plays the sound of a beep through the console speaker.
        /// </summary>
        /// <returns>The current Console Proxy.</returns>
        public IConsoleProxy Beep()
        {
            this.Append();
            return this;
        }

        /// <summary>
        ///     Clears the console window.
        /// </summary>
        /// <returns>The current Console Proxy.</returns>
        public IConsoleProxy Clear()
        {
            this.Append();
            return this;
        }

        /// <summary>
        ///     Gets the current position of the cursor.
        /// </summary>
        /// <param name="point">The current position of the cursor.</param>
        /// <returns>The current Console Proxy.</returns>
        public IConsoleProxy GetPosition(out CursorPoint point)
        {
            point = this.position;
            return this;
        }

        /// <summary>
        ///     Gets the current style of the console.
        /// </summary>
        /// <param name="style">The current style of the console.</param>
        /// <returns>The current Console Proxy.</returns>
        public IConsoleProxy GetStyle(out ConsoleStyle style)
        {
            style = new ConsoleStyle("current", this.Foreground, this.Background);
            return this;
        }

        /// <summary>
        ///     Gets the title to display in the console title bar.
        /// </summary>
        /// <param name="title">The string to be displayed in the title bar of the console.</param>
        /// <returns>The current Console Proxy.</returns>
        public IConsoleProxy GetTitle(out string title)
        {
            title = this.innerTitle;
            return this;
        }

        /// <summary>
        ///     Hides the cursor.
        /// </summary>
        /// <returns>The current Console Proxy.</returns>
        public IConsoleProxy HideCursor()
        {
            this.Append();
            return this;
        }

        /// <summary>
        ///     Obtains the next character or function key pressed by the user. The pressed key is optionally displayed in the
        ///     console window.
        /// </summary>
        /// <param name="key">
        ///     An object that describes the <see cref="T:System.ConsoleKey" /> constant and Unicode character, if
        ///     any, that correspond to the pressed console key. The <see cref="T:System.ConsoleKeyInfo" /> object also describes,
        ///     in a bitwise combination of <see cref="T:System.ConsoleModifiers" /> values, whether one or more Shift, Alt, or
        ///     Ctrl modifier keys was pressed simultaneously with the console key.
        /// </param>
        /// <param name="intercept">
        ///     Determines whether to display the pressed key in the console window. true to not display the
        ///     pressed key; otherwise, false.
        /// </param>
        /// <returns>The current Console Proxy.</returns>
        /// <exception cref="NoMoreKeysInKeyQueue">Thrown when no more keys exists in the queue.</exception>
        public IConsoleProxy ReadKey(out ConsoleKeyInfo key, bool intercept)
        {
            key = this.ReadKey(intercept);
            return this;
        }

        /// <summary>
        ///     Reads the next line of characters from the standard input stream.
        /// </summary>
        /// <param name="value">The next line of characters from the input stream.</param>
        /// <returns>The current Console Proxy.</returns>
        /// <exception cref="NoMoreKeysInKeyQueue">Thrown if no more keys exists in the console key queue.</exception>
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

        /// <summary>
        ///     Resets the color.
        /// </summary>
        /// <returns>The current Console Proxy.</returns>
        public IConsoleProxy ResetStyle()
        {
            this.Append();
            return this;
        }

        /// <summary>
        ///     Sets the colors of the console.
        /// </summary>
        /// <param name="foreground">The foreground color.</param>
        /// <param name="background">The background color.</param>
        /// <returns>The current Console Proxy.</returns>
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

        /// <summary>
        ///     Sets the position of the cursor.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns>The current Console Proxy.</returns>
        public IConsoleProxy SetPosition(CursorPoint point)
        {
            this.Write($"[{point.Left},{point.Top}]");
            return this;
        }

        /// <summary>
        ///     Sets the title to display in the console title bar.
        /// </summary>
        /// <param name="title">The string to be displayed in the title bar of the console.</param>
        /// <returns>The current Console Proxy.</returns>
        public IConsoleProxy SetTitle(string title)
        {
            this.Append(config: title);
            this.innerTitle = title;
            return this;
        }

        /// <summary>
        ///     Shows the cursor.
        /// </summary>
        /// <returns>The current Console Proxy.</returns>
        public IConsoleProxy ShowCursor()
        {
            this.Append();
            return this;
        }

        /// <summary>
        ///     Styles the output of the console based on a predefined style.
        /// </summary>
        /// <param name="style">The style.</param>
        /// <returns>The current Console Proxy.</returns>
        public IConsoleProxy Style(ConsoleStyle style)
        {
            this.SetColor(style.Foreground, style.Background);
            return this;
        }

        /// <summary>
        ///     Styles the output of the console based on a predefined style.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>The current Console Proxy.</returns>
        public IConsoleProxy Style(StyleName name)
        {
            this.Style(ConsoleStyle.Get(name));
            return this;
        }

        /// <summary>
        ///     Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return this.result.ToString();
        }

        /// <summary>
        ///     Writes the specified value to the console.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The current Console Proxy.</returns>
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

        /// <summary>
        ///     Writes a line break to the console.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The current Console Proxy.</returns>
        public IConsoleProxy WriteLine(string value)
        {
            this.Write(value);
            this.result.Append("\n");
            this.position = new CursorPoint(this.position.Top + 1, 0);
            return this;
        }

        /// <summary>
        ///     Appends the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="config">The configuration.</param>
        // ReSharper disable once MemberCanBePrivate.Global
        protected void Append([CallerMemberName] string name = null, string config = null)
        {
            this.result.Append(string.IsNullOrEmpty(config) ? $"[{name}]" : $"[{name}:{config}]");
        }

        /// <summary>
        ///     Reads a key from the keys queue.
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

            var name = intercept ? "InterceptedKey" : "Key";

            var info = this.Keys.Dequeue();
            this.Write(info.Key == ConsoleKey.Separator ? $"[{name}:'{info.KeyChar}']" : $"[{name}:{info.Key}]");

            return info;
        }
    }
}