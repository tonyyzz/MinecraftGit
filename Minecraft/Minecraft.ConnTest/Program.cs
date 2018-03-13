using Minecraft.Config;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;

namespace Minecraft.ConnTest
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("--------------【Minecraft客户端】---------------");
			Console.ResetColor();

			//for (int i = 1; i <= 10; i++)
			//{
			//	ThreadPool.QueueUserWorkItem(o =>
			//	{
			//		ClientStart.Start();
			//	});
			//}

			ClientStart.Start();
			Console.ReadKey();
		}
	}
}
