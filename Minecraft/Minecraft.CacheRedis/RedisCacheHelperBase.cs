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
			//先序列化后再存，不然反序列化是失败
			Client.Set(AddKeyPrefix(key), value.JsonSerialize(), timeSpan);
		}
		public void StringSet<T>(string key, T value) where T : class
		{
			//先序列化后再存，不然反序列化是失败
			Client.Set(AddKeyPrefix(key), value.JsonSerialize());
		}

		public T StringGet<T>(string key)
		{
			return Client.Get<string>(AddKeyPrefix(key)).JsonDeserialize<T>();
		}
	}
}
