using Minecraft.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Minecraft.CSRedisTest
{
	/*
	 * private static RedisHelper redisHelper = new RedisHelper();
var cacheModel = redisHelper.StringGet<PlayerbasisModel>(redisKey);
redisHelper.StringSet(redisKey, model, CommonConfig.DefRedisExpiry);
192.168.0.137:6379
	 */
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
		private static CSRedis.RedisClient client;
		static RedisHelper()
		{
			ConnectionString = JsonConfig.Value.ConnectionString.redis;// MinecraftConfiguration.Minecraft_RedisConnStr;
			DefaultKey = JsonConfig.Value.Redis.CachePrefixKey;// MinecraftConfiguration.Minecraft_RedisDefaultKey;
			var strs = ConnectionString.Split(':');
			var host = strs[0];
			var port = Convert.ToInt32(strs[1]);
			client = new CSRedis.RedisClient(host, port);
		}
		public RedisHelper()
		{

		}
		private static string AddKeyPrefix(string key)
		{
			return $"{DefaultKey}:{key}";
		}

		public void StringSet(string key, string value, TimeSpan timeSpan)
		{
			client.Set(AddKeyPrefix(key), value, timeSpan);
		}
		public void StringSet(string key, string value)
		{
			client.Set(AddKeyPrefix(key), value);
		}

		public void StringSet<T>(string key, T value, TimeSpan timeSpan) where T : class
		{
			client.Set(AddKeyPrefix(key), value.JsonSerialize(), timeSpan);
		}
		public void StringSet<T>(string key, T value) where T : class
		{
			client.Set(AddKeyPrefix(key), value.JsonSerialize());
		}


		public string StringGet(string key)
		{
			return client.Get(AddKeyPrefix(key));
		}

		public T StringGet<T>(string key) where T : class
		{
			return client.Get(AddKeyPrefix(key)).JsonDeserialize<T>();
		}

	}
}
