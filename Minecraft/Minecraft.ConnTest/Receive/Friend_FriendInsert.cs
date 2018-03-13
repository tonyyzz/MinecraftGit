using Minecraft.Config;
using Minecraft.Model.ReqResp;
using System;
using System.Net.Sockets;

namespace Minecraft.ConnTest.Receive
{
	public class Friend_FriendInsert
	{
		public void Execute(Socket socketClient, EnumCommand command, string respStr)
		{
			var resp = respStr.JsonDeserialize<FriendInsertResp>();
			if (resp == null)
			{
				return;
			}
			switch (resp.RespLevel)
			{
				case RespLevelEnum.Success:
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
