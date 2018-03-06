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
			//进入连接
			this.Send(MainCommand.Conn, SecondCommand.Conn_Success, new BaseResp { RespLevel = RespLevelEnum.Success, Msg = "Welcome to SuperSocket Minecraft Server" });

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

			//var sessions = this.AppServer.GetAllSessions().ToList();
			//Console.WriteLine($"当前连接数量：{sessions.Count()}");

			//ip,address,sessionID
			// this.SessionID
			//this.IsLogin
		}

		protected override void OnSessionClosed(CloseReason reason)
		{

			//断开连接

			if (minecraftSessionInfo.IsLogin)
			{
				//存储数据
				PlayerbasisBLL.Update(minecraftSessionInfo.player, nameof(minecraftSessionInfo.player.PlayerId));
			}
			//add you logics which will be executed after the session is closed
			//base.OnSessionClosed(reason);
			this.Send(MainCommand.Conn, SecondCommand.Conn_Close, new BaseResp { RespLevel = RespLevelEnum.Success, Msg = "断开连接的通知" });


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
			return str + CommonConfig.EndingSymbol;
		}

		protected override void HandleException(Exception e)
		{
			this.Send(MainCommand.Handle, SecondCommand.Handle_HandleException, new BaseResp { RespLevel = RespLevelEnum.Error, Msg = e.Message });
		}

		protected override void HandleUnknownRequest(StringRequestInfo requestInfo)
		{
			this.Send(MainCommand.Handle, SecondCommand.Handle_HandleUnknownRequest, new BaseResp { RespLevel = RespLevelEnum.Error, Msg = $"Unknow request：{requestInfo.Key}" });
		}

	}
}
