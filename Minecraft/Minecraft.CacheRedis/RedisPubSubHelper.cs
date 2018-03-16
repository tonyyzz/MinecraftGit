﻿using RedisTools;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.CacheRedis
{
	/// <summary>
	/// redis发布订阅帮助类（redis集群模式）
	/// </summary>
	public class RedisPubSubHelper
	{
		private IRedisClient Redis { get; set; }
		public RedisPubSubHelper()
		{
			Redis = (RedisClient)RedisPubSubProvider.Provider.GetClient();
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
				OnMessage(channel, msg);
			};

			//订阅事件处理
			subscription.OnSubscribe = channel =>
			{
				OnSubscribe?.Invoke(channel);
			};

			//取消订阅事件处理
			subscription.OnUnSubscribe = channel =>
			{
				OnUnSubscribe?.Invoke(channel);
			};

			//订阅频道
			subscription.SubscribeToChannels(channelList.ToArray());
		}
	}
}
