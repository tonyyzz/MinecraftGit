﻿using Minecraft.BLL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.InitTest
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("--------------【Minecraft初始化】---------------");

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

			Console.WriteLine();

			//执行初始化方法
			Init.Do();

			Console.WriteLine();

			Console.WriteLine("按任意键退出程序");
			Console.ReadKey();

		}
	}
}
