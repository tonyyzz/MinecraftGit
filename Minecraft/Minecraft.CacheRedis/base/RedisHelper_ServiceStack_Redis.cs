using Minecraft.Config;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.CacheRedis
{
	public class RedisHelper
	{
		/// <summary>
		/// 连接字符串
		/// </summary>
		private static string ConnectionString;
		/// <summary>
		/// 默认的 Key 值（用来当作 RedisKey 的前缀）
		/// </summary>
		private static string DefaultKey;
		/// <summary>
		/// 数据库
		/// </summary>
		private static IRedisClient client;

		static RedisHelper()
		{
			ConnectionString = MinecraftConfiguration.Minecraft_RedisConnStr;
			DefaultKey = MinecraftConfiguration.Minecraft_RedisDefaultKey;
			var strs = ConnectionString.Split(':');
			var host = strs[0];
			var port = Convert.ToInt32(strs[1]);
			client = new RedisClient(host, port)
			{
				ConnectTimeout = 3000, //貌似不起作用
			};
		}
		public RedisHelper()
		{

		}

		private static string AddKeyPrefix(string key)
		{
			return $"{DefaultKey}:{key}";
		}

		public void StringSet<T>(string key, T value, TimeSpan timeSpan) where T : class
		{
			client.Set(AddKeyPrefix(key), value, timeSpan);
		}
		public void StringSet<T>(string key, T value) where T : class
		{
			client.Set(AddKeyPrefix(key), value);
		}

		public T StringGet<T>(string key)
		{
			return client.Get<T>(AddKeyPrefix(key));
		}

		public long PublishMessage(string toChannel, string message)
		{
			return client.PublishMessage(toChannel, message);
		}

	}
}
