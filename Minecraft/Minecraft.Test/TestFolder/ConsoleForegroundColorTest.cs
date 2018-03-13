using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.Test
{
	public class ConsoleForegroundColorTest
	{
		public static void Do()
		{
			ConsoleColor consoleColor = ConsoleColor.Black;
			var dict = consoleColor.GetEnumDesxriptionDict();
			foreach (var item in dict)
			{
				var theColor = (ConsoleColor)item.Key;
				Console.ForegroundColor = theColor;
				Console.WriteLine($"{theColor.ToString()}");
			}
		}
	}
}
