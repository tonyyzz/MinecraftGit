using Minecraft.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.CacheRedis
{
	public class StartCacheRedis
	{
		public static bool StartCacheRedisCheck()
		{
			bool canStart = false;
			try
			{
				RedisHelper redisHelper = new RedisHelper();
				redisHelper.StringGet<string>(RedisKeyConfig.Test + 1);
				canStart = true;
			}
			catch (Exception)
			{

			}
			return canStart;
		}
	}
}
