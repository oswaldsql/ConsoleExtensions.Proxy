// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsoleProxy.cs" company="Lasse Sjørup">
//   Copyright (c) 2019 Lasse Sjørup
//   Licensed under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoleExtensions.Proxy
{
    using System;

    /// <summary>
    ///     Class ConsoleProxy.
    /// </summary>
    /// <seealso cref="ConsoleExtensions.Proxy.IConsoleProxy" />
    public class ConsoleProxy : IConsoleProxy
    {
        /// <summary>
        ///     Initializes static members of the <see cref="ConsoleProxy" /> class.
        /// </summary>
        static ConsoleProxy()
        {
            LocalInstance = new ConsoleProxy();
        }

        /// <summary>
        ///     Prevents a default instance of the <see cref="ConsoleProxy" /> class from being created from the outside.
        /// </summary>
        private ConsoleProxy()
        {
        }

        /// <summary>
        ///     Gets the width of the console window.
        /// </summary>
        public int WindowWidth => Console.WindowWidth;

        /// <summary>
        ///     Gets the instance.
        /// </summary>
        private static IConsoleProxy LocalInstance { get; }

        /// <summary>
        ///     Gets the shared instance of the console proxy.
        /// </summary>
        /// <returns>Instance of the console proxy wrapping the static System.Console.</returns>
        public static IConsoleProxy Instance()
        {
            return LocalInstance;
        }

        /// <summary>
        ///     Plays the sound of a beep through the console speaker.
        /// </summary>
        /// <returns>The current Console Proxy.</returns>
        public IConsoleProxy Beep()
        {
            Console.Beep();
            return this;
        }

        /// <summary>
        ///     Clears the console window.
        /// </summary>
        /// <returns>The current Console Proxy.</returns>
        public IConsoleProxy Clear()
        {
            Console.Clear();
            return this;
        }

        /// <summary>
        ///     Gets the current position of the cursor.
        /// </summary>
        /// <param name="point">The current position of the cursor.</param>
        /// <returns>The current Console Proxy.</returns>
        public IConsoleProxy GetPosition(out CursorPoint point)
        {
            point = new CursorPoint(Console.CursorTop, Console.CursorLeft);
            return this;
        }

        /// <summary>
        ///     Gets the current style of the console.
        /// </summary>
        /// <param name="style">The current style of the console.</param>
        /// <returns>The current Console Proxy.</returns>
        /// <exception cref="T:System.Security.SecurityException">The user does not have permission to perform this action.</exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred.</exception>
        public IConsoleProxy GetStyle(out ConsoleStyle style)
        {
            style = new ConsoleStyle("current", Console.ForegroundColor, Console.BackgroundColor);
            return this;
        }

        /// <summary>
        ///     Gets the title to display in the console title bar.
        /// </summary>
        /// <param name="title">The string to be displayed in the title bar of the console.</param>
        /// <returns>The current Console Proxy.</returns>
        public IConsoleProxy GetTitle(out string title)
        {
            title = Console.Title;
            return this;
        }

        /// <summary>
        ///     Hides the cursor.
        /// </summary>
        /// <returns>The current Console Proxy.</returns>
        public IConsoleProxy HideCursor()
        {
            Console.CursorVisible = false;
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
        public IConsoleProxy ReadKey(out ConsoleKeyInfo key, bool intercept = false)
        {
            key = Console.ReadKey(intercept);
            return this;
        }

        /// <summary>
        ///     Reads the next line of characters from the standard input stream.
        /// </summary>
        /// <param name="result">The next line of characters from the input stream.</param>
        /// <returns>The current Console Proxy.</returns>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred.</exception>
        /// <exception cref="T:System.OutOfMemoryException">
        ///     There is insufficient memory to allocate a buffer for the returned
        ///     string.
        /// </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///     The number of characters in the next line of characters is
        ///     greater than <see cref="F:System.Int32.MaxValue" />.
        /// </exception>
        public IConsoleProxy ReadLine(out string result)
        {
            result = Console.ReadLine();
            return this;
        }

        /// <summary>
        ///     Resets the color.
        /// </summary>
        /// <returns>The current Console Proxy.</returns>
        /// <exception cref="T:System.Security.SecurityException">The user does not have permission to perform this action.</exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred.</exception>
        public IConsoleProxy ResetStyle()
        {
            Console.ResetColor();
            return this;
        }

        /// <summary>
        ///     Sets the colors of the console.
        /// </summary>
        /// <param name="foreground">The foreground color.</param>
        /// <param name="background">The background color.</param>
        /// <returns>The current Console Proxy.</returns>
        /// <exception cref="T:System.Security.SecurityException">The user does not have permission to perform this action.</exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred.</exception>
        public IConsoleProxy SetColor(ConsoleColor? foreground, ConsoleColor? background)
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

        /// <summary>
        ///     Sets the position of the cursor.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns>The current Console Proxy.</returns>
        public IConsoleProxy SetPosition(CursorPoint point)
        {
            Console.CursorTop = point.Top;
            Console.CursorLeft = point.Left;
            return this;
        }

        /// <summary>
        ///     Sets the title to display in the console title bar.
        /// </summary>
        /// <param name="title">The string to be displayed in the title bar of the console.</param>
        /// <returns>The current Console Proxy.</returns>
        public IConsoleProxy SetTitle(string title)
        {
            Console.Title = title;
            return this;
        }

        /// <summary>
        ///     Shows the cursor.
        /// </summary>
        /// <returns>The current Console Proxy.</returns>
        public IConsoleProxy ShowCursor()
        {
            Console.CursorVisible = true;
            return this;
        }

        /// <summary>
        ///     Styles the output of the console based on a predefined style.
        /// </summary>
        /// <param name="style">The style.</param>
        /// <returns>The current Console Proxy.</returns>
        /// <exception cref="T:System.Security.SecurityException">The user does not have permission to perform this action.</exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred.</exception>
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
        /// <exception cref="T:System.Security.SecurityException">The user does not have permission to perform this action.</exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred.</exception>
        public IConsoleProxy Style(StyleName name)
        {
            this.Style(ConsoleStyle.Get(name));
            return this;
        }

        /// <summary>
        ///     Writes the specified value to the console.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The current Console Proxy.</returns>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred.</exception>
        public IConsoleProxy Write(string value)
        {
            Console.Write(value);
            return this;
        }

        /// <summary>
        ///     Writes a line break to the console.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The current Console Proxy.</returns>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred.</exception>
        public IConsoleProxy WriteLine(string value = "")
        {
            Console.WriteLine(value);
            return this;
        }
    }
}