using SuperSocket.SocketBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketBase.Protocol;
using SuperSocket.Facility.Protocol;
using Minecraft.Config;

namespace Minecraft.ServerHall
{
	public class MinecraftServer : AppServer<MinecraftSession>
	{

		//自定义协议
		//public TelnetServer()
		//: base(new CommandLineReceiveFilterFactory(Encoding.UTF8,new BasicRequestInfoParser(":",",")))
		//{

		//}

		//public TelnetServer()
		//: base(new CommandLineReceiveFilterFactory(Encoding.UTF8))
		//{

		//}


		//public TelnetServer()
		//: base(new CountSpliterReceiveFilterFactory((byte)'#', 8))
		//{

		//}

		//固定请求大小协议
		//public TelnetServer()
		//: base(new DefaultReceiveFilterFactory<MyReceiveFilter, StringRequestInfo>()) //使用默认的接受过滤器工厂 (DefaultReceiveFilterFactory)
		//{

		//}
		//结束符协议
		public MinecraftServer()
		: base(new TerminatorReceiveFilterFactory(SeparatorConfig.Protocol))
		{
			//Console.WriteLine("MinecraftServer");
		}
		[Obsolete]
		protected override void OnStartup()
		{
			//Console.WriteLine("OnStartup");
			base.OnStartup();
		}

		protected override void OnStarted()
		{
			//Console.WriteLine("OnStarted");
			base.OnStarted();
		}

		protected override void OnStopped()
		{
			//Console.WriteLine("OnStopped");
			base.OnStopped();
		}

		protected override bool Setup(IRootConfig rootConfig, IServerConfig config)
		{
			//Console.WriteLine("Setup");
			return base.Setup(rootConfig, config);
		}

		protected override void OnSystemMessageReceived(string messageType, object messageData)
		{
			//Console.WriteLine($"-----messageType:{messageType} messageData:{messageData.JsonSerialize()}");
			base.OnSystemMessageReceived(messageType, messageData);
		}

		protected override void OnNewSessionConnected(MinecraftSession session)
		{
			//Console.WriteLine($"新连接进入：{session.RemoteEndPoint.Address.ToString()}:{session.RemoteEndPoint.Port}");
			base.OnNewSessionConnected(session);
		}

		protected override void OnSessionClosed(MinecraftSession session, CloseReason reason)
		{
			//Console.WriteLine($"连接断开：{session.RemoteEndPoint.Address.ToString()}:{session.RemoteEndPoint.Port}");
			base.OnSessionClosed(session, reason);
		}
		protected override bool RegisterSession(string sessionID, MinecraftSession appSession)
		{
			//Console.WriteLine($"注册Session：sessionID:{sessionID}  IPAddress:{appSession.RemoteEndPoint.Address.ToString()}:{appSession.RemoteEndPoint.Port}");
			return base.RegisterSession(sessionID, appSession);
		}

		protected override void ExecuteCommand(MinecraftSession session, StringRequestInfo requestInfo)
		{
			base.ExecuteCommand(session, requestInfo);
			(MainCommand mainCommand, SecondCommand secondCommand) = ProtocolHelper.GetCommand(requestInfo.Key);
			Console.WriteLine($"正在执行的命令：时间：{DateTime.Now.ToStr()} IPAddress:{session.RemoteEndPoint} 主协议：{mainCommand.ToString()} 次协议：{secondCommand.ToString()}");
		}
	}
}
