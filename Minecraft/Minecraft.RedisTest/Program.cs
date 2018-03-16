using Minecraft.CacheRedis;
using Minecraft.Config;
using Minecraft.Model.ReqResp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.RedisTest
{
	class Program
	{
		static void Main(string[] args)
		{
			RedisSingleCacheHelper redisCacheHelper = new RedisSingleCacheHelper();
			TestReq req = new TestReq
			{
				PlayerId = 1,
			};
			//redisHelper.StringSet(RedisKeyConfig.Test + req.PlayerId, req, CommonConfig.DefRedisExpiry);

			//var theReq = redisHelper.StringGet<TestReq>(RedisKeyConfig.Test + req.PlayerId);

			//redisHelper.StringOptTest();

		}
	}
}
