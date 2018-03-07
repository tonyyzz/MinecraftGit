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
			Console.WriteLine("--------------【Minecraft客户端】---------------");

			for (int i = 1; i <= 1000; i++)
			{
				ThreadPool.QueueUserWorkItem(o =>
				{
					ClientStart.Start();
				});
			}
			Console.ReadKey();
		}
	}
}
