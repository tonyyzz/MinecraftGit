using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Minecraft.ServerHall.ServerThreadPool
{
	public class ServerThreadPoolBase
	{
		public void Start(string threadPoolName, Action<object> action, object obj = null)
		{
			ThreadPool.QueueUserWorkItem(o =>
			{
				Console.WriteLine($" threadPoolName为【{threadPoolName}】的线程池启动...");
				while (true)
				{
					Thread.Sleep(1);
					if (action == null)
					{
						return;
					}
					action(o);
				}
			}, obj);
		}
	}
}
