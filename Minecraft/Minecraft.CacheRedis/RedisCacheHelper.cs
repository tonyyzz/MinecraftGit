using Minecraft.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.CacheRedis
{
	/// <summary>
	/// redis cache 帮助类（通过配置切换single和sentinel模式）
	/// </summary>
	public class RedisCacheHelper : RedisCacheHelperBase
	{
		/// <summary>
		/// redis cache 模式
		/// </summary>
		public static EnumRedisCachePattern RedisCachePattern
		{
			get
			{
				//var pattern = Convert.ToInt32(MinecraftConfiguration.Minecraft_Redis_CachePattern);
				return (EnumRedisCachePattern)JsonConfig.Value.Redis.CachePattern; //pattern;
			}
		}

		public RedisCacheHelper() : base()
		{
			switch (RedisCachePattern)
			{
				case EnumRedisCachePattern.Single:
					{
						Client = RedisSingleCacheProvider.Provider.GetClient();
					}
					break;
				case EnumRedisCachePattern.Sentinel:
					{
						Client = RedisSentinelCacheProvider.Provider.GetClient();
					}
					break;
				default:
					{
						Client = null;
					}
					break;
			}
		}
	}
	/// <summary>
	/// redis cache 模式
	/// </summary>
	public enum EnumRedisCachePattern
	{
		/// <summary>
		/// 单个
		/// </summary>
		Single = 1,
		/// <summary>
		/// 哨兵
		/// </summary>
		Sentinel,
	}
}
