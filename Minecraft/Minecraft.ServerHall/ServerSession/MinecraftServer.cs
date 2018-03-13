using SuperSocket.SocketBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketBase.Protocol;
using SuperSocket.Facility.Protocol;
using Minecraft.Config;
using Minecraft.Config.ipConst;

namespace Minecraft.ServerHall
{
	public class MinecraftServer : AppServer<MinecraftSession>
	{
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
			EnumCommand command = ProtocolHelper.GetCommand(requestInfo.Key);

			if (MinecraftConfiguration.IsConsoleWrite)
			{
				string ipUserNameTipStr = IpConstConfig.GetIpUserNameTipStr(session.RemoteEndPoint.Address.ToString());
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine("-------------------------------------------------------");
				Console.WriteLine($"正在执行命令：（时间：{DateTime.Now.ToStr()}）");
				if (!ipUserNameTipStr.IsNullOrWhiteSpace())
				{
					Console.ForegroundColor = ConsoleColor.Green;
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.Magenta;
				}
				Console.WriteLine($"	IP地址：{session.RemoteEndPoint}{ipUserNameTipStr}");
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine($"	协议：{command.ToString()}");
				Console.WriteLine($"	当前在线人数：{session.AppServer.GetAllSessions().Count()}");
				Console.ResetColor();
			}
		}
	}
}
