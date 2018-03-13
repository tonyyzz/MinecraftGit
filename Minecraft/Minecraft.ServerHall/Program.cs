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

			#region 数据监测以及初始化
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			StartBLL.StartDBServerCheck(out bool canStartAll);
			stopwatch.Stop();
			if (canStartAll)
			{
				Console.WriteLine("数据库连接测试：所有数据库启动连接成功！");
			}
			else
			{
				Console.WriteLine($"数据库连接检查所花时间为：{stopwatch.Elapsed.TotalSeconds.ToString("0.00")} s");
				Console.WriteLine("按任意键退出");
				Console.ReadKey();
				return;
			}

			CSVConfig.Install();
			IpConstConfig.Init();

			//ServerThreadPoolTest.Start();

			#endregion

			//服务器最后启动
			MinecraftServerStart.Do();
		}
	}
}
