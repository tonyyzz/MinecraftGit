using Minecraft.CacheRedis;
using Minecraft.Config;
using Minecraft.ServiceStackRedisTest.t;
using RedisTools;
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
		static void Main(string[] args)
		{
			Console.WriteLine("serviceStack.Redis测试");
			RedisCacheHelperTest.Do();
			Console.ReadKey();
		}
	}
}
