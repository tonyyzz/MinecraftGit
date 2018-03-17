using SuperSocket.SocketBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperSocket.SocketBase.Protocol;
using Minecraft.Config;
using Minecraft.Model;
using Minecraft.Model.ReqResp;
using Minecraft.BLL.mysql;
using Minecraft.Config.ipConst;

namespace Minecraft.ServerHall
{
	public class MinecraftSession : AppSession<MinecraftSession>
	{
		/// <summary>
		/// minecraft session info ext
		/// </summary>
		public MinecraftSessionInfo minecraftSessionInfo = new MinecraftSessionInfo();

		protected override void OnSessionStarted()
		{
			this.Logger.Info($"进入连接：{this.RemoteEndPoint.ToString()}");
			//进入连接
			if (MinecraftConfiguration.IsConsoleWrite)
			{
				string ipUserNameTipStr = IpConstConfig.GetIpUserNameTipStr(this.RemoteEndPoint.Address.ToString());
				if (!ipUserNameTipStr.IsNullOrWhiteSpace())
				{
					Console.ForegroundColor = ConsoleColor.Gray;
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.DarkYellow;
				}
				Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------");
				Console.Write($"->->->有新客户端进入（时间：{DateTime.Now.ToStr()}）");
				Console.Write($"IP地址：{this.RemoteEndPoint.ToString()}{ipUserNameTipStr}");
				Console.WriteLine($"	当前在线人数：{this.AppServer.GetAllSessions().Count()}");
				Console.ResetColor();
			}
			this.Send(EnumCommand.Conn_Success, new BaseResp { RespLevel = RespLevelEnum.Success, Msg = "Welcome to SuperSocket Minecraft Server" });

			//Console.WriteLine("");
			//Console.WriteLine($"远程IP端口：{this.RemoteEndPoint.Address.ToString()}:{this.RemoteEndPoint.Port}");

			//Console.WriteLine($"编码：{this.Charset.WebName}");
			//Console.WriteLine($"是否连接：{this.Connected}");
			//Console.WriteLine($"当前命令：{ this.CurrentCommand}");
			//Console.WriteLine($"最后一次激活时间：{this.LastActiveTime.ToString("yyyy-MM-dd HH:mm:ss")}");
			//Console.WriteLine($"本地IP端口：{this.LocalEndPoint.Address.ToString()}:{this.LocalEndPoint.Port}");
			//Console.WriteLine($"PrevCommand:{this.PrevCommand}");
			//Console.WriteLine($"SessionID:{this.SessionID}");
			//Console.WriteLine($"开始时间：{this.StartTime.ToString("yyyy-MM-dd HH:mm:ss")}");
			//Console.WriteLine($"安全协议：{this.SecureProtocol.ToString()}");

			var sessions = this.AppServer.GetAllSessions().ToList();
			//Console.WriteLine($"当前连接数量：{sessions.Count()}");

			//ip,address,sessionID
			// this.SessionID
			//this.IsLogin
		}

		protected override void OnSessionClosed(CloseReason reason)
		{
			//断开连接
			if (MinecraftConfiguration.IsConsoleWrite)
			{
				string ipUserNameTipStr = IpConstConfig.GetIpUserNameTipStr(this.RemoteEndPoint.Address.ToString());
				if (!ipUserNameTipStr.IsNullOrWhiteSpace())
				{
					Console.ForegroundColor = ConsoleColor.DarkGray;
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.DarkMagenta;
				}
				Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------");
				Console.Write($"<-<-<-客户端断开连接（时间：{DateTime.Now.ToStr()}）");
				Console.Write($"IP地址：{this.RemoteEndPoint.ToString()}{ipUserNameTipStr}");
				Console.WriteLine($"	当前在线人数：{this.AppServer.GetAllSessions().Count()}");
				Console.ResetColor();
			}

			if (minecraftSessionInfo.IsLogin)
			{
				//存储数据
				PlayerbasisBLL.Update(minecraftSessionInfo.player);
			}
			//add you logics which will be executed after the session is closed
			//base.OnSessionClosed(reason);
			this.Send(EnumCommand.Conn_Close, new BaseResp { RespLevel = RespLevelEnum.Success, Msg = "断开连接的通知" });


			//var sessions = this.AppServer.GetAllSessions().ToList();
			// Console.WriteLine($"当前连接数量：{sessions.Count()}");
			//Console.WriteLine("");
			//Console.WriteLine($"远程客户端{this.RemoteEndPoint.Address.ToString()}:{this.RemoteEndPoint.Port}断开连接");
		}

		//服务器发送给客户端的消息的后续处理方法
		protected override string ProcessSendingMessage(string rawMessage)
		{
			//加密处理
			var str = EncryptHelper.Encrypt(rawMessage);
			//加上 数据结尾分隔符，用作黏包情况处理
			return str + SeparatorConfig.StickyBag;
		}

		protected override void HandleException(Exception ex)
		{
			string exceptionStr = $"服务器错误：{ex.ToString()}";
			this.Logger.Fatal(exceptionStr);
			Console.WriteLine(exceptionStr);
			this.Send(EnumCommand.Handle_HandleException, new BaseResp { RespLevel = RespLevelEnum.Error, Msg = ex.Message });
		}

		protected override void HandleUnknownRequest(StringRequestInfo requestInfo)
		{
			if (MinecraftConfiguration.IsConsoleWrite)
			{
				Console.WriteLine($"时间：{DateTime.Now.ToStr()} 客户端未知请求：{requestInfo.Key}");
			}
			this.Send(EnumCommand.Handle_HandleUnknownRequest, new BaseResp { RespLevel = RespLevelEnum.Error, Msg = $"Unknow request：{requestInfo.Key}" });
		}
	}
}
