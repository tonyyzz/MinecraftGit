using Minecraft.Config;
using RedisTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.ServiceStackRedisTest
{
	class Program
	{
		static void Main(string[] args)
		{
			var redisKey = "test";
			RedisHelper redisHelper = new RedisHelper();
			redisHelper.StringSet(redisKey, "56565", CommonConfig.DefRedisExpiry);
			var cacheModel = redisHelper.StringGet<string>(redisKey);
			Console.WriteLine(cacheModel);
			Console.ReadKey();
		}
	}
}
