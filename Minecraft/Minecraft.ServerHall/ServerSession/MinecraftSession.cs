using SuperSocket.SocketBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperSocket.SocketBase.Protocol;
using Minecraft.Common;

namespace SuperSocketSdy.ConsoleTest.Telnet
{
	public class MinecraftSession : AppSession<MinecraftSession>
	{
		protected override void HandleException(Exception e)
		{
			this.Send(CustomEncrypt.Encrypt("Application error: {0}"), e.Message);
		}

		protected override void HandleUnknownRequest(StringRequestInfo requestInfo)
		{
			this.Send(CustomEncrypt.Encrypt("Unknow request"));
		}

		protected override void OnSessionClosed(CloseReason reason)
		{
			//add you logics which will be executed after the session is closed
			base.OnSessionClosed(reason);
			//Console.WriteLine("");
			//Console.WriteLine($"远程客户端{this.RemoteEndPoint.Address.ToString()}:{this.RemoteEndPoint.Port}断开连接");
		}

		protected override void OnSessionStarted()
		{
			this.Send(CustomEncrypt.Encrypt("Welcome to SuperSocket Telnet Server"));
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
		}

		//服务器发送给客户端的消息的后续处理方法
		protected override string ProcessSendingMessage(string rawMessage)
		{
			//Console.WriteLine($"rawMessage:{rawMessage}");


			//加密处理

			return rawMessage;
		}
	}
}
