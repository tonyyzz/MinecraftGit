using Minecraft.CacheRedis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Minecraft.ServiceStackRedisTest.t
{
	public class ServiceStackTest
	{
		public static void Do()
		{
			Console.WriteLine("redis 发布选择1，订阅选择2");
			var index = Convert.ToInt32(Console.ReadLine());
			if (index == 1)
			{
				Console.WriteLine("选择的是发布");
				using (RedisPubSubHelper redisPubSubHelper = new RedisPubSubHelper())
				{
					for (int i = 1; i <= 50; i++)
					{
						//服务器
						redisPubSubHelper.PublishMessage("channel-1", string.Format("这是我发送的第{0}消息!", i));
						Thread.Sleep(200);
					}
				}
			}
			else
			{
				Console.WriteLine("选择的是订阅");
				using (RedisPubSubHelper redisPubSubHelper = new RedisPubSubHelper())
				{
					redisPubSubHelper.Subscription(new List<string> { "channel-1" },
						(channel, msg) =>
						{
							Console.WriteLine("-------------------------");
							Console.WriteLine($"channel:{channel}");
							Console.WriteLine($"msg:{msg}");
							Console.WriteLine($"时间：{DateTime.Now.ToStr()}");
						});
				}
			}
		}
	}
}
