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
				string redisKey = RedisKeyHelper.GetRedisKeyName(RedisKeyConfig.Test, 1.ToString());
				redisHelper.StringGet<string>(redisKey);
				canStart = true;
			}
			catch (Exception ex)
			{
				Console.WriteLine("【redis】异常：" + ex.ToString());
			}
			return canStart;
		}
	}
}
