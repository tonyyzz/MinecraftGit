using Minecraft.Config;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.CacheRedis
{
	public class RedisSingleCacheProvider
	{
		/// <summary>
		/// 连接字符串
		/// </summary>
		private static string ConnectionString;
		public IRedisClient GetClient()
		{
			try
			{
				ConnectionString = JsonConfig.Value.ConnectionString.redis;// MinecraftConfiguration.Minecraft_RedisConnStr;
				var strs = ConnectionString.Split(':');
				var host = strs[0];
				var port = Convert.ToInt32(strs[1]);
				var client = new RedisClient(host, port);
				return client;
			}
			catch (TimeoutException)
			{
				return null;
			}
		}

		private static RedisSingleCacheProvider _instance;
		public static object _providerLock = new object();
		public static RedisSingleCacheProvider Provider
		{
			get
			{
				lock (_providerLock)
				{
					if (_instance == null)
					{
						var instance = new RedisSingleCacheProvider();
						_instance = instance;
						return _instance;
					}
					else
					{

						return _instance;
					}
				}
			}
		}
	}
}
