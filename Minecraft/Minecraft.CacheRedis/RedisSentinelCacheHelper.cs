using Minecraft.Config;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.CacheRedis
{
	/// <summary>
	/// redis缓存帮助类（哨兵模式 redis cache缓存，建议使用）
	/// </summary>
	public class RedisSentinelCacheHelper : RedisCacheHelperBase
	{
		public RedisSentinelCacheHelper() : base()
		{
			Client = RedisSentinelCacheProvider.Provider.GetClient();
		}
	}
}
