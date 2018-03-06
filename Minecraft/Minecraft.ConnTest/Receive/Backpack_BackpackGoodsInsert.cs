using Minecraft.Config;
using Minecraft.Model.ReqResp;
using System;
using System.Net.Sockets;

namespace Minecraft.ConnTest.Receive
{
	public class Backpack_BackpackGoodsInsert
	{
		public void Execute(Socket socketClient, MainCommand mainCommand, SecondCommand secondCommand, string respStr)
		{
			var resp = respStr.JsonDeserialize<BackpackGoodsInsertResp>();
			if (resp == null || resp.PlayerId <= 0)
			{
				return;
			}
			Console.WriteLine($"背包信息：{respStr}");
		}
	}
}
