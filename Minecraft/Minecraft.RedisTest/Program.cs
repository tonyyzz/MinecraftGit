﻿using Minecraft.CacheRedis;
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
			RedisHelper redisHelper = new RedisHelper();
			TestReq req = new TestReq
			{
				PlayerId = 1,
			};
			//redisHelper.StringSet(MinecraftRedisKeyConfig.Test + req.PlayerId, req, MinecraftCommonConfig.DefRedisExpiry);

			var theReq = redisHelper.StringGet<TestReq>(MinecraftRedisKeyConfig.Test + req.PlayerId);

		}
	}
}
