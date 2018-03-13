using Minecraft.Config;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;

namespace Minecraft.ConnTest
{
	public class ClientStart
	{
		/// <summary>
		/// 启动一个客户端
		/// </summary>
		public static void Start(Socket socketClient = null, bool isReConn = false)
		{
#if DEBUG //本地测试
			string ipStr = "127.0.0.1";
			int port = 2018;
#elif MINECRAFT_LAN //windows局域网测试
			string ipStr = "192.168.0.137";
			int port = 2017;
#elif LINUX_LAN //linux局域网测试
			string ipStr = "192.168.0.112";
			int port = 2017;
#else //（不使用，只用来做模板）
			string ipStr = "192.168.0.137";
			int port = 2017;
#endif
			bool hasException = false;
			IPAddress ip = IPAddress.Parse(ipStr);
			IPEndPoint point = new IPEndPoint(ip, port);
			if (socketClient == null)
			{
				socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			}
			try
			{
				//进行连接
				//socketClient.Connect(point);
				if (!isReConn)
				{
					Console.WriteLine("连接...");
				}
				else
				{
					Console.WriteLine("客户端重连...");
				}
				//socketClient.Connect(point);
				socketClient.BeginConnect(point, (rs) =>
				{
				}, null);
			}
			catch (SocketException ex)
			{
				//Thread.Sleep(3000);
				//Console.WriteLine($"1：{ex.ToString()}");
				//Console.WriteLine("客户端重连...");
				////socketClient.Disconnect(true);
				//socketClient.Dispose();
				//socketClient = null;
				//ClientStart.Start(socketClient);
				hasException = true;
			}
			catch (Exception ex)
			{
				//Thread.Sleep(1000);
				//Console.WriteLine($"2：{ex.ToString()}");
				//Console.WriteLine("客户端重连...");
				//socketClient.Dispose();
				//socketClient = null;
				//ClientStart.Start(socketClient);
				hasException = true;
			}
			if (!hasException)
			{
				//不停的接收服务器端发送的消息
				Thread thread = new Thread(Receive)
				{
					IsBackground = true
				};
				thread.Start(socketClient);
			}
		}

		private static void Receive(object o)
		{
			var socketClient = o as Socket;
			while (true)
			{
				Thread.Sleep(1);
				try
				{
					//获取发送过来的消息
					byte[] buffer = new byte[1024 * 1024 * 2];
					var effective = socketClient.Receive(buffer);
					if (effective == 0)
					{
						break;
					}
					var str = Encoding.UTF8.GetString(buffer, 0, effective);
					//黏包情况处理（用结束符分割处理）
					var strs = str.Split(new String[] { SeparatorConfig.StickyBag }, StringSplitOptions.RemoveEmptyEntries);
					if (strs.Count() >= 2)
					{
						Console.WriteLine("------【出现黏包情况】");
					}
					foreach (var item in strs)
					{
						//Console.WriteLine("拆分后的数据包：" + item);
						var deStr = EncryptHelper.Decrypt(item, "client");
						//Console.WriteLine("解析后的数据：" + deStr);

						var deStrs = deStr.Split(new string[] { SeparatorConfig.Transfer }, StringSplitOptions.None);
						var protocolStr = deStrs[0];
						var respStr = string.Join(SeparatorConfig.Transfer, deStrs.Skip(1).ToArray());
						//Console.WriteLine($"协议：{protocolStr}，数据：{respStr}");
						//接收
						//解析枚举

						EnumCommand command = ProtocolHelper.GetCommand(protocolStr);

						//▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲输出协议传输信息▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲
						ComManager.ConsoleWriteResp(command, respStr);

						// 加载程序集(dll文件地址)，使用Assembly类
						var execName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, AppDomain.CurrentDomain.FriendlyName);
						Assembly assembly = Assembly.LoadFile(execName);

						string className = "Minecraft.ConnTest.Receive." + command.ToString();

						//获取类型，参数（名称空间+类）   
						Type type = assembly.GetType(className);

						//创建该对象的实例，object类型，参数（名称空间+类）   
						object instance = assembly.CreateInstance(className);
						if (instance == null)
						{
							continue;
						}

						//设置Show_Str方法中的参数类型，Type[]类型；如有多个参数可以追加多个   
						Type[] params_type = new Type[3];
						params_type[0] = typeof(Socket);
						params_type[1] = typeof(EnumCommand);
						params_type[2] = typeof(string);

						//设置Show_Str方法中的参数值；如有多个参数可以追加多个   
						Object[] params_obj = new Object[3];
						params_obj[0] = socketClient;
						params_obj[1] = command;
						params_obj[2] = respStr;

						//执行Show_Str方法   
						object value = type.GetMethod("Execute", params_type).Invoke(instance, params_obj);
					}
					//Console.WriteLine("---------------------------");
				}
				catch (System.InvalidOperationException ex)
				{
					Thread.Sleep(1000);
				}
				catch (System.Net.Sockets.SocketException ex)
				{
					Console.ForegroundColor = ConsoleColor.Magenta;
					Console.WriteLine("服务器已经关闭！！！");
					Console.ResetColor();
					Thread.Sleep(1000);
					socketClient.Dispose();
					socketClient = null;
					ClientStart.Start(socketClient, true);
					break;
				}
				catch (Exception ex)
				{

					Console.WriteLine("接收异常:" + ex);
				}

			}
		}
	}
}
