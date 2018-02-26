using log4net.Repository.Hierarchy;
using Minecraft.Config;
using SuperSocket.SocketBase.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperSocketSdy.ConsoleTest.Telnet
{
	public class MinecraftServerStart
	{
		public void Do()
		{
			var appServer = new MinecraftServer();
			Console.WriteLine($"BodyName:{Encoding.UTF8.BodyName}");
			Console.WriteLine($"EncodingName:{Encoding.UTF8.EncodingName}");
			Console.WriteLine($"HeaderName:{Encoding.UTF8.HeaderName}");
			Console.WriteLine($"WebName:{Encoding.UTF8.WebName}");
			ServerConfig serverConfig = new ServerConfig
			{
				TextEncoding = CommonConfig.DefEncoding.WebName,
				Port = 2018,
				DisableSessionSnapshot = true,
				MaxConnectionNumber = 60000
			};
			//Setup the appServer
			//if (!appServer.Setup(2012)) //Setup with listening port
			Console.WriteLine("服务器启动中...");
			if (!appServer.Setup(serverConfig)) //Setup with listening port
			{
				Console.WriteLine("Failed to setup!");
				Console.ReadKey();
				return;
			}

			Console.WriteLine();

			//Try to start the appServer
			if (!appServer.Start())
			{
				Console.WriteLine("Failed to start!");
				Console.ReadKey();
				return;
			}

			Console.WriteLine("The server started successfully, press key 'q' to stop it!");

			Console.WriteLine($"服务器文本编码：{appServer.TextEncoding.WebName}");

			appServer.Logger.Error("");

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
