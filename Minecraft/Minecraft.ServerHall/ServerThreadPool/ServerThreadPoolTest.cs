using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Minecraft.ServerHall.ServerThreadPool
{
	/// <summary>
	/// 测试线程池
	/// </summary>
	public class ServerThreadPoolTest
	{
		public static void Start()
		{
			new ServerThreadPoolBase().Start("ServerThreadPoolTest", o =>
			{
				Console.WriteLine(DateTime.Now.ToStr());
				Thread.Sleep(1000);
			});
		}
	}
}
