using Minecraft.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.CSRedisTest.TestFolder
{
	public class RedisTest
	{
		public static void Do()
		{
			CSRedis.RedisClient client = new CSRedis.RedisClient("localhost", 6379);
			string res= client.Set("test", "34");

			//var redisKey = "test";
			//RedisHelper redisHelper = new RedisHelper();
			//redisHelper.StringSet(redisKey, "56565", CommonConfig.DefRedisExpiry);
			//var cacheModel = redisHelper.StringGet(redisKey);

			//RedisHelper redisHelper = new RedisHelper();
			//string redisKey = RedisKeyHelper.GetRedisKeyName(RedisKeyConfig.Test, 1.ToString());
			//var f = redisHelper.StringGet<string>(redisKey);

			//CSRedis.RedisClient client = new CSRedis.RedisClient("localhost", 6379);
			//var res = client.SetAsync("test", "34", CommonConfig.DefRedisExpiry);
			//var task = client.GetAsync("test");
			//Console.WriteLine(task.Result);

		}
	}
}
