using log4net.Repository.Hierarchy;
using Minecraft.Config;
using SuperSocket.SocketBase.Config;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Minecraft.ServerHall
{
	public class MinecraftServerStart
	{
		public static void Do()
		{
			var appServer = new MinecraftServer() ;
			ServerConfig serverConfig = new ServerConfig
			{
				TextEncoding = CommonConfig.DefEncoding.WebName,
				Port = 2017,
				DisableSessionSnapshot = true,
				MaxConnectionNumber = 5000,
			};
			//Setup the appServer
			//if (!appServer.Setup(2012)) //Setup with listening port
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();

			Console.WriteLine("服务器启动中...");
			if (!appServer.Setup(serverConfig)) //Setup with listening port
			{
				Console.WriteLine("Failed to setup!");
				Console.ReadKey();
				return;
			}

			//Try to start the appServer
			if (!appServer.Start())
			{
				Console.WriteLine("Failed to start!");
				Console.ReadKey();
				return;
			}
			stopwatch.Stop();
			Console.WriteLine($"服务器启动所花时间为：{stopwatch.Elapsed.TotalSeconds.ToString("0.00")} s");

			if (stopwatch.Elapsed.TotalSeconds < 1)
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine("【服务器启动时间较短，可能没有启用日志功能，请将Config目录中的log配置文件的属性：‘复制到输出目录’的值改成“如果较新则复制”（如果需要日志功能）】");
				Console.ResetColor();
			}

			Console.WriteLine("The server started successfully, press key 'q' to stop it!");

			//Console.WriteLine($"服务器文本编码：{appServer.TextEncoding.WebName}");

			//appServer.Logger.Error("");

			while (Console.ReadKey().KeyChar != 'q')
			{
				Console.WriteLine();
				continue;
			}

			//Stop the appServer
			appServer.Stop();

			Console.WriteLine("The server was stopped!");
			Console.ReadKey();
		}
	}
}
