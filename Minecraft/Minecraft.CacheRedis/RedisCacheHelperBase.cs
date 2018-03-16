using Minecraft.Config;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.CacheRedis
{
	public class RedisCacheHelperBase
	{
		protected virtual IRedisClient Client { get; set; }

		private static string DefaultKey;

		public RedisCacheHelperBase()
		{
			DefaultKey = MinecraftConfiguration.Minecraft_RedisDefaultKey;
		}

		private static string AddKeyPrefix(string key)
		{
			return $"{DefaultKey}:{key}";
		}

		public void FlushAll()
		{
			Client.FlushAll();
		}

		public void StringSet<T>(string key, T value, TimeSpan timeSpan) where T : class
		{
			Client.Set(AddKeyPrefix(key), value, timeSpan);
		}
		public void StringSet<T>(string key, T value) where T : class
		{
			Client.Set(AddKeyPrefix(key), value);
		}

		public T StringGet<T>(string key)
		{
			return Client.Get<T>(AddKeyPrefix(key));
		}
	}
}
