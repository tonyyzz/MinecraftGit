using Minecraft.Config;
using Minecraft.ConnTest.Send;
using Minecraft.Model.ReqResp;
using System;
using System.Net.Sockets;
using System.Threading;

namespace Minecraft.ConnTest.Receive
{
	public class Backpack_BackpackGoodsSelect
	{
		public void Execute(Socket socketClient, EnumCommand command, string respStr)
		{
			var resp = respStr.JsonDeserialize<BackpackGoodsSelectResp>();
			if (resp == null)
			{
				return;
			}
			switch (resp.RespLevel)
			{
				case RespLevelEnum.Success:
					{
						
					}
					break;
				case RespLevelEnum.Warn:
					break;
				case RespLevelEnum.Error:
					{
						Console.WriteLine(resp.Msg);
					}
					break;
				default:
					break;
			}
		}
	}
}
