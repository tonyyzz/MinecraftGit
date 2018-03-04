using Minecraft.Config;
using Minecraft.Model.ReqResp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.ConnTest.Receive
{
	public class Heart_HeartData
	{
		public void Execute(MainCommand mainCommand, SecondCommand secondCommand, string respStr)
		{
			Console.WriteLine($"主协议：{mainCommand.ToString()} 次协议：{secondCommand.ToString()} 响应字符串：{respStr}");
			var resp = respStr.JsonDeserialize<MsgResp>();
			if (resp == null || resp.InfoLevel != MsgLevelEnum.Info)
			{
				return;
			}
		}
	}
}
