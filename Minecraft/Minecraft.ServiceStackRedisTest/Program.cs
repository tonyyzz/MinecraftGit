using Minecraft.CacheRedis;
using Minecraft.Config;
using RedisTools;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Minecraft.ServiceStackRedisTest
{
	class Program
	{
		static int port = 6382;
		static void Main(string[] args)
		{
			Console.WriteLine("serviceStack.Redis测试");
			PubSub.Do();
			Console.ReadKey();
		}

		
	}
}
