
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.CacheRedis
{
	using RedisTools;
	public class RedisPubSubProvider
	{
		private PooledRedisClientManager Pool { get; set; }
		private RedisPubSubProvider()
		{
			var writeServerList = RedisPubSubConfig.Current.WriteServerList.Split(',');
			var readServerList = RedisPubSubConfig.Current.ReadServerList.Split(',');
			Pool = new PooledRedisClientManager(writeServerList, readServerList,
				new RedisClientManagerConfig
				{
					MaxWritePoolSize = RedisPubSubConfig.Current.MaxWritePoolSize,
					MaxReadPoolSize = RedisPubSubConfig.Current.MaxReadPoolSize,
					AutoStart = RedisPubSubConfig.Current.AutoStart,
				});
		}

		public IRedisClient GetClient()
		{
			try
			{
				var connection = (RedisClient)Pool.GetClient();
				return connection;
			}
			catch (TimeoutException)
			{
				return null;
			}
		}

		private static RedisPubSubProvider _instance;
		public static object _providerLock = new object();
		public static RedisPubSubProvider Provider
		{
			get
			{
				lock (_providerLock)
				{
					if (_instance == null)
					{
						var instance = new RedisPubSubProvider();
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
