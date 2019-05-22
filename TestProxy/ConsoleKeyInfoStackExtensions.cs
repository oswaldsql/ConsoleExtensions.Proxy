// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsoleKeyInfoStackExtensions.cs" company="Lasse Sjørup">
//   Copyright (c) 2019 Lasse Sjørup
//   Licensed under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable UnusedMethodReturnValue.Global
namespace ConsoleExtensions.Proxy.TestHelpers
{
	using System;
	using System.Collections.Generic;

	using JetBrains.Annotations;

	/// <summary>
	///     Class ConsoleKeyInfoStackExtensions.
	/// </summary>
	public static class ConsoleKeyInfoStackExtensions
	{
		/// <summary>
		///     Adds the specified string as individual characters to the console key queue.
		/// </summary>
		/// <param name="target">The console key queue to add to.</param>
		/// <param name="values">The string value to add.</param>
		/// <returns>The console key queue.</returns>
		public static Queue<ConsoleKeyInfo> Add(this Queue<ConsoleKeyInfo> target, string values)
		{
			var charArray = values.ToCharArray();
			foreach (var c in charArray)
			{
				target.Enqueue(new ConsoleKeyInfo(c, ConsoleKey.Separator, char.IsUpper(c), false, false));
			}

			return target;
		}

		/// <summary>
		///     Adds the specified console key to the console key queue.
		/// </summary>
		/// <param name="target">The console key queue to add to.</param>
		/// <param name="value">The key value to add.</param>
		/// <param name="controlKeys">The control keys used to specify [shift], [alt] and [ctrl] .</param>
		/// <returns>The console key queue.</returns>
		[UsedImplicitly]
		public static Queue<ConsoleKeyInfo> Add(
			this Queue<ConsoleKeyInfo> target,
			ConsoleKey value,
			ControlKeys controlKeys = ControlKeys.None)
		{
			target.Enqueue(
				new ConsoleKeyInfo(
					' ',
					value,
					controlKeys.HasFlag(ControlKeys.Shift),
					controlKeys.HasFlag(ControlKeys.Alt),
					controlKeys.HasFlag(ControlKeys.Control)));
			return target;
		}
	}
}