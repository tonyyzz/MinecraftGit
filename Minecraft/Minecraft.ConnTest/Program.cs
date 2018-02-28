using Minecraft.Config;
using Minecraft.Model.ReqResp;
using Minecraft.Model.ReqResp.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Minecraft.ConnTest
{
	class Program
	{
		static void Main(string[] args)
		{
			Socket socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			IPAddress ip = IPAddress.Parse("127.0.0.1");
			//IPAddress ip = IPAddress.Parse("111.230.142.94");
			IPEndPoint point = new IPEndPoint(ip, 2017);
			//进行连接
			socketClient.Connect(point);

			//ThreadPool.QueueUserWorkItem(o =>
			//{
			//	while (true)
			//	{
			//		var protocolStr2 = ProtocolHelper.GetProtocolStr(
			//				MainCommand.Heart, SecondCommand.Heart_Data);
			//		var buffter2 = Encoding.UTF8.GetBytes($"{protocolStr2} {""}##");
			//		socketClient.Send(buffter2);
			//		Thread.Sleep(5000);
			//		//Thread.Sleep(1);
			//	}
			//});


			//不停的接收服务器端发送的消息
			Thread thread = new Thread(Recive)
			{
				IsBackground = true
			};
			thread.Start(socketClient);




			//var protocolStr = ProtocolHelper.GetProtocolStr(
			//	MainCommand.Test, SecondCommand.Test_Test);
			//TestReq req = new TestReq()
			//{
			//	PlayerId = 1
			//};

			var protocolStr = ProtocolHelper.GetProtocolStr(
				MainCommand.Player, SecondCommand.Player_BaseInsert);

			PlayerBaseInsertReq req = new PlayerBaseInsertReq
			{
				PlayerId = 1,
				Fight_Attack = 4,
				Fight_AttackSpeed = 7,
				Fight_Defense = 78,
				Fight_TravelRate = 79,
				Human_Clean = 5,
				Human_GoToilet = 57,
				Human_Hunger = 4,
				Human_Life = 4,

			};





			string cont = req.JsonSerialize();
			var sendContent = CustomEncrypt.Encrypt(cont);
			var buffter = Encoding.UTF8.GetBytes($"{protocolStr} {sendContent}##");
			socketClient.Send(buffter);

			Console.WriteLine("消息发送成功");
			Console.ReadKey();
		}
		static void Recive(object o)
		{
			var send = o as Socket;
			while (true)
			{
				//获取发送过来的消息
				byte[] buffer = new byte[1024 * 1024 * 2];
				var effective = send.Receive(buffer);
				if (effective == 0)
				{
					break;
				}
				//var bytes = buffer.ToList().Take(effective).ToArray();
				//CustomDE.Decrypt(bytes, 0, bytes.Length);

				var str = Encoding.UTF8.GetString(buffer, 0, effective);
				//Console.WriteLine(str);

				try
				{

					//Console.WriteLine("元数据：" + str);

					//黏包情况处理（用结束符分割处理）
					var strs = str.Split(new String[] { MinecraftComConfig.EndingSymbol }, StringSplitOptions.RemoveEmptyEntries);
					if (strs.Count() >= 2)
					{
						Console.WriteLine("------【出现黏包情况】");
					}
					foreach (var item in strs)
					{
						//Console.WriteLine("拆分后的数据包：" + item);
						var deStr = CustomEncrypt.Decrypt(item, "client");
						//Console.WriteLine("解析后的数据：" + deStr);

						var deStrs = deStr.Split(new char[] { MinecraftComConfig.SeparativeSymbol });
						var protocolStr = deStrs[0];
						var dataStr = string.Join(MinecraftComConfig.SeparativeSymbol.ToString(), deStrs.Skip(1).ToArray());
						Console.WriteLine($"协议：{protocolStr}，数据：{dataStr}");
					}
					Console.WriteLine("---------------------------");
				}
				catch (Exception)
				{

					Console.WriteLine("接收异常");
				}

			}
		}
	}
}
