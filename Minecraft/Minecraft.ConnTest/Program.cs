using Minecraft.Config;
using Minecraft.ConnTest.Receive;
using Minecraft.Model.ReqResp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Minecraft.ConnTest
{
	class Program
	{
		static void Main(string[] args)
		{
			var socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			IPAddress ip = IPAddress.Parse("127.0.0.1");
			//IPAddress ip = IPAddress.Parse("111.230.142.94");
			IPEndPoint point = new IPEndPoint(ip, 2017);
			//进行连接
			socketClient.Connect(point);

			//不停的接收服务器端发送的消息
			Thread thread = new Thread(Recive)
			{
				IsBackground = true
			};
			thread.Start(socketClient);

			Console.ReadKey();
		}


		


		static void Recive(object o)
		{
			var socketClient = o as Socket;
			while (true)
			{
				//获取发送过来的消息
				byte[] buffer = new byte[1024 * 1024 * 2];
				var effective = socketClient.Receive(buffer);
				if (effective == 0)
				{
					break;
				}
				var str = Encoding.UTF8.GetString(buffer, 0, effective);
				try
				{
					//Console.WriteLine("元数据：" + str);

					//黏包情况处理（用结束符分割处理）
					var strs = str.Split(new String[] { MinecraftCommonConfig.EndingSymbol }, StringSplitOptions.RemoveEmptyEntries);
					if (strs.Count() >= 2)
					{
						Console.WriteLine("------【出现黏包情况】");
					}
					foreach (var item in strs)
					{
						//Console.WriteLine("拆分后的数据包：" + item);
						var deStr = EncryptHelper.Decrypt(item, "client");
						//Console.WriteLine("解析后的数据：" + deStr);

						var deStrs = deStr.Split(new char[] { MinecraftCommonConfig.SeparativeSymbol });
						var protocolStr = deStrs[0];
						var respStr = string.Join(MinecraftCommonConfig.SeparativeSymbol.ToString(), deStrs.Skip(1).ToArray());
						//Console.WriteLine($"协议：{protocolStr}，数据：{respStr}");
						//接收
						//解析枚举
						var mainStr = protocolStr.Substring(0, ProtocolLen.Main);
						var secondStr = protocolStr.Substring(ProtocolLen.Main);

						int mainInt = Convert.ToInt32(mainStr);
						int secondInt = Convert.ToInt32(secondStr);

						MainCommand mainCommand = (MainCommand)mainInt;
						SecondCommand secondCommand = (SecondCommand)secondInt;


						//---------------输出协议传输信息----------------
						ComManager.ConsoleWriteResp(mainCommand, secondCommand, respStr);

						// 加载程序集(dll文件地址)，使用Assembly类
						var execName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, AppDomain.CurrentDomain.FriendlyName);
						Assembly assembly = Assembly.LoadFile(execName);

						string className = "Minecraft.ConnTest.Receive." + secondCommand.ToString();

						//获取类型，参数（名称空间+类）   
						Type type = assembly.GetType(className);

						//创建该对象的实例，object类型，参数（名称空间+类）   
						object instance = assembly.CreateInstance(className);
						if (instance == null)
						{
							continue;
						}

						//设置Show_Str方法中的参数类型，Type[]类型；如有多个参数可以追加多个   
						Type[] params_type = new Type[4];
						params_type[0] = typeof(Socket);
						params_type[1] = typeof(MainCommand);
						params_type[2] = typeof(SecondCommand);
						params_type[3] = typeof(string);

						//设置Show_Str方法中的参数值；如有多个参数可以追加多个   
						Object[] params_obj = new Object[4];
						params_obj[0] = socketClient;
						params_obj[1] = mainCommand;
						params_obj[2] = secondCommand;
						params_obj[3] = respStr;

						//执行Show_Str方法   
						object value = type.GetMethod("Execute", params_type).Invoke(instance, params_obj);



					}
					//Console.WriteLine("---------------------------");
				}
				catch (Exception ex)
				{

					Console.WriteLine("接收异常:" + ex);
				}

			}
		}
	}
}
