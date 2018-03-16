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
	/// redis缓存帮助类（单个redis，不建议使用）
	/// </summary>
	public class RedisSingleCacheHelper : RedisCacheHelperBase
	{
		public RedisSingleCacheHelper() : base()
		{
			Client = RedisSingleCacheProvider.Provider.GetClient();
		}
	}
}
