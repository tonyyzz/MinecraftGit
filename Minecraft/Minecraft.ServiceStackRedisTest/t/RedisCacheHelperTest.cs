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
	public class RedisCacheHelperTest
	{
		public static void Do()
		{
			RedisCacheHelper redisCacheHelper = new RedisCacheHelper();
			string redisKey = RedisKeyHelper.GetRedisKeyName(RedisKeyConfig.Playerbasis, 1.ToString());

			redisCacheHelper.StringSet(redisKey, new TestResp { PlayerId = 1 });
			var res = redisCacheHelper.StringGet<TestResp>(redisKey);
			Console.WriteLine(res.JsonSerialize());
		}
	}
}
