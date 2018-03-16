using Minecraft.Config;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.CacheRedis
{
	public class RedisSentinelCacheProvider
	{
		public IRedisClient GetClient()
		{
			try
			{
				RedisSentinel redisSentinel = new RedisSentinel(
					MinecraftConfiguration.Minecraft_Redis_SentinelHosts,
					MinecraftConfiguration.Minecraft_Redis_SentinelPattern_MasterName);
				var manager = redisSentinel.Start() as PooledRedisClientManager;
				var client = manager.GetClient();
				return client;
			}
			catch (TimeoutException ex)
			{
				Console.WriteLine("连接超时  "+ex.ToString());
				return null;
			}
			catch (Exception ex)
			{
				Console.WriteLine("异常  " + ex.ToString());
				return null;
			}
		}

		private static RedisSentinelCacheProvider _instance;
		public static object _providerLock = new object();
		public static RedisSentinelCacheProvider Provider
		{
			get
			{
				lock (_providerLock)
				{
					if (_instance == null)
					{
						var instance = new RedisSentinelCacheProvider();
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
