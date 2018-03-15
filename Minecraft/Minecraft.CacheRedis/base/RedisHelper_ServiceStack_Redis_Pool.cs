using RedisTools;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.CacheRedis
{
	public class RedisHelper : RedisOperatorBase
	{
		public RedisHelper() : base() { }

		/// <summary>
		/// 默认的 Key 值（用来当作 RedisKey 的前缀）
		/// </summary>
		private static string DefaultKey;
		private static string AddKeyPrefix(string key)
		{
			return $"{DefaultKey}:{key}";
		}

		public void StringSet<T>(string key, T value, TimeSpan timeSpan) where T : class
		{
			Redis.Set(AddKeyPrefix(key), value, timeSpan);
		}
		public void StringSet<T>(string key, T value) where T : class
		{
			Redis.Set(AddKeyPrefix(key), value);
		}

		public T StringGet<T>(string key)
		{
			return Redis.Get<T>(AddKeyPrefix(key));
		}

		/// <summary>
		/// 发布
		/// </summary>
		/// <param name="toChannel"></param>
		/// <param name="message"></param>
		/// <returns></returns>
		public long PublishMessage(string toChannel, string message)
		{
			return Redis.PublishMessage(toChannel, message);
		}

		/// <summary>
		/// 订阅
		/// </summary>
		/// <param name="channelList"></param>
		/// <param name="OnMessage"></param>
		/// <param name="OnSubscribe"></param>
		/// <param name="OnUnSubscribe"></param>
		public void Subscription(List<string> channelList,
			Action<string, string> OnMessage,
			Action<string> OnSubscribe = null,
			Action<string> OnUnSubscribe = null
			)
		{
			if (channelList == null || !channelList.Any())
			{
				throw new Exception("参数不能为空 或者 列表个数不能为0");
			}
			//创建订阅
			IRedisSubscription subscription = Redis.CreateSubscription();
			//接受到消息时的委托
			subscription.OnMessage = (channel, msg) =>
			{
				//Console.WriteLine("频道【" + channel + "】订阅客户端接收消息：" + ":" + msg + " [" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "]");
				//Console.WriteLine("订阅数：" + subscription.SubscriptionCount);
				//Console.WriteLine("___________________________________________________________________");
				OnMessage(channel, msg);
			};

			//订阅事件处理
			subscription.OnSubscribe = channel =>
			{
				//Console.WriteLine("订阅客户端：开始订阅" + channel);
				OnSubscribe?.Invoke(channel);
			};

			//取消订阅事件处理
			subscription.OnUnSubscribe = channel =>
			{
				//Console.WriteLine("订阅客户端：取消订阅");
				OnUnSubscribe?.Invoke(channel);
			};

			//订阅频道
			subscription.SubscribeToChannels(channelList.ToArray());
		}
	}
}
