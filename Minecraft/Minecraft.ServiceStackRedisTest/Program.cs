using Minecraft.Config;
using RedisTools;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Minecraft.ServiceStackRedisTest
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("redis 发布选择1，订阅选择2");
			var index = Convert.ToInt32(Console.ReadLine());
			if (index == 1)
			{
				Console.WriteLine("选择的是发布");
				Pub();
				using (IRedisClient publisher = new RedisClient("127.0.0.1", 6379))
				{
					for (int i = 1; i <= 50; i++)
					{
						publisher.PublishMessage("channel-1", string.Format("这是我发送的第{0}消息!", i));
						Thread.Sleep(200);
					}
				}
			}
			else
			{
				Console.WriteLine("选择的是订阅");
				//订阅
				Subscription();
			}
			Console.ReadKey();
		}

		/// <summary>
		/// 订阅
		/// 一个客户端订阅channel-1
		/// </summary>
		public static void Subscription()
		{
			using (var consumer = new RedisClient("127.0.0.1", 6379))
			{
				//创建订阅
				IRedisSubscription subscription = consumer.CreateSubscription();

				//接受到消息时的委托
				subscription.OnMessage = (channel, msg) =>
				{
					Console.WriteLine("频道【" + channel + "】订阅客户端接收消息：" + ":" + msg + " [" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "]");
					Console.WriteLine("订阅数：" + subscription.SubscriptionCount);
					Console.WriteLine("___________________________________________________________________");
				};

				//订阅事件处理
				subscription.OnSubscribe = channel => { Console.WriteLine("订阅客户端：开始订阅" + channel); };

				//取消订阅事件处理
				subscription.OnUnSubscribe = a => { Console.WriteLine("订阅客户端：取消订阅"); };

				//订阅频道
				subscription.SubscribeToChannels("channel-1");

			}
		}

		//使用发布者仅仅能够发布消息，但是不能够检测一些事件的变化，Redis中还有一个RedisPublishServer的类，里面包括一些事件能够使我们很好地检测服务的运行。
		//OnMessage：接受到消息；
		//OnStart:发布服务开始运行时；
		//OnStop：发布服务停止运行时；
		//OnUnSubscribe：订阅者取消订阅时；
		//OnError:发布出现错误时；
		//OnFailover:Redis服务器冗余切换时；
		//发布服务端初始化完成后，调用Start()方法，开始执行发布服务。
		//发布服务执行后，执行消息的发布client.PublishMessage时，发布服务端也能够接受到发布的消息。
		public static void Pub()
		{
			//PooledRedisClientManager
			IRedisClientsManager RedisClientManager = new PooledRedisClientManager("127.0.0.1:6379");

			//发布、订阅服务 IRedisPubSubServer'
			//订阅频道channel-1,channel-2
			var pubSubServer = new RedisPubSubServer(RedisClientManager, "channel-1", "channel-2")
			{

				//接受到消息时的委托
				OnMessage = (channel, msg) =>
				{

					Console.WriteLine("【Redis发布服务APP】从频道{0}接收消息：{1}  时间：{2}", channel, msg, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
					Console.WriteLine("___________________________________________________________________");
				},
				OnStart = () =>
				{
					Console.WriteLine("发布服务已启动");
					Console.WriteLine("___________________________________________________________________");
				},
				OnStop = () => { Console.WriteLine("服务停止"); },

				//取消订阅频道时
				OnUnSubscribe = channel =>
				{
					Console.WriteLine(channel);
				},
				OnError = e => { Console.WriteLine(e.Message); },
				OnFailover = s => { Console.WriteLine(s); }
			};
			//pubSubServer.OnHeartbeatReceived = () => { Console.WriteLine("OnHeartbeatReceived"); };
			//pubSubServer.OnHeartbeatSent = () => { Console.WriteLine("OnHeartbeatSent"); };
			//pubSubServer.IsSentinelSubscription = true;
			//接收消息
			pubSubServer.Start();
		}
	}
}
