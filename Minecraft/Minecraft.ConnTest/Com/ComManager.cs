using Minecraft.Config;
using Minecraft.Model.ReqResp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.ConnTest
{
	public class ComManager
	{
		public static void Send<T>(Socket socketClient,
			Func<CommandReq<T>> func) where T : BaseReq
		{
			var commandReq = func();
			var protocolStr = ProtocolHelper.GetProtocolStr(commandReq.Command);
			string cont = commandReq.Req.JsonSerialize();
			var sendContent = EncryptHelper.Encrypt(cont);
			var buffter = Encoding.UTF8.GetBytes($"{protocolStr} {sendContent}##");
			socketClient.Send(buffter);
		}
		/// <summary>
		/// 输出协议信息
		/// </summary>
		/// <param name="mainCommand"></param>
		/// <param name="command"></param>
		/// <param name="respStr"></param>
		public static void ConsoleWriteResp(EnumCommand command, string respStr)
		{
			var resp = respStr.JsonDeserialize<BaseResp>();

			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("-------------------------------------------------------");
			Console.WriteLine($"接收返回的数据：（时间：{DateTime.Now.ToStr()}）");
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine($"	协议：{command.ToString()}");
			Console.WriteLine($"	响应消息级别：{resp.RespLevel.ToString()}");
			Console.ForegroundColor = ConsoleColor.DarkYellow;
			Console.WriteLine($"	响应字符串：{respStr}");
			Console.ResetColor();
		}
	}
}
