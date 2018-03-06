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
			Func<(MainCommand, SecondCommand, T)> func) where T : BaseReq
		{
			var (mainCommand, secondCommand, req) = func();
			var protocolStr = ProtocolHelper.GetProtocolStr(mainCommand, secondCommand);
			string cont = req.JsonSerialize();
			var sendContent = EncryptHelper.Encrypt(cont);
			var buffter = Encoding.UTF8.GetBytes($"{protocolStr} {sendContent}##");
			socketClient.Send(buffter);
		}
		/// <summary>
		/// 输出协议信息
		/// </summary>
		/// <param name="mainCommand"></param>
		/// <param name="secondCommand"></param>
		/// <param name="respStr"></param>
		public static void ConsoleWriteResp(MainCommand mainCommand, SecondCommand secondCommand, string respStr)
		{
			var resp = respStr.JsonDeserialize<BaseResp>();
			Console.WriteLine($"主协议：{mainCommand.ToString()} 次协议：{secondCommand.ToString()} 【响应消息级别：{resp.RespLevel.ToString()}】 响应字符串：{respStr}");
		}
	}
}
