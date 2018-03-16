using Minecraft.CacheRedis;
using Minecraft.Config;
using Minecraft.Model.ReqResp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.ServiceStackRedisTest.t
{
	public class RedisSentinelPatternTest
	{
		public static void Do()
		{
			RedisSentinelCacheHelper redisSentinelCacheHelper = new RedisSentinelCacheHelper();
			string redisKey = RedisKeyHelper.GetRedisKeyName(RedisKeyConfig.Playerbasis, 1.ToString());

			redisSentinelCacheHelper.StringSet(redisKey, new TestResp { PlayerId = 1 }, CommonConfig.DefRedisExpiry);
			var res = redisSentinelCacheHelper.StringGet<TestResp>(redisKey);
			Console.WriteLine(res.JsonSerialize());
		}
	}
}
