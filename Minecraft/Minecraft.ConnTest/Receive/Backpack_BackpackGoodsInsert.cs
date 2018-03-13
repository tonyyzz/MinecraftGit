using Minecraft.Config;
using Minecraft.Model.ReqResp;
using System;
using System.Net.Sockets;

namespace Minecraft.ConnTest.Receive
{
	public class Backpack_BackpackGoodsInsert
	{
		public void Execute(Socket socketClient, EnumCommand command, string respStr)
		{
			var resp = respStr.JsonDeserialize<BackpackGoodsInsertResp>();
			if (resp == null)
			{
				return;
			}
			switch (resp.RespLevel)
			{
				case RespLevelEnum.Success:
					{
						Console.WriteLine($"背包信息：{respStr}");
					}
					break;
				case RespLevelEnum.Warn:
					break;
				case RespLevelEnum.Error:
					break;
				default:
					break;
			}
			
		}
	}
}
