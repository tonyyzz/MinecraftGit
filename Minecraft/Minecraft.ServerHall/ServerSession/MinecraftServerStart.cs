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
#if DEBUG //本地测试
			int port = 2018;
#elif MINECRAFT_LAN //windows局域网测试
			int port = 2017;
#elif LINUX_LAN //linux局域网测试
			int port = 2017;
#else //（不使用，只用来做模板）
			int port = 2017;
#endif

			var appServer = new MinecraftServer();
			ServerConfig serverConfig = new ServerConfig
			{
				TextEncoding = CommonConfig.DefEncoding.WebName,
				Port = port,
				DisableSessionSnapshot = true,
				MaxConnectionNumber = 8000,
				SendBufferSize = 1024 * 1024 * 2,//（该字段应该表示客户端发送过来的最大字节长度）
				ReceiveBufferSize = 1024 * 200, //(该字段应该表示客户端接收的最大字节数，最大为1024 * 412，不然会启动失败)
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

			Console.WriteLine("The server started successfully, press key 'q' to stop it!");
			Console.WriteLine();
			//Console.WriteLine($"服务器文本编码：{appServer.TextEncoding.WebName}");

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
