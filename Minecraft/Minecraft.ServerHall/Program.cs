using Minecraft.BLL;
using Minecraft.Config;
using Minecraft.Config.ipConst;
using Minecraft.ServerHall.ServerThreadPool;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.ServerHall
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("--------------【Minecraft服务器】---------------");
			Console.ResetColor();

			StartBLL.StartDBServerCheck();

			CSVConfig.Install();
			IpConstConfig.Init();

			//ServerThreadPoolTest.Start();


			//服务器最后启动
			MinecraftServerStart.Do();
		}
	}
}
